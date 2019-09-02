using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity_Movement : MonoBehaviour
{
	[SerializeField]
	protected float _moveSpeed = 6f;

	[SerializeField]
	protected float _jumpForce = 10;

	[SerializeField]
	protected float _floorHitRayLength = 2;

	protected Rigidbody _rigidbody;
	protected Transform _transform;
	protected Animator _animator;

	public bool Jump = false;

	public float Horizontal = 0;
	public float Vertical = 0;

	public float Speed { get { return SpeedVector.magnitude; } }

	public Vector3 TurnTarget { get; set; } = Vector3.zero;

	protected Vector3 SpeedVector = Vector3.zero;

	protected bool OnGround { get; private set; } = false;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_transform = GetComponent<Transform>();

		_animator = GetComponentInChildren<Animator>();

		Debug.Assert(_rigidbody != null);
	}

	protected virtual void CheckGround()
	{
		OnGround = false;

		RaycastHit floorHit;
		if (Physics.Raycast(_transform.position, -_transform.up, out floorHit, _floorHitRayLength))
		{
			OnGround = true;
		}

		Debug.DrawLine(_transform.position, _transform.position - _transform.up * _floorHitRayLength, Color.red);
	}

	protected virtual void DoJump()
	{
		if (Jump)
		{
			Jump = false;

			if (OnGround)
			{
				_rigidbody.AddRelativeForce(Vector3.up * _rigidbody.mass * _jumpForce, ForceMode.Impulse);
			}
		}
	}

	protected virtual void Turning()
	{
		var direction = TurnTarget - _transform.position;

		Quaternion newRotatation = Quaternion.LookRotation(direction, Vector3.up);

		_rigidbody.MoveRotation(newRotatation);
	}

	protected virtual void Move()
	{
		SpeedVector = new Vector3(Horizontal, 0, Vertical);
		SpeedVector.Normalize();

		// Normalise the movement vector and make it proportional to the speed per second.
		SpeedVector *= _moveSpeed;

		// Move the player to it's current position plus the movement.
		_rigidbody.MovePosition(_transform.position + SpeedVector * Time.fixedDeltaTime);
	}

	protected abstract void CalculateInput();

	protected virtual void Animate()
	{
		if (_animator == null)
		{
			return;
		}

		_animator.SetFloat("Speed", Speed);
		_animator.SetBool("Jump", !OnGround);
		//Debug.Log($"Setting speed to  {Speed}");
	}

	protected virtual void Update()
	{
		CalculateInput();
		Animate();
	}

	protected virtual void FixedUpdate()
	{
		CheckGround();

		// Move the player around the scene.
		Move();

		// Turn the player to face the mouse cursor.
		Turning();

		DoJump();
	}
}
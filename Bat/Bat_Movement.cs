using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_Movement : MonoBehaviour
{
	[SerializeField]
	private float _movementSpeed = 50;

	[SerializeField]
	private LayerMask _enemyMask;

	public Vector3 StartPosition = Vector3.zero;
	public Vector3 Direction = Vector3.forward;

	private Transform _transform;

	private Vector3 _lastPosition = Vector3.zero;

	private void Start()
	{
		_transform = GetComponent<Transform>();

		_transform.position = StartPosition;

		_lastPosition = StartPosition;

		//Direction = new Vector3(Direction.x, 0, Direction.z);
	}

	private void Update()
	{
		var enemy = EnemyManager.Instance.GetClosestEnemy(_transform.position, 10);
		if(enemy != null)
		{
			var newDirection = enemy.transform.position - _transform.position;
			Direction = Vector3.RotateTowards(Direction, newDirection, Time.deltaTime * 10, Time.deltaTime * 10);
			Direction.Normalize();
		}

		_transform.Translate(Direction * Time.deltaTime * _movementSpeed, Space.World);

		_transform.LookAt(_transform.position + Direction, Vector3.up);


		CheckCollision();


		_lastPosition = _transform.position;

	}

	private void CheckCollision()
	{
		RaycastHit hitInfo;

		if(Physics.Linecast(_lastPosition, _transform.position + Direction, out hitInfo, _enemyMask))
		{
			var enemyGO = hitInfo.collider.GetComponentInParent<Enemy>();

			if (enemyGO != null && enemyGO.IsStunned == false)
			{
				enemyGO.Stun();

				Destroy(gameObject);
			}
		}
	}
}

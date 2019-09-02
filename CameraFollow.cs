using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField]
    private Transform _playerTransform;

	private Transform _transform;

	[SerializeField]
	private float _movementSpeedDampener = 5;

	[SerializeField]
	private float _rotationSpeed = 5f;

	private Vector3 _smoothSpeedVector = Vector3.zero;

	private void Start()
	{
		Debug.Assert(_playerTransform != null);

		_transform = GetComponent<Transform>();
	}

	private void LateUpdate()
	{
		float scroll = Input.GetAxis("Mouse ScrollWheel");
		//Debug.Log(scroll);
		//_transform.Rotate(Vector3.up * scroll);
		_transform.position = Vector3.Lerp(_transform.position, _playerTransform.position, Time.smoothDeltaTime * _movementSpeedDampener);
	}
}

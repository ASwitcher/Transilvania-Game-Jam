using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usturoi_Wobble : MonoBehaviour
{
	private Transform _transform;

	private Vector3 _orgLocal;

	[SerializeField]
	private float _wobbleFrequency = 0.1f;
	[SerializeField]
	private float _wobbleStrength = 1;

	private void Awake()
	{
		_transform = GetComponent<Transform>();

		_orgLocal = _transform.localPosition;
	}

	private void Update()
	{
		var newOffset = Vector3.up * _wobbleStrength * Mathf.Sin(_wobbleFrequency * Time.time);

		_transform.localPosition = newOffset + _orgLocal;
	}
}

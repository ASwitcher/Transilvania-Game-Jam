using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_BatGun : MonoBehaviour
{
	[SerializeField]
	private Bat _batPrefab;

	[SerializeField]
	private int _batCount = 5;

	[SerializeField]
	private Text _uiBatCountText;

	[SerializeField]
	private Transform _batSpawnTransform;

	private Transform _transform;

	private void Awake()
	{
		_transform = GetComponent<Transform>();

		Debug.Assert(_batPrefab != null);
		Debug.Assert(_batSpawnTransform != null);
	}

	private void Update()
	{
		if (Input.GetButtonDown("Fire1") && _batCount > 0)
		{
			_batCount--;
			var bat = _batPrefab.Clone();
			bat.Movement.StartPosition = _batSpawnTransform.position;
			bat.Movement.Direction = _transform.forward;
		}

		if(_uiBatCountText != null)
		{
			_uiBatCountText.text = $"Bats left {_batCount}";
		}
	}
}
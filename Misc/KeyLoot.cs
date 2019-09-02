using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLoot : MonoBehaviour
{
	public KeyManager KeyManager;

	private void Awake()
	{
		Debug.Assert(KeyManager != null);
	}

	private void OnCollisionEnter(Collision collision)
	{
		var go = collision.collider.gameObject;

		if (go.tag == "Player")
		{
			KeyManager.KeysCollectedTotal++;
			Destroy(gameObject);

		}
	}
}

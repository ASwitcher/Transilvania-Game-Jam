using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
	private Bat_Movement _batMovement;

	public Bat_Movement Movement
	{
		get
		{
			if(_batMovement == null)
			{
				_batMovement = GetComponent<Bat_Movement>();
				Debug.Assert(_batMovement != null);
			}

			return _batMovement;
		}
	}

    public Bat Clone()
	{
		return Instantiate(gameObject).GetComponent<Bat>();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	public int health = 1;
	public int numOfHearts;

	public Text _uiText;


	private void Update()
	{
		if(_uiText != null)
		{
			_uiText.text = $"Health {health}";
		}

		if(health <= 0)
		{
			Destroy(gameObject);
		}
	}
}
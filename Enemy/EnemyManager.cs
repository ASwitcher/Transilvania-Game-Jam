using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

	[SerializeField]
	private List<Enemy> _enemyList = new List<Enemy>();

	internal void AddEntity(Enemy enemy)
	{
		_enemyList.Add(enemy);
	}

	public Enemy GetClosestEnemy(Vector3 position, float maxRange = float.PositiveInfinity)
	{
		Enemy enemy = null;
		float auxRange = maxRange;

		for (int i = 0; i < _enemyList.Count; i++)
		{
			if(_enemyList[i].IsStunned)
			{
				continue;
			}

			float dist = Vector3.Distance(_enemyList[i].transform.position, position);
			if(dist < auxRange)
			{
				enemy = _enemyList[i];
				auxRange = dist;
			}
		}

		return enemy;
	}

	private void Awake()
	{
		Instance = this;
	}

	private void OnDestroy()
	{
		Instance = null;
	}
}

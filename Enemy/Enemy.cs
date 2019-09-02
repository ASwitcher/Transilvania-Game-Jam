using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	[SerializeField]
	private float _stunTime = 2;

	private NavMeshAgent _agent;

	public float RemainingStunTime
	{
		get;
		private set;
	} = 0;

	public bool IsStunned { get { return RemainingStunTime > 0; } }

	private void Awake()
	{
		_agent = GetComponent<NavMeshAgent>();
		Debug.Assert(_agent != null);
	}

	private void Start()
	{
		EnemyManager.Instance.AddEntity(this);
	}

	private void Update()
	{
		RemainingStunTime -= Time.deltaTime;

		if(RemainingStunTime > 0)
		{
			_agent.enabled = false;
		}
		else if(_agent.enabled == false)
		{
			_agent.enabled = true;
		}
	}

	public void Stun()
	{
		RemainingStunTime = _stunTime;
	}

	private void OnCollisionEnter(Collision collision)
	{
		
	}

}
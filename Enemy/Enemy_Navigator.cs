using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Navigator : MonoBehaviour
{
	private Enemy_Movement _movement;

	private NavMeshAgent _navMeshAgent;

	private Vector3 _patrolCenter = Vector3.zero;

	[SerializeField]
	private float _patrolRadius = 100;

	[SerializeField]
	private Transform _targetTransform;

	[SerializeField]
	private float _playerFollowMaxDistance = 20;
	[SerializeField]
	private float _patrolPositionUpdateDeltaTime = 10;
	private float _nextPatrolUpdateTime = 0;

	private Transform _transform;

	private Vector3 _targetPosition = Vector3.zero;

	private float _ignorePlayerTimer = 5;
	private float _ignorePlayerTimeDelta = 0;

	private void Awake()
	{
		_transform = GetComponent<Transform>();
		_patrolCenter = _transform.position;

		_movement = GetComponent<Enemy_Movement>();

		_navMeshAgent = GetComponent<NavMeshAgent>();

		Debug.Assert(_navMeshAgent != null);

		StartCoroutine(UpdateTarget());
	}

	private IEnumerator UpdateTarget()
	{
		yield return new WaitForSeconds(0.1f);

		if (Vector3.Distance(_targetTransform.position, _transform.position) > _playerFollowMaxDistance || _ignorePlayerTimeDelta > 0)
		{
			if (Time.time > _nextPatrolUpdateTime)
			{
				_targetPosition = Random.insideUnitSphere * _patrolRadius;
				_targetPosition.y = 0;
				_targetPosition += _patrolCenter;

				_nextPatrolUpdateTime = Time.time + _patrolPositionUpdateDeltaTime;
			}
		}
		else
		{
			_targetPosition = _targetTransform.position;
		}

		if (_navMeshAgent.enabled)
		{
			_navMeshAgent.SetDestination(_targetPosition);
		}

		StartCoroutine(UpdateTarget());
	}

	private void Update()
	{
		_ignorePlayerTimeDelta -= Time.deltaTime;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(_ignorePlayerTimeDelta > 0)
		{
			return;
		}

		var otherGO = collision.gameObject;
		var playerHealth = otherGO.GetComponentInParent<PlayerHealth>();

		if(playerHealth != null)
		{
			playerHealth.health--;

			_ignorePlayerTimeDelta = _ignorePlayerTimer;
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;

		Gizmos.DrawWireSphere(transform.position, _patrolRadius);
	}
}
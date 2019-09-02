using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy_Movement : Entity_Movement
{
	public Vector3 TargetPosition { get; internal set; }

	protected override void CalculateInput()
	{
		Jump = false;

		var localTarget = _transform.InverseTransformPoint(TargetPosition);

		localTarget.y = 0;



		Horizontal = Mathf.Atan2(localTarget.z, localTarget.x);

		Vertical = 1;

#if UNITY_EDITOR
		Debug.DrawLine(TargetPosition, _transform.position, Color.green);
#endif
	}



	protected override void Turning()
	{
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player_Movement : Entity_Movement
{
	[SerializeField]
	private LayerMask _floorMask;
	private float _camRayLength = 100f;

	protected override void CalculateInput()
	{
		//Debug.Log("asd");
		if (Jump == false)
		{
			Jump = Input.GetButtonDown("Jump");
		}

		//Debug.Log("OnGroiund");
		Horizontal = Input.GetAxis("Horizontal");
		Vertical = Input.GetAxis("Vertical");
	}

	protected override void Turning()
	{
		if (Speed < 0.1f)
		{
			// Create a ray from the mouse cursor on screen in the direction of the camera.
			Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

			// Create a RaycastHit variable to store information about what was hit by the ray.
			RaycastHit floorHit;

			// Perform the raycast and if it hits something on the floor layer...
			if (Physics.Raycast(camRay, out floorHit, _camRayLength, _floorMask))
			{
#if UNITY_EDITOR
				Debug.DrawLine(floorHit.point, floorHit.point + Vector3.up * 10, Color.red);
#endif
				// Create a vector from the player to the point on the floor the raycast from the mouse hit.
				Vector3 playerToMouse = floorHit.point - transform.position;

				// Ensure the vector is entirely along the floor plane.
				playerToMouse.y = 0f;

				// Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
				Quaternion newRotatation = Quaternion.LookRotation(playerToMouse, Vector3.up);

				// Set the player's rotation to this new rotation.
				_rigidbody.MoveRotation(newRotatation);
			}
		}
		else
		{
			TurnTarget = _transform.position + SpeedVector;
			base.Turning();
		}
	}
}

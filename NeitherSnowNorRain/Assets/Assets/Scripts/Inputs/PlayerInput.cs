using UnityEngine;
using System.Collections;

[RequireComponent (typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
	private PlayerMovement playerMover;
	
	void Start()
	{
		playerMover = GetComponent<PlayerMovement> ();
	}

	void Update()
	{
		if(Input.GetKeyDown(Inputs.RIGHTBUMPER) || Input.GetKeyDown(KeyCode.Space))
		{
			playerMover.Fire();
		}
	}

	void FixedUpdate ()
	{
		Vector2 movement = new Vector2();
		movement.x = Input.GetAxis(Inputs.XAXIS);
		movement.y = Input.GetAxis(Inputs.YAXIS);
		if(movement.magnitude > 1)
		{
			movement.Normalize();
		}
		playerMover.Move (movement);

		Vector2 aim = new Vector2();
		aim.x = Input.GetAxis(Inputs.XRIGHTAXIS);
		aim.y = Input.GetAxis(Inputs.YRIGHTAXIS);

		if(aim.magnitude > 0)
		{
			aim.Normalize();
			playerMover.FireDirection (aim);
		}
	}
}

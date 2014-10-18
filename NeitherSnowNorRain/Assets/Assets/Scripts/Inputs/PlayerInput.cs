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
		if(Input.GetKeyDown(Inputs.RIGHTBUMPER))
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
		playerMover.FireDirection (movement);
	}
}

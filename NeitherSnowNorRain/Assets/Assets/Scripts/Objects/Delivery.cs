using UnityEngine;
using System.Collections;

public class Delivery : MonoBehaviour
{
	public Vector2 Velocity;
	// Update is called once per frame
	void FixedUpdate ()
	{
		transform.position = new Vector3 (transform.position.x + Velocity.x, transform.position.y + Velocity.y, 
		                                  transform.position.z);
	}
}

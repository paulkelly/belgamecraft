using UnityEngine;
using System.Collections;

public class Delivery : MonoBehaviour
{
	private const float SPEED = 12f;
	public Vector2 Velocity;

	// Update is called once per frame
	void FixedUpdate ()
	{
		rigidbody2D.AddTorque(Random.Range (-10f, 10f));
		rigidbody2D.MovePosition(rigidbody2D.position + Velocity * SPEED * Time.deltaTime);
	}
}

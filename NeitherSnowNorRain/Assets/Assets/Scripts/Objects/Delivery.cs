using UnityEngine;
using System.Collections;

public class Delivery : MonoBehaviour
{

	private const float TIMER = 4f;
	private const float SPEED = 12f;
	public Vector2 Velocity = Vector2.up;

	// Update is called once per frame
	void FixedUpdate ()
	{
		rigidbody2D.AddTorque(Random.Range (-10f, 10f));
		rigidbody2D.MovePosition(rigidbody2D.position + Velocity * SPEED * Time.deltaTime);
		StartCoroutine (Cleanup ());
	}

	private float time = 0;
	IEnumerator Cleanup()
	{
		time += Time.deltaTime;
		while(time < TIMER)
		{
			yield return null;
		}
		Destroy (gameObject);
	}
}

using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Player))]
[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
	public GameObject projectile;

	private const float SPEED = 3f;
	private const float X_MULTI = 2f;
	private static Vector2 CONSTANT_VELOCITY = new Vector2(0f, 1.2f);

	private Vector2 Velocity = Vector2.zero;
	private Vector2 AimDirection = Vector2.zero;

	private Player player;

	void Start()
	{
		player = GetComponent<Player> ();
	}

	public void Fire()
	{
		Debug.Log ("Shoot");
		GameObject newProj = (GameObject) Instantiate (projectile, transform.position, Quaternion.identity);
		newProj.GetComponent<Delivery> ().Velocity = AimDirection;
	}

	public void Move(Vector2 value)
	{
		if(player.IsAlive)
		{
			value.x = value.x * X_MULTI;
			Velocity = CONSTANT_VELOCITY + value;
			rigidbody2D.MovePosition(rigidbody2D.position + Velocity * SPEED * Time.deltaTime);
		}
	}

	public void FireDirection(Vector2 value)
	{
		AimDirection = value;
	}
}

using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Player))]
[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
	public GameObject projectile;
	public GameObject ProjtileParent;

	private const float SPEED = 3f;
	private const float X_MULTI = 2f;
	private static Vector2 CONSTANT_VELOCITY = new Vector2(0f, 1.2f);

	private Vector2 Velocity = Vector2.zero;
	private Vector2 AimDirection = Vector2.up;

	private Player player;

	void Start()
	{
		player = GetComponent<Player> ();
	}

	public void Fire()
	{
		GameObject newProj = (GameObject) Instantiate (projectile, transform.position, Quaternion.identity);
		newProj.transform.parent = ProjtileParent.transform;
		newProj.GetComponent<Delivery> ().Velocity = AimDirection;
	}

	public void Move(Vector2 value)
	{
		if(player.IsAlive)
		{
			value.x = value.x * X_MULTI;
			Velocity = (CONSTANT_VELOCITY + value) * SPEED * Time.deltaTime;
			player.Velocity = Velocity;
			rigidbody2D.MovePosition(rigidbody2D.position + Velocity);

			float rotation = (Mathf.Atan2(Velocity.y, Velocity.x) * 180 / Mathf.PI) - 90;
			rigidbody2D.MoveRotation(rotation);
		}
	}

	public void FireDirection(Vector2 value)
	{
		AimDirection = value;
	}
}

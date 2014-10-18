using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	private bool isAlive = true;
	public bool IsAlive
	{
		get
		{
			return isAlive;
		}

		set
		{
			isAlive = value;
		}
	}
	
	public Vector2 Velocity;

	public ParticleSystem[] deathParticles;

	private EnemyCollisionEventHandler EnemyCollisionListener;
	// Use this for initialization
	void Start ()
	{
		EnemyCollisionListener = new EnemyCollisionEventHandler(CollideWithEnemy);
		EventManager.EnemyCollisionEvent += EnemyCollisionListener;
	}

	void OnDestroy()
	{
		EventManager.EnemyCollisionEvent -= EnemyCollisionListener;
	}

	private float torque = 0;
	private void CollideWithEnemy(Enemy enemy, Collision2D collision)
	{
		Debug.Log ("Hit " + enemy.name);
		isAlive = false;
		StartCoroutine (BlowUp (2.6f));
		torque = Random.Range (-0.1f, 0.1f);
	}

	private float time = 0;
	IEnumerator BlowUp(float TIMER)
	{
		while(time < TIMER)
		{
			time += Time.deltaTime;
			rigidbody2D.AddTorque(torque);
			rigidbody2D.MovePosition(rigidbody2D.position + Velocity);
			torque = torque * 0.98f;
			yield return null;
		}

		renderer.enabled = false;
		foreach(ParticleSystem system in deathParticles)
		{
			system.Play();
		}
	}
	
}

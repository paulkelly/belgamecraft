using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider2D))]
public class EnemySpawner : MonoBehaviour
{
	private Bounds spawnerBounds;
	public GameObject EnemyType;

	public Vector2 minVelocity;
	public Vector2 maxVelocity;

	// Use this for initialization
	void Start ()
	{
		spawnerBounds = GetComponent<BoxCollider2D> ().bounds;
		waitTime = Random.Range (minTime, maxTime);
	}
	
	public float minTime;
	public float maxTime;
	private float timer = 0;
	private float waitTime = 0;
	void Update ()
	{
		if(timer < waitTime)
		{
			timer += Time.deltaTime;
		}
		else
		{
			timer = 0;
			waitTime = Random.Range (minTime, maxTime);
			SpawnEnemy();
		}
	}

	public void SpawnEnemy()
	{
		Vector3 pos = transform.position;
		pos.x += Random.Range (-0.5f, 0.5f) * spawnerBounds.size.x;
		pos.y += Random.Range (-0.5f, 0.5f) * spawnerBounds.size.y;
		GameObject enemy = (GameObject) Instantiate (EnemyType, pos, Quaternion.identity);

		Vector2 velocity = new Vector2 ();
		velocity.x = Random.Range (minVelocity.x, maxVelocity.x);
		velocity.y = Random.Range (minVelocity.y, maxVelocity.y);
		enemy.GetComponent<Enemy> ().Velocity = velocity;

	}
}

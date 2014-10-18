using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
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


	private void CollideWithEnemy(Enemy enemy, Collision2D collision)
	{

	}
}

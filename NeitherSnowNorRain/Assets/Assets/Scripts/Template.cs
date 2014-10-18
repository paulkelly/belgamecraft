using UnityEngine;
using System.Collections;

public class Template : MonoBehaviour
{

	private EnemyCollisionEventHandler EventListener;

	void Start ()
	{
		EventListener = new EnemyCollisionEventHandler(HandleEvent);
		EventManager.EnemyCollisionEvent += EventListener;
	}
	
	void OnDestroy()
	{
		EventManager.EnemyCollisionEvent -= EventListener;
	}
	
	
	private void HandleEvent(Enemy enemy, Collider2D collision)
	{

	}

}

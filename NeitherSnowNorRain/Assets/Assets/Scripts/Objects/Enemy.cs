using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour
{

	void OnCollisionEnter2D(Collision2D collision)
	{
		EventManager.SendEnemeyCollisionEvent (this, collision);
	}
}

using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour
{

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player") {
			EventManager.SendEnemeyCollisionEvent (this, collision);
		}

		if(collision.gameObject.tag == "Delivery"){
			EventManager.SendDeliveryEnemyEvent(collision);
		}
	
		Destroy (this.gameObject);
	}
}

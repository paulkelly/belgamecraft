using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour
{
	public Vector2 Velocity;
	public bool isAlive = true;

	void OnCollisionEnter2D(Collision2D collision)
	{

			if (collision.gameObject.tag == "Player")
			{
				if(isAlive)
				{
					EventManager.SendEnemeyCollisionEvent (this, collision);
				}
			}

			if(collision.gameObject.tag == "Delivery")
			{
				EventManager.SendDeliveryEnemyEvent(collision);
				if(isAlive)
				{
					Kill();
				}
				Destroy (collision.gameObject);
			}


		if(collision.gameObject.tag == "Cleanup"){
			CleanUp();
		}
	}

	protected virtual void Kill()
	{
		Destroy (this.gameObject);
	}

	private void CleanUp()
	{
		Destroy (this.gameObject);
	}
}

using UnityEngine;
using System.Collections;

public class Destination : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			EventManager.SendPlayerDestinationEvent ();
		}
		
		if(coll.gameObject.tag == "Delivery"){
			EventManager.SendDeliveryDestinationEvent(this,coll);
		}
		
		Destroy (this.gameObject);
	}
}

using UnityEngine;
using System.Collections;

public class Destination : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			EventManager.SendPlayerDestinationEvent ();
		}
		
		if(coll.gameObject.tag == "Delivery"){
			EventManager.SendDeliveryDestinationEvent(this,coll);

			Destroy (coll.gameObject);
		}
		
		Destroy (this.gameObject);
	}
}

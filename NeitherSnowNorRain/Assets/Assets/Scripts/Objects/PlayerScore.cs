using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	private int score = 0;

	void OnGUI()
	{
		GUI.Box(new Rect(15, 10, 150, 20), "Score: "+score);
	}

	private DeliveryDestinationEventHandler DeliveryListener;
	// Use this for initialization
	void Start ()
	{
		DeliveryListener = new DeliveryDestinationEventHandler(Delivery);
		EventManager.DeliveryDestinationEvent += DeliveryListener;
	}

	void Delivery(Destination destination, Collider2D collision)
	{
		score += 1;
	}
}

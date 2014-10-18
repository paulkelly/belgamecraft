using UnityEngine;
using System.Collections;

public class Asteroid : Enemy {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		rigidbody2D.MovePosition(rigidbody2D.position + Velocity * Time.deltaTime);
	}
}

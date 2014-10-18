using UnityEngine;
using System.Collections;

public class Dog : Enemy
{
	public Animator animator;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(isAlive)
		{
		}
		else
		{
		}
	}

	protected override void Kill()
	{
		Debug.Log ("DogDead");
		animator.SetTrigger ("Dead");
		isAlive = false;
	}
}

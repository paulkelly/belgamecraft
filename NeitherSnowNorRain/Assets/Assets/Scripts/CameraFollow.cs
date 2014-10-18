using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	public Player player;
	private float yOffset = 4f;
	private Vector3 target;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		target = player.transform.position;
		target.x = transform.position.x;
		target.y = target.y + yOffset;
		target.z = transform.position.z;
		transform.position = Vector3.Lerp (transform.position, target, Time.deltaTime);
	}
}

using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	public Player player;
	private float yOffset = 4f;
	private Vector3 target;

	private float shakeAmount = 0;

	private EnemyCollisionEventHandler EnemyCollisionListener;

	// Use this for initialization
	void Start ()
	{
		EnemyCollisionListener = new EnemyCollisionEventHandler(CameraShake);
		EventManager.EnemyCollisionEvent += EnemyCollisionListener;
	}

	void OnDestroy()
	{
		EventManager.EnemyCollisionEvent -= EnemyCollisionListener;
	}

	void CameraShake(Enemy enemy, Collision2D collider)
	{
		shakeAmount = 8;
		StopAllCoroutines ();
		StartCoroutine (StopShake ());
	}

	private float time = 0;
	private float maxTime = 2.6f;
	IEnumerator StopShake()
	{
		while(time < maxTime)
		{
			time += Time.deltaTime;
			yield return null;
		}
		shakeAmount = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		target = player.transform.position;
		target.x = transform.position.x;
		target.y = target.y + yOffset;
		target.z = transform.position.z;
		transform.position = Vector3.Lerp (transform.position, target, Time.deltaTime);
		Vector3 shake = transform.position;
		shake.x += Random.Range (-shakeAmount * Time.deltaTime, shakeAmount * Time.deltaTime);
		shake.y += Random.Range (-shakeAmount * Time.deltaTime, shakeAmount * Time.deltaTime);
		transform.position = shake;
	}
}

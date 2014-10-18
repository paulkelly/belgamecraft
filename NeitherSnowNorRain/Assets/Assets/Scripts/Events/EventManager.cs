using UnityEngine;
using System.Collections;

public delegate void EnemyCollisionEventHandler(Enemy enemy, Collision2D collision);
public delegate void DeliveryDestinationEventHandler(DeliveryDestination destination, Collision2D collision);
public delegate void DeliveryEnemyEventHandler(Collision2D collision);
public delegate void PlayerDestinationEventHandler();

public class EventManager : MonoBehaviour
{
	public static event EnemyCollisionEventHandler EnemyCollisionEvent;
	public static event DeliveryDestinationEventHandler DeliveryDestinatioEvent;
	public static event DeliveryEnemyEventHandler DeliveryEnemyEvent;
	public static event PlayerDestinationEventHandler PlayerDestinationEvent;

	private static EventManager _instance;
	public static EventManager Instance
	{
		get
		{
			return _instance;
		}
	}

	void Awake()
	{
		_instance = this;
		EnemyCollisionEvent += new EnemyCollisionEventHandler(EnemyCollisionEventMethod);
		DeliveryDestinatioEvent += new DeliveryDestinationEventHandler(DeliveryDestinationEventMethod);
		DeliveryEnemyEvent += new DeliveryEnemyEventHandler(PlayerDestinationEventMethod);
		PlayerDestinationEvent += new PlayerDestinationEventHandler(EmptyMethod);
	}

	void EmptyMethod()
	{
	}

	void EnemyCollisionEventMethod(Enemy enemy, Collision2D collision)
	{
	}

	void DeliveryDestinationEventMethod(DeliveryDestination destination, Collision2D collision)
	{
	}

	void PlayerDestinationEventMethod(Collision2D collision)
	{
	}
}

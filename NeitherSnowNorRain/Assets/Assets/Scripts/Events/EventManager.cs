using UnityEngine;
using System.Collections;

public delegate void EnemyCollisionEventHandler(Enemy enemy, Collision2D collision);
public delegate void DeliveryDestinationEventHandler(Destination destination, Collision2D collision);
public delegate void DeliveryEnemyEventHandler(Collision2D collision);
public delegate void PlayerDestinationEventHandler();

public class EventManager : MonoBehaviour
{
	public static event EnemyCollisionEventHandler EnemyCollisionEvent;
	public static event DeliveryDestinationEventHandler DeliveryDestinationEvent;
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
		DeliveryDestinationEvent += new DeliveryDestinationEventHandler(DeliveryDestinationEventMethod);
		DeliveryEnemyEvent += new DeliveryEnemyEventHandler(PlayerDestinationEventMethod);
		PlayerDestinationEvent += new PlayerDestinationEventHandler(EmptyMethod);
	}

	public static void SendEnemeyCollisionEvent(Enemy enemy, Collision2D collision)
	{
		EnemyCollisionEvent.Invoke (enemy, collision);
	}

	public static void SendDeliveryDestinationEvent(Destination destination, Collision2D collision)
	{
		DeliveryDestinationEvent.Invoke (destination, collision);
	}

	public static void SendDeliveryEnemyEvent(Collision2D collision)
	{
		DeliveryEnemyEvent.Invoke (collision);
	}

	public static void SendPlayerDestinationEvent()
	{
		PlayerDestinationEvent.Invoke ();
	}

	void EmptyMethod()
	{
	}

	void EnemyCollisionEventMethod(Enemy enemy, Collision2D collision)
	{
	}

	void DeliveryDestinationEventMethod(Destination destination, Collision2D collision)
	{
	}

	void PlayerDestinationEventMethod(Collision2D collision)
	{
	}
}

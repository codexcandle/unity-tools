using UnityEngine;
using System.Collections;

public class NavMeshEnemySeeking:MonoBehaviour
{
	Transform player;
	UnityEngine.AI.NavMeshAgent nav;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

	void Update()
	{
		nav.SetDestination(player.position);

		// if player dies...
		// nav.enabled = false;
	}
}
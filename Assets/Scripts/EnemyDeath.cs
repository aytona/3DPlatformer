using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			gameObject.SendMessageUpwards("OnDeath");
		}
	}
}

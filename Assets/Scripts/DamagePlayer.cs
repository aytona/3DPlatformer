using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {

	public delegate void DamagePlayerAction(GameObject player);
	public static event DamagePlayerAction OnDamagePlayer;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (OnDamagePlayer != null)
			{
				OnDamagePlayer(other.gameObject);
			}
		}
	}
}

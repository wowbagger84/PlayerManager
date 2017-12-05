using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public float health = 100;

	//TODO: check who did the damage?
	public void TakeDamage(float amount) {
		health -= amount;
		if (health <= 0)
		{
			transform.parent.GetComponent<Player>().RemovePlayer();
		}
	}
}

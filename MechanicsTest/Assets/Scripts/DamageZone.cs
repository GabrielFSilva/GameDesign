using UnityEngine;
using System.Collections;

public class DamageZone : MonoBehaviour 
{
	public Player	player;

	void OnTriggerEnter2D(Collider2D p_coll) 
	{
		if (p_coll.tag == "Enemy")
			player.DecreaseLife ();
	}
}

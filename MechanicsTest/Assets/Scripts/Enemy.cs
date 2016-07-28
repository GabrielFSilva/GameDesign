using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour 
{
	public event Action<Enemy> OnEnemyDie;
	public ColorInfo.ColorType	color;

	public Rigidbody2D		rigidBody;
	public int	life = 2;
	public float speed = 1.0f;

	void Update () 
	{
		rigidBody.velocity = Vector2.down * speed;
	}

	void OnTriggerEnter2D(Collider2D p_coll) 
	{
		if (p_coll.tag == "Shoot") 
		{
			Shoot __shoot = p_coll.GetComponent<Shoot> ();
			if (__shoot.color == color) 
			{
				life--;
				if (life <= 0)
					OnEnemyDie(this);
			}
		}
		else  if (p_coll.tag == "Player" || p_coll.tag == "DamageZone")
			OnEnemyDie(this);
	}
}

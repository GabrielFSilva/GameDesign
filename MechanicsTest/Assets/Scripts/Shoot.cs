using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour 
{
	public ColorInfo.ColorType 	color;
	public SpriteRenderer		sprite;

	public Vector3 				direction;
	public float 				speed;

	void Start () 
	{
		sprite.color = ColorInfo.ColorTypeToColor (color);
	}

	void Update () 
	{
		transform.Translate (Vector2.up * Time.deltaTime * speed);
		if (Vector2.Distance (transform.position, Vector2.zero) > 6f)
			Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D p_coll) 
	{
		if (p_coll.tag == "Enemy") 
			Destroy (gameObject);
	}
}

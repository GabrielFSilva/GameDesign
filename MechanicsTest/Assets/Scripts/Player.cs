using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
	public UIManager				uiManager;
	public GameObject				shootPrefab;
	public ColorInfo.ColorType 		color;
	public SpriteRenderer			sprite;

	public Rigidbody2D 				rigidBody;
	public float 					speed;
	public int 						life;
	//Shoot Control 
	private float shootCooldownCount;
	public float shootCooldown = 0.25f;

    public Vector3 rotateRight;
    public Vector3 rotateLeft;

    private Vector3 playerRotation;

    void Start () 
	{
		//Change player color
		sprite.color = ColorInfo.ColorTypeToColor (color);
		shootCooldownCount = shootCooldown;
	}

	void Update () 
	{
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(rotateRight);
            playerRotation = rotateRight;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            playerRotation = rotateLeft;
            transform.Rotate(rotateLeft);
        }

        shootCooldownCount += Time.deltaTime;
		//Shoot control
		if (Input.GetMouseButton (0) && shootCooldownCount >= shootCooldown) 
		{
			GameObject __go = (GameObject)GameObject.Instantiate (shootPrefab, 
				transform.position, transform.rotation);
			Shoot __shoot = __go.GetComponent<Shoot> ();
			__shoot.color = color;
			shootCooldownCount = 0f;
		}

        if (Input.GetKey(KeyCode.Q))
	    {
	        transform.Rotate(rotateRight);
	    }
	    else if (Input.GetKey(KeyCode.E))
	    {
            transform.Rotate(rotateLeft);
        }

        //Change Color on Right-Button Press
        if (Input.GetMouseButtonDown (1)) 
		{
			color = ColorInfo.GetNextColor (color);
			sprite.color = ColorInfo.ColorTypeToColor (color);
		}

		//Calc Movement
		Vector2 __dir = Vector2.zero;
		//X axis
		if (Input.GetKey (KeyCode.A))
			__dir.x = -1f;
		else if (Input.GetKey (KeyCode.D))
			__dir.x = 1f;
		//Y axis
		if (Input.GetKey (KeyCode.W))
			__dir.y = 1f;
		else if (Input.GetKey (KeyCode.S))
			__dir.y = -1f;
		
		//Normalize Speed
		//rigidBody.velocity = __dir * speed;
		rigidBody.velocity =  __dir.normalized * speed;

		//Clamp Position
		transform.position = new Vector2 (Mathf.Clamp (transform.position.x, -3f, 3f),
			Mathf.Clamp (transform.position.y, -2.5f, -0.5f));
	}

	void OnTriggerEnter2D(Collider2D p_coll) 
	{
		if (p_coll.tag == "Enemy")
			DecreaseLife ();
	}

	public void DecreaseLife()
	{
		life--;
		uiManager.UpdateLabels ();
		if (life <= 0)
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}

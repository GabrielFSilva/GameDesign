using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyFactory : MonoBehaviour 
{
	public UIManager			uiManager;
	public List<GameObject>		enemies;

	private float	spawnTimeCount;
	public float	spawnCooldown;

	public int deadCount = 0;

	void Start () 
	{
		spawnTimeCount = 0f;
	}

	void Update () 
	{
		spawnTimeCount += Time.deltaTime;
		if (spawnTimeCount >= spawnCooldown)
			SpawnEnemy ();
	}

	private void SpawnEnemy()
	{
		spawnTimeCount -= spawnCooldown;

		Vector2 __pos = new Vector2 (Random.Range (-3f, 3f), 3.5f);
		GameObject __go = (GameObject)GameObject.Instantiate (enemies[Random.Range(0, enemies.Count)], 
			__pos, Quaternion.identity);
		__go.transform.parent = transform;

		__go.GetComponent<Enemy>().OnEnemyDie += KillEnemy;
	}

	void KillEnemy (Enemy p_enemy)
	{
		Destroy (p_enemy.gameObject);
		deadCount++;
		uiManager.UpdateLabels ();
	}
}

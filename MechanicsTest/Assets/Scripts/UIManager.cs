using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour 
{
	public Text enemiesLabel;
	public Text playerLifeLabel;

	public Player player;
	public EnemyFactory	enemyFactory;

	void Start()
	{
		UpdateLabels ();
	}

	public void UpdateLabels()
	{
		playerLifeLabel.text = "Life: " + player.life.ToString ();
		enemiesLabel.text = "Enemies: " + enemyFactory.deadCount.ToString ();
	}
}

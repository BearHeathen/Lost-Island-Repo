using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour 
{
	//player elements 
	public int startingLives = 3;
	public int currentLives = 0;
	PlayerHealth playerHealth;

	// Use this for initialization
	void Awake () 
	{
		currentLives = startingLives;

	}
	// Update is called once per frame
	void Update () 
	{

		if (currentLives <= 0) 
		{
			GameOver ();
		}
	}


	private void GameOver() 
	{

		Debug.Log("Game Over");
	}
}

using UnityEngine;
using System.Collections;

public class PlayerLives : MonoBehaviour {

	//Lives Bar elements 
	public GUIText LivesBar;

	//player elements 
	public GUIText Player;
	public int PLives = 3;
	public int CurrentPLives;

	// Use this for initialization
	void Start () {
		CurrentPLives = PLives;
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void PlayerMinusLivesCount (int Lives)
	{
		CurrentPLives -= 1;

		if(CurrentPLives == 0)
		{
			//will end the game and display a message to the player stating that they have Lost The Game

		} else{
		LivesBar.text = "Lives" + CurrentPLives;
		}
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

public class GameOver : MonoBehaviour 
{

	public AudioClip gameOverClip;
	public Transform player;
	AudioSource playerAudio;
	Image gameOver;
	public Image gameOverBackground;
	public Color color = new Color(1f,0f,0f,1f);
	private bool finished = false;
	public Button playAgain;
	public Button exitGame;



	void Awake () 
	{
		gameOver = GetComponent<Image>();
		gameOverBackground = GetComponent<Image>();
		player = GetComponent<Transform>();
		playerAudio = GetComponent<AudioSource>();
		playAgain = GetComponent<Button>();
		exitGame = GetComponent<Button>();

		gameOver.enabled = false;
		playAgain.interactable = false;
		playAgain.gameObject.SetActive(false);
		exitGame.enabled = false;
		Time.timeScale = 1;

	}


	void Update () 
	{
		if (LivesManager.lives <= 0 && finished == false) 
		{
			finished = true;
			PlayGameOverAudio();
			gameOver.enabled = true;
			playAgain.enabled = true;
			exitGame.enabled = true;
			HaltOperations ();

		}
	}

	void PlayGameOverAudio()
	{
		if (finished) 
		{
			playerAudio.clip = gameOverClip;
			playerAudio.Play ();
        }
    }

	void HaltOperations()
	{
		Time.timeScale = 0;
		//Application.LoadLevel(1);
	}



	public void RestartGame(int scene)
	{
		Application.LoadLevel(scene);
	}
    
}
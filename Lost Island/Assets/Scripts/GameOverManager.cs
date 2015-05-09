using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour 
{

	public PlayerHealth playerHealth;
	public float restartDelay = 5f;

	Animator anim;
	float restartTimer;

	void Awake () 
	{
		anim = GetComponent<Animator>();
	}
	

	void Update () 
	{
		if (LivesManager.lives <= 0) 
		{

			anim.SetTrigger("GameOver");

			restartTimer += Time.deltaTime;


			if (restartTimer >= restartDelay) 
			{
				Application.LoadLevel("GameOverScene");
				LivesManager.lives = 3;
			}

		}
	}
}

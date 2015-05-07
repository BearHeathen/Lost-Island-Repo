using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesManager : MonoBehaviour 
{
	public static int lives;
	Text text;


	void Awake () 
	{
		text = GetComponent<Text>();
		lives = 3;

	}
	

	void Update () 
	{
		text.text = "Lives: " + lives;

	}
}

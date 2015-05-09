using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesManager : MonoBehaviour 
{
	public static int lives = 3;
	Text text;


	void Awake () 
	{
		text = GetComponent<Text>();


	}
	

	void Update () 
	{
		text.text = "Lives: " + lives;

	}
}

using UnityEngine;
using System.Collections;

public class OnLavaEnter : MonoBehaviour {
	private GameObject LavaBox;
	PlayerHealth playerHealth;
	Transform Player;
	public Transform Destination;
	
	// Use this for initialization
	void Start () {
		
	}
	
	void Awake () 
	{
		Player = GameObject.FindGameObjectWithTag("Player").transform;
		playerHealth = Player.GetComponent <PlayerHealth> ();
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			LavaBox = GameObject.Find("LavaBox");
			KIllPlayer();
		}
	}
	
	void KIllPlayer()
	{
		Player.transform.position = Destination.position;
		if (playerHealth.currentHealth < 100) {
			playerHealth.currentHealth = playerHealth.startingHealth;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}

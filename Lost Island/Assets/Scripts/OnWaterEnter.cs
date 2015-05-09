using UnityEngine;
using System.Collections;

public class OnWaterEnter : MonoBehaviour {

	private GameObject WaterBox;
	public Transform Player;
	public Transform Destination;
	PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
	
	}

	void Awake () {
		playerHealth = Player.GetComponent<PlayerHealth>();
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") 
		{
			WaterBox = GameObject.FindGameObjectWithTag("WaterBox");
			playerHealth.currentHealth = 0;
			
			//playerHealth.ApplyDamagePlayer(0f);
		}
	}

}

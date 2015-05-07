using UnityEngine;
using System.Collections;

public class OnWaterEnter : MonoBehaviour {

	private GameObject Water;
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
		if (other.tag == "Player") {
			Water = GameObject.Find("Water");
			KillPlayer();
			playerHealth.RestoreHealth();
			playerHealth.ApplyDamagePlayer(0f);
		}
	}

	void KillPlayer()
	{
		Player.transform.position = Destination.position;

	}
	
	// Update is called once per frame
	void Update () {
	}
}

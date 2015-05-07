using UnityEngine;
using System.Collections;

public class OnLavaEnter : MonoBehaviour {

	private GameObject LavaBox;
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
			LavaBox = GameObject.Find("LavaBox");
			KIllPlayer();
			playerHealth.RestoreHealth();
			playerHealth.ApplyDamagePlayer(0f);
		}
	}
	
	void KIllPlayer()
	{
		Player.transform.position = Destination.position;
	}
	
	// Update is called once per frame
	void Update () {
	}
}

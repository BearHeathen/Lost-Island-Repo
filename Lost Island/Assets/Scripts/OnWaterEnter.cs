using UnityEngine;
using System.Collections;

public class OnWaterEnter : MonoBehaviour {

	private GameObject Water;
	public Transform Player;
	public Transform Destination;

	// Use this for initialization
	void Start () {
	
	}

	//void Awake () {}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			Water = GameObject.Find("Water");
			KIllPlayer();
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

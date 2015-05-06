using UnityEngine;
using System.Collections;

public class OnLavaEnter : MonoBehaviour {
	private GameObject LavaBox;
	public Transform Player;
	public Transform Destination;
	
	// Use this for initialization
	void Start () {
		
	}
	
	//void Awake () {}
	
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
	}
	
	// Update is called once per frame
	void Update () {

	}
}

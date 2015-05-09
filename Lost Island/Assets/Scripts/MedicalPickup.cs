using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MedicalPickup : MonoBehaviour 
{
	public Slider healthSlider;
	PlayerHealth playerHealth;
	GameObject player;
	int healthRestore = 33;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
	}

	void OnTriggerEnter(Collider other)
	{

			playerHealth.currentHealth += healthRestore;
		     healthSlider.value += healthRestore;
			Destroy(gameObject);


	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour 
{
	//Health Bar UI Elements
	public Slider healthSlider;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColor = new Color(1f,0f,0f,0.1f);
	int livesValue = 1;




	//Player Elements
	public float startingHealth = 100f;
	public float currentHealth;
	public GameObject playerRespawn;
	public Transform player;
	bool damaged;
	bool isDead;

	//Enemy Elements
	GameObject enemy;
	EnemyHealth enemyHealth;


	void Awake()
	{
		currentHealth = startingHealth;
		player.GetComponent<Transform>();
		enemy = GameObject.FindGameObjectWithTag("Enemy");
		enemyHealth = GetComponent<EnemyHealth>();
		playerRespawn = GameObject.FindGameObjectWithTag("Respawn");

	}
	
	private void Update()
	{


		if (damaged) 
		{
			damageImage.color = flashColor;
		}
		else 
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime );
		}
		damaged = false;
	}
	
	public void ApplyDamagePlayer(float damage)
	{
		damaged = true;
		currentHealth -= damage;
		healthSlider.value = currentHealth;

		if (currentHealth <= 0f && !isDead) 
		{
			Dead ();
		}
	}
	
	public void Dead()
	{

		isDead = true;

		Respawn();
	}

	public void Respawn()
	{

		player.transform.position = playerRespawn.transform.position;
		healthSlider.value = startingHealth;
		currentHealth = startingHealth;
		LivesManager.lives -= 1;
		enemy.GetComponent<EnemyHealth>().currentHealth = enemy.GetComponent<EnemyHealth>().startingHealth;
	}
}

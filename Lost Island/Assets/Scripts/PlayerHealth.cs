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
	public Text livesBar;



	//Player Elements
	public float startingHealth = 100f;
	public float currentHealth;
	public Transform playerRespawn;
	public Transform player;
	bool damaged;
	bool isDead;
	PlayerLives playerLives;
	//OnLavaEnter respawner;

	void Awake()
	{
		currentHealth = startingHealth;
		player.GetComponent<Transform>();
		livesBar = gameObject.GetComponent<Text>();
	}
	
	private void Update()
	{
		livesBar.text = "Lives: ";

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
		//Filler, will replace with respawn if lives >= 1 or will show Game Over otherwise.\
		Respawn();
		playerLives.currentLives -= 1; 
		//Destroy(gameObject);


	}

	public void Respawn()
	{
		player.transform.position = playerRespawn.transform.position;
		currentHealth = startingHealth;

	}
}

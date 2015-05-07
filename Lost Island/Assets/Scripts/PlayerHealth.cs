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

	//Player Elements
	public float startingHealth = 100f;
	public float currentHealth;
	bool damaged;
	bool isDead;

	void Awake()
	{
		currentHealth = startingHealth;
	}
	
	private void Update()
	{
//		if (health <= 0f) 
//		{
//			Dead();
//		}

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
		//Filler, will replace with respawn if lives >= 1 or will show Game Over otherwise.
		Destroy(gameObject);
	}

	public void RestoreHealth()
	{
		currentHealth = startingHealth;
	}
}

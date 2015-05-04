using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour 
{
	//UI Elements
	public Slider healthSlider;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColor = new Color(1f,0f,0f,0.1f);

	//Player Elements
	public int startingHealth = 100;
	public int currentHealth;
	bool damaged;
	bool isDead;

	void Awake()
	{
		currentHealth = startingHealth;
	}
	
	private void Update()
	{
//		if (health <= 0) 
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
	
	public void ApplyDamagePlayer(int damage)
	{
		damaged = true;
		currentHealth -= damage;
		healthSlider.value = currentHealth;

		if (currentHealth <= 0 && !isDead) 
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
}

using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour 
{
	public int currentHealth;
	public int startingHealth = 30;
	public AudioClip deathClip;
	public AudioClip hurtClip;


	CapsuleCollider capsuleCollider;
	Animator anim;
	AudioSource enemyAudio;


	void Awake()
	{
		currentHealth = startingHealth;
		capsuleCollider = GetComponent<CapsuleCollider>();
		anim = GetComponent<Animator>();
		enemyAudio = GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (currentHealth <= 0) 
		{
			Dead();
		}
	}

	private void ApplyDamage(int damage)
	{
		currentHealth -= damage;
		enemyAudio.clip = hurtClip;
		enemyAudio.Play();
		if (currentHealth <= 0)
		{
			Dead ();
		}
	}

	private void Dead()
	{
		anim.SetTrigger("Dead");
		enemyAudio.clip = deathClip;
		enemyAudio.Play();
		Destroy(gameObject, 2f);
	}
}

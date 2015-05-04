using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	public float timeBetweenAttacks = 5000f;
	public int attackDamage = 10;

	Animator anim;
	GameObject player;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	bool playerInRange;
	float timer;

	// Use this for initialization
	void Awake () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		enemyHealth = GetComponent<EnemyHealth>();
		anim = GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player) 
		{
			playerInRange = true;	
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == player) 
		{
			playerInRange = false;	
		}
	}

	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;

		if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0) 
		{
			Attack();
			anim.SetTrigger("PlayerInRange");

		}

		if (playerHealth.currentHealth <= 0) 
		{
			playerHealth.Dead();
		}
	}

	void Attack()
	{
		timer = 0f;

		if (playerHealth.currentHealth > 0)
		{
			playerHealth.ApplyDamagePlayer(attackDamage);

		}
	}
}

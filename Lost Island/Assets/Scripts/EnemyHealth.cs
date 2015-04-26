using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour 
{
	public int health = 30;

	private void Update()
	{
		if (health <= 0) 
		{
			Dead();
		}
	}

	private void ApplyDamage(int damage)
	{
		health -= damage;
	}

	private void Dead()
	{
		Destroy(gameObject);
	}
}

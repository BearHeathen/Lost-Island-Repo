using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour 
{
	Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;
	public float aggroRange = 10f;
	float distance;
	Animator anim;





	// Use this for initialization
	void Awake () 
	{
	    //Set up references
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		distance = Vector3.Distance(transform.position, player.position);
		//
		Debug.Log(distance);
		if (distance <= aggroRange && enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0f) 
		{
			anim.SetTrigger("PlayerInRange");
			nav.SetDestination(player.position);
			nav.Resume();
		}
	
		else if(distance > aggroRange)
		{
			anim.SetTrigger("PlayerOutRange");
			nav.Stop();

		}
		else 
		{
			nav.enabled = false;
		}
	}
}

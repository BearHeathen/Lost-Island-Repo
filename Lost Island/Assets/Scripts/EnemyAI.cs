using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
	float distance;
	public Transform target;
	public int damage = 5;
	public float lookAtDistance = 25.0f;
	public float attackRange = 15.0f;
	public float moveSpeed = 5.0f;
	float damping = 6.0f;
	float hitDistance = 3.0f;
	GameObject[] enemy;
	Renderer rend;

	private void Start()
	{

	}
	private void Update()
	{

		enemy = GameObject.FindGameObjectsWithTag("Enemy");
		
		foreach (GameObject gameObj in enemy) 
		{
			rend = gameObj.GetComponent<Renderer>();
			distance = Vector3.Distance(target.position, transform.position);

			if (distance < lookAtDistance) 
			{
				rend.material.color = Color.yellow;
				LookAt();
			}
			
			if (distance > lookAtDistance) 
			{
				rend.material.color = Color.green;
			}
			
			if (distance < attackRange) 
			{
				rend.material.color = Color.red;
				EnemyAttack();
			}

			if (distance < hitDistance) 
			{
				RaycastHit hit;
				
				if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit)) 
				{
					float rayDistance = hit.distance;
					float maxDistance = 1.5f;
					if (rayDistance < maxDistance) 
					{

						hit.transform.SendMessage(("ApplyDamagePlayer"), damage, SendMessageOptions.DontRequireReceiver);
					}

					
				}
			}
		}

	}

	private void LookAt()
	{
		Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
	}

	private void EnemyAttack()
	{
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
	}
}

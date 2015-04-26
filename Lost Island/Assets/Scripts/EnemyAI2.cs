using UnityEngine;
using System.Collections;

public class EnemyAI2 : MonoBehaviour 
{
	float distance;

	public Transform target;
	public int damage = 5;
	public float lookAtDistance = 25.0f;
	public float attackRange = 2.0f;
	public float chaseRange = 15.0f;
	public float moveSpeed = 5.0f;
	public float gravity = 20f;
	private Vector3 moveDirection = Vector3.zero;
	public CharacterController controller;
	public float damping = 6.0f;
	public int attackRepeatTime = 1;
	private float attackTime;
	GameObject[] enemy;
	Renderer rend;

	
	private void Start()
	{
		attackTime = Time.time;
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

				LookAt();
			}
			
			if (distance > lookAtDistance) 
			{
				rend.material.color = Color.green;
			}

			if (distance <= attackRange) 
			{
				Debug.Log ("Calling Attack");
				float noTiltZ = transform.rotation.x;
				noTiltZ = 0f;
				Attack ();
			}
			
			else if (distance < chaseRange) 
			{
				Debug.Log("Calling Chase");
				float noTiltZ = transform.rotation.x;
				noTiltZ = 0f;
				Chase();
			}
			

		}
		
	}
	
	private void LookAt()
	{
		rend.material.color = Color.yellow;
		Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
	}
	
	private void Chase()
	{
		rend.material.color = Color.red;

		moveDirection = transform.forward;
		moveDirection *= moveSpeed;

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

	private void Attack()
	{
		if (Time.time > attackTime) 
		{
			target.SendMessage("ApplyDamagePlayer", damage);
			Debug.Log ("The enemy has attacked.");
			attackTime = Time.time + attackRepeatTime;
		}

	}

	private void Enrage()
	{
		chaseRange += 30;
		moveSpeed += 2;
		lookAtDistance += 40;
	}

}

using UnityEngine;
using System.Collections;

public class MeleeSystem : MonoBehaviour 
{

	public float damage = 5f;
	public float distance;
	public float maxDistance = 1.5f;

	Animation anim;

	private void Start()
	{
		anim = GetComponent<Animation>();
	}

	private void Update()
	{
		if (Input.GetButtonDown("Fire1")) 
		{

			anim.Play("DagAttack");

		}
	}

	private void AttackDamage()
	{
		RaycastHit hit;
		
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit)) 
		{
			distance = hit.distance;
			if (distance < maxDistance ) 
			{
				hit.transform.SendMessage(("ApplyDamage"), damage, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}


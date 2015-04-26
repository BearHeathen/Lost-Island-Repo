using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour 
{
	public Transform effect;
	public int damage = 10;



	// Update is called once per frame
	void Update () 
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0));

		if (Input.GetMouseButtonDown(0)) 
		{
			if (Physics.Raycast(ray, out hit, 100)) 
			{
				Transform particleClone = Instantiate(effect, hit.point, Quaternion.LookRotation(hit.normal)) as Transform;
				Destroy (particleClone.gameObject, 1.75f);
				hit.transform.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);

			}
		}
	}
}

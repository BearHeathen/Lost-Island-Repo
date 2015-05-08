using UnityEngine;
using System.Collections;

public class WeaponSwitching : MonoBehaviour {

	public GameObject weapon1;
	public GameObject weapon2;


	void Awake()
	{
		weapon1.SetActive(false);
	}
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Q)) 
		{
			SwapWeapons();
		}
	}

	private void SwapWeapons()
	{
		if (weapon1.activeSelf == true) 
		{
			weapon1.SetActiveRecursively(false);
			weapon2.SetActiveRecursively(true);
		}
		else
		{
			weapon1.SetActiveRecursively(true);
			weapon2.SetActiveRecursively(false);
		}
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VolcanoTriggerSound : MonoBehaviour
{
    private AudioSource rumble;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered volcano sound trigger");
        if (other.tag == "VolcanoSound") 
	    {
		    rumble.Play();
	    }
      
    }

}
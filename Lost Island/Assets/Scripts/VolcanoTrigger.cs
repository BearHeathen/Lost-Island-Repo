using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VolcanoTrigger : MonoBehaviour 
{
    private float fadeSpeed;
    private Color fadeColor = new Color(25.5f, 0f, 0f, .2f);
    public Image volcanoImage;
    public AudioSource volcanoRumble;

   
	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "VolcanoZone")
        {
            Debug.Log("Entered trigger");
            fadeSpeed += Time.deltaTime;

            volcanoImage.color = Color.clear;
            //volcanoImage.CrossFadeAlpha(45f, .5f, false);
            volcanoImage.color = Color.Lerp(volcanoImage.color, fadeColor, (Time.deltaTime * 20));
            //volcanoImage.CrossFadeAlpha(45f, 10f, true);
            volcanoRumble.GetComponent<AudioSource>().loop = false;
            volcanoRumble.GetComponent<AudioSource>().pitch = 1;

            
            
            volcanoRumble.Play();
        }
    }

        void OnTriggerExit(Collider other)
        {
            volcanoImage.color = Color.clear;
            volcanoRumble.Stop();
        }
        
       
     


     
	
}

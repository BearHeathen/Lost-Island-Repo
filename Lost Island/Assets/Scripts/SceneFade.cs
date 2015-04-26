using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour 
{

    public Texture2D fadeOutTexture;  //Will overlay screen (will be white)
    public float startTime;
    private float alpha = 1.0f;

    void OnLevelWasLoaded()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time - startTime >= 3.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnGUI()
    {
        //alpha += startTime * Time.deltaTime;
        //alpha = Mathf.Clamp01(alpha);
        GUI.color = Color.white;
        GUI.color = new Color() { a = Mathf.Lerp(1.0f, 0.0f, (Time.time - startTime)) };
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture); //draw texture to fit whole screen

    }

   
    
	
}

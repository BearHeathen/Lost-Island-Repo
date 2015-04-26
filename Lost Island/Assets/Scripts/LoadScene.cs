using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour 
{

    public void LoadToScene(int level)
    {
        Application.LoadLevel(level);
    }
	
}

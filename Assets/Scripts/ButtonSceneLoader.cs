using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneLoader : MonoBehaviour
{
    public void OnClick(int sceneToLoad) 
    {
        // Debug.Log($"Load scene #{sceneToLoad}");
        SceneManager.LoadScene(sceneToLoad);
    }

    public void OnClickNoParam() 
    {
        SceneManager.LoadScene(GetComponent<SceneNumberScript>().GetSceneNumber());
    }
}

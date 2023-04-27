using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNumberScript : MonoBehaviour
{
    private static int sceneNumber;

    public void SetSceneNumber() => sceneNumber = SceneManager.GetActiveScene().buildIndex;
    public int GetSceneNumber() => sceneNumber;
    
}

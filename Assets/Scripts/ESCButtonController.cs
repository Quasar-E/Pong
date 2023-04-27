using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ESCButtonController : MonoBehaviour
{
    [SerializeField] InputAction EscAction;

    private void OnEnable() 
    {
        EscAction.Enable();
        EscAction.performed += ctx => SceneManager.LoadScene(0);
    }

    private void OnDisable() 
    {
        EscAction.Disable();
    }
}

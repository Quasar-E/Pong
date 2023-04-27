using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] float speed = 5f;
    [SerializeField] bool isAI = false;
    private GameObject ball;

    private void OnEnable() 
    {
        movement.Enable();    
    }

    private void OnDisable() 
    {
        movement.Disable();
    }

    private void Start() 
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    void FixedUpdate()
    {
        float mov = 0;

        if (isAI) 
        {
            float diff = ball.transform.position.y - transform.position.y;

            if (Mathf.Abs(diff) >= GetComponent<Collider2D>().bounds.size.y / 4)
                mov = Mathf.Abs(diff) / diff;
        }
            
        else
            mov = movement.ReadValue<float>();

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, mov * speed);
    }
}

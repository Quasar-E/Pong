using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    float speed;
    int hitCounter = 0;

    int playerRScore = 0, playerLScore = 0;

    [SerializeField] TMP_Text playerRScoreText, playerLScoreText;
    [SerializeField] float startSpeed = 1f, speedIncreaseByHit = .5f;
    [SerializeField] int maxHit = 10, maxScore = 10;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartBallMovement(new Vector2(1, 0));
    }

    // Set the ball at the posiion of Vector pos and start movement afetr 2 sec
    private void StartBallMovement(Vector2 pos) 
    {
        transform.position = pos;
        StartCoroutine(MovementCoroutine());
    }
    // Coroutine for prev func
    private IEnumerator MovementCoroutine() 
    {
        yield return new WaitForSeconds(2f);
        ChangeDirection(new Vector2(transform.position.x < 0 ? -1 : 1, 0));
    }

    // Changes ball direction and speed
    private void ChangeDirection(Vector2 newDirV2D) 
    {
        newDirV2D = newDirV2D.normalized;
        float speed = startSpeed + speedIncreaseByHit * hitCounter;

        rb.velocity = newDirV2D * speed;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag != "Racket" && other.gameObject.tag != "DeathWall")
            return;

        // Debug.Log($"Collision! {other.transform.InverseTransformPoint(other.GetContact(0).point).y}");

        if (other.gameObject.tag == "Racket") 
        {
            // get +-1
            float newVectorX = rb.velocity.x / Mathf.Abs(rb.velocity.x);

            // object length is 1, from -.5 to .5
            // multiply by 2 to get 1 & -1
            float newVectorY = other.transform.InverseTransformPoint(other.GetContact(0).point).y * 2;

            ChangeDirection(new Vector2(newVectorX, newVectorY));

            // increase ball speed
            if (hitCounter < maxHit)
                hitCounter++;
        }



        if (other.gameObject.tag == "DeathWall") 
        {
            // Stop the ball
            rb.velocity = new Vector2(0, 0);

            // left wall
            if (transform.position.x < 0) 
            {
                // Debug.Log("Death left");
                StartBallMovement(new Vector2(-1, 0));
                playerRScore++;
                playerRScoreText.text = playerRScore.ToString();
            }
            
            // right wall
            if (transform.position.x > 0) 
            {
                // Debug.Log("Death right");
                StartBallMovement(new Vector2(1, 0));
                playerLScore++;
                playerLScoreText.text = playerLScore.ToString();
            }

            CheckWinner();
            hitCounter = 0;
        }

        // Debug.Log(hitCounter);
    }

    private void CheckWinner() 
    {
        if (playerLScore == maxScore || playerRScore == maxScore) 
        {
            SceneManager.LoadScene(3);
            GetComponent<SceneNumberScript>().SetSceneNumber();
        }
    }
}

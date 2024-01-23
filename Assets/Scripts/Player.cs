using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public float jumpForce;
    public Rigidbody rb;

    public int score;
    public Text ScoreText;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            thisAnimation.Play();
        }
        if(transform.position.y >= 3.59)
        {
            transform.position = new Vector3(transform.position.x, 3.59f, transform.position.z);
        }
        else if (transform.position.y <= -4.41)
        {
            SceneManager.LoadScene("GameLose");
        }

        if (score >= 100)
        {
            SceneManager.LoadScene("GameWin");
        }
            
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameLose");
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PassObstacle"))
        {
            score+=10;
            ScoreText.GetComponent<Text>().text = "SCORE : " + score;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed = 1500f;
	public Rigidbody Rb;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;

	// Use this for initialization
	void Start () {

	}
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKey("d"))
        {
            Rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            Rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("w"))
        {
            Rb.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            Rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
        if (health == 0)
        {
            Debug.Log("Game Over!");
            health = 5;
            SceneManager.LoadScene(0);
        }
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score++;
            //Debug.Log("score:" + score);
            SetScoreText();
        }
        if (other.gameObject.CompareTag("Trap"))
        {
            health--;
            //Debug.Log("Health:" + health);
            SetHealthText();
        }
        if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("You Win!");
        }
    }
}

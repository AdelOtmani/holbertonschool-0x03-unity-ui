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
    public Image winLoseBG;
    public Text winLoseText;

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
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(0);
    }

	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
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
            //Debug.Log("Game Over!");
            winLoseBG.gameObject.SetActive(true);
            winLoseText.color = Color.white;
            winLoseBG.color = Color.red;
            winLoseText.text = "Game Over!";
            StartCoroutine(LoadScene(3));
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
            winLoseBG.gameObject.SetActive(true);
            winLoseText.color = Color.black;
            winLoseBG.color = Color.green;
            winLoseText.text = "You win!";
            StartCoroutine(LoadScene(3));
        }
    }
}

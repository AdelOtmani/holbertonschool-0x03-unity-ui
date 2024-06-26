﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;
    public void PlayMaze()
    {
		trapMat.color = Color.red;
        goalMat.color = Color.green;

        if (colorblindMode.isOn)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

	public void QuitMaze()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }


	// Update is called once per frame
	void Update () {

	}
}

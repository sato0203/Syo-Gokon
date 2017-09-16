using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreText : MonoBehaviour {

    private int score;
    private Text text;

    private float elapsedSceonds;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        score = PlayerPrefs.GetInt("score");
        text.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        elapsedSceonds += Time.deltaTime;

        if (elapsedSceonds > 5.0f)
        {
            SceneManager.LoadScene("home_scene");
        }
	}  
}

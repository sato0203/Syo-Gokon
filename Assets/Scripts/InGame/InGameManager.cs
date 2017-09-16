using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using System.Linq;

public class InGameManager : SingletonMonoBehaviour<InGameManager> {

    private int score = 0;
    private float limitSeconds = 0;
    private float elapsedSeconds = 0;
    private float remainSeconds { 
        get {
            var answer = limitSeconds - elapsedSeconds;
            if (answer <= 0f)
                OnTimeOver();
            return answer;
            } 
    }

    private PlayerTap[] players;
    public GameObject[] stages;

	// Use this for initialization
	void Start () {
        LoadStage();
        Initialize();
	}

    void Initialize() {
        score = 100;
        players = FindObjectsOfType<PlayerTap>();

    }
	
	// Update is called once per frame
	void Update () {
        elapsedSeconds = Time.deltaTime;

        if (players.Where((PlayerTap arg) => arg.isGoal == false).Count() == 0)
        {
            Goal();
        }
	}

    public void LoadStage() {
        int stageNum = PlayerPrefs.GetInt("stage");
        Instantiate(stages[stageNum], Vector3.zero, Quaternion.identity);
    }

    public void OnReleaseFinger(OnReleaseFingerData data) {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
        SceneManager.LoadScene("game_over_scene");
    }

    private void OnTimeOver() { 
        
    }

    public void DeleteScore() {
        score -= 10;
    }

    public void Goal() { 
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
        SceneManager.LoadScene("result_scene");
    }

}

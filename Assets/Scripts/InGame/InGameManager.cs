using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;

public class InGameManager : SingletonMonoBehaviour<InGameManager> {

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
    public GameObject[] stages;

	// Use this for initialization
	void Start () {
        LoadStage();
	}
	
	// Update is called once per frame
	void Update () {
        elapsedSeconds = Time.deltaTime;
	}

    public void LoadStage() {
        int stageNum = PlayerPrefs.GetInt("stage");
        Instantiate(stages[stageNum], Vector3.zero, Quaternion.identity);
    }

    public void OnReleaseFinger(OnReleaseFingerData data) { 
    
    }

    private void OnTimeOver() { 
        
    }
}

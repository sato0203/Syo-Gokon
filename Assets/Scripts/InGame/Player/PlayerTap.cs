using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TouchScript.Gestures;
using TouchScript.Pointers;
using TouchScript.Hit;

public class PlayerTap : MonoBehaviour
{
    public float invisibleTime = 0.0f;

    //タップされている(true)か否か
    public bool isTap;
    private AudioSource badAudio;

    private void Start()
    {
        isTap = false;
        badAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(invisibleTime > 0.0f)
        {
            invisibleTime--;
        }
    }

    //オブジェクト有効化　→　イベントハンドラ有効
    private void OnEnable()
    {
        GetComponent<PressGesture>().Pressed += TappedHandler;
        GetComponent<ReleaseGesture>().Released += CanceledHandler;
    }
    //オブジェクト無効化　→　イベントハンドラ無効
    private void OnDisable()
    {
        UnsubscribeEvent();
    }

    //オブジェクト削除　→　イベントハンドラ無効
    private void OnDestroy()
    {
        UnsubscribeEvent();
    }

    private void UnsubscribeEvent()
    {
        GetComponent<PressGesture>().Pressed -= TappedHandler;
        GetComponent<ReleaseGesture>().Released += CanceledHandler;
    }

    //タップされた時のイベントハンドラ
    public void TappedHandler(object sender, EventArgs g)
    {
        Debug.Log("01:Player_Touch");
        isTap = true;
    }

    //アンタップされた時のイベントハンドラ
    public void CanceledHandler(object sender,EventArgs g)
    {
        Debug.Log("02:Player_UnTouch");
        //ゲーム進行中　＆＆　離した＝ゲームオーバー
        //InGameManager.Instance
        isTap = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall" && invisibleTime == 0.0f)
        {
            Debug.Log("全体マイナススコア");
            badAudio.Play();
            //InGameManager.Instance
            invisibleTime = 60.0f;
        }
    }
}
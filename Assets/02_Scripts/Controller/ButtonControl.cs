using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public Action StartBtn;
    public void PlayAndStop(Sprite[] sprites){
        if(Time.timeScale>0)
            Time.timeScale=0;
        else
            Time.timeScale=1;

        //text.text = Time.timeScale > 0 ? "일시정지" : "재생";
    }
    public void Lobby(){
        SceneManager.LoadScene("Lobby");
    }
    public void StartButtonBtn(){
        GameManager_CH.Instance.OnStartSetData();
        StartBtn?.Invoke();
    }
}

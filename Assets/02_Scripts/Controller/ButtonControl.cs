using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public Action StartBtn;

    public void PlayAndStop(){
        if(Time.timeScale>0)
            Time.timeScale=0;
        else
            Time.timeScale=1;
    }
    public void Lobby(){
        SceneManager.LoadScene("Lobby");
    }
    public void StartButtonBtn(){
        GameManager_CH.Instance.OnStartSetData();
        StartBtn?.Invoke();
    }
}

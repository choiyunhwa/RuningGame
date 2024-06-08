using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager_CH : MonoBehaviour
{    
    public void GameScene(StageData stageData)
    {
        GameManager_CH.Instance.stageData=stageData;
        Time.timeScale = 0;
        SceneManager.LoadScene("GameMainScene");
    }
}

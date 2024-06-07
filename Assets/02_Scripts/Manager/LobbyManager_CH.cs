using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager_CH : MonoBehaviour
{
    public void GameScene(StageData stageData)
    {
        GameManager_CH.Instance.stageData=stageData;
        GameManager_CH.Instance.StartGame();
        SceneManager.LoadScene("GameMainScene_CH");
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyManager_CH : MonoBehaviour
{
    Color trueColor = new Color(255/255, 255/255, 255/255);
    Color falseColor = new Color(97f/255f,97f/255f,97f/255f);

    public GameObject[] stages;

    void Start(){
        for(int i=1; i<stages.Length;i++){
            bool check = GameManager_CH.Instance.dataManager.data.stages[i - 1];
            stages[i].GetComponent<Image>().color = check ? trueColor:falseColor;
            stages[i].GetComponent<Button>().enabled = check;
        }
    }
    public void GameScene(StageData stageData)
    {
        GameManager_CH.Instance.stageData=stageData;
        Time.timeScale = 0;
        SceneManager.LoadScene("GameMainScene");
    }
}

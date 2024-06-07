using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{

    public GameObject EndingPanel;
    
    void Start(){
        GameManager_CH.Instance.buttonControl = this;
        EndingPanel.SetActive(false);
    }
    public void OpenEndingPanel(){
        EndingPanel.SetActive(true);
    }

    public void PlayAndStop(Text text){
        if(Time.timeScale>0)
            Time.timeScale=0;
        else
            Time.timeScale=1;

        text.text = Time.timeScale > 0 ? "일시정지" : "재생";
    }
    public void Lobby(){
        SceneManager.LoadScene("Lobby");
    }
}

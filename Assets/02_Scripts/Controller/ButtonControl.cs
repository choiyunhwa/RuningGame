using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    [Header("ButtonControl")]
    public GameObject EndingPanel;
    public GameObject StartingPanel;
    void Start(){
        GameManager_CH.Instance.buttonControl = this;
        EndingPanel.SetActive(false);
    }
    public void EndingPanelControl(bool Active)
    {
        EndingPanel.SetActive(Active);
    }
    public void StartingPanelControl(bool Active){
        StartingPanel.SetActive(Active);
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
    public void StartButtonBtn(){
        StartingPanelControl(false);
        GameManager_CH.Instance.OnStartSetData();
    }
}

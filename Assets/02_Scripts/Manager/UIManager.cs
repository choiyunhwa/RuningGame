using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public UIControl uiControl;
    public ButtonControl buttonControl;
    // Start is called before the first frame update
    void Awake(){
        uiControl = GetComponent<UIControl>();
        buttonControl = GetComponent<ButtonControl>();
    }
    void Start()
    {
        GameManager_CH.Instance.uiManager = this;
        buttonControl.StartBtn+= StartBtnAction;
        uiControl.SetStartPanel();
    }

    void StartBtnAction(){
        uiControl.StartingPanelControl(false);
    }

    public void PlayAndStopBtn(){
        buttonControl.StartButton();
        uiControl.StopAndPlayerPanelControl();
    }
}

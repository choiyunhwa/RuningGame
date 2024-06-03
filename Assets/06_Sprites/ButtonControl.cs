using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public GameObject settingPanel;

    public void OpenSetting(){
        settingPanel.SetActive(!settingPanel.activeInHierarchy);
    }
    public void PlayAndStop(Text text){
        if(Time.timeScale>0)
            Time.timeScale=0;
        else
            Time.timeScale=1;

        text.text = Time.timeScale > 0 ? "일시정지" : "재생";
    }
}

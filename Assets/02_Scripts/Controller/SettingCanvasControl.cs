using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingCanvasControl : MonoBehaviour
{
    public GameObject settingPanel;
    // Start is called before the first frame update
    void Start(){
        settingPanel.SetActive(false);
    }
    public void OpenSetting()
    {
        settingPanel.SetActive(!settingPanel.activeInHierarchy);
    }
}

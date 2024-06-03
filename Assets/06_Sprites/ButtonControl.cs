using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    public GameObject settingPanel;

    public void OpenSetting(){
        settingPanel.SetActive(!settingPanel.activeInHierarchy);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [Header("ScoreAndRemain_Canvas")]
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI remainingMonsterTxt;//남은 몬스터

    [Header("EndingPanel_Canvas")]
    public GameObject EndingPanel;
    public TextMeshProUGUI endingBodyTxt;
    public TextMeshProUGUI stageTxt;
    [Header("StartingPanel_Canvas")]
    public GameObject StartingPanel;
    public TextMeshProUGUI startingBodyTxt;


    void Start(){
        EndingPanel.SetActive(false);
    }
    void Update()
    {
        remainingMonsterTxt.text = GameManager_CH.Instance.curMonster.ToString();
        scoreTxt.text = GameManager_CH.Instance.curScore.ToString();
    }
    public void EndingPanelControl(bool Active)
    {
        stageTxt.text=$"스테이지{GameManager_CH.Instance.stageData.stageNum.ToString()}";
        EndingPanel.SetActive(Active);
    }
    public void StartingPanelControl(bool Active){
        StartingPanel.SetActive(Active);
    }


    public void SetStartPanel(){
        StageData stageData = GameManager_CH.Instance.stageData;
        startingBodyTxt.text = $"설명 : 몬스터{stageData.monsterCount}마리 출현";
        startingBodyTxt.gameObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    [Header("ScoreAndRemain_Canvas")]
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI remainingMonsterTxt;//남은 몬스터

    [Header("EndingPanel_Canvas")]
    public TextMeshProUGUI endingBodyTxt;

    [Header("StartingPanel_Canvas")]
    public TextMeshProUGUI startingBodyTxt;

    void Update()
    {
        remainingMonsterTxt.text = GameManager_CH.Instance.curMonster.ToString();
        scoreTxt.text = GameManager_CH.Instance.curScore.ToString();
    }

    public void SetStartPanel(){
        StageData stageData = GameManager_CH.Instance.stageData;
        startingBodyTxt.text = $"설명 : 몬스터{stageData.monsterCount}마리 출현";
        startingBodyTxt.gameObject.SetActive(true);
    }
}

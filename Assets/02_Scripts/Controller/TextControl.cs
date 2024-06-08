using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    [Header("ScoreAndRemain_Canvas")]
    public Text scoreTxt;
    public Text remainingMonsterTxt;//남은 몬스터

    [Header("EndingPanel_Canvas")]
    public Text endingBodyTxt;

    [Header("StartingPanel_Canvas")]
    public Text startingBodyTxt;

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

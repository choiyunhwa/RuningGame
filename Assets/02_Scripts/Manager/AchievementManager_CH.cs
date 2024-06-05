using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager_CH : MonoBehaviour
{
    //Dictionary는 직렬화가 안되요~
    public List<AchievementData> AchievementList;
    public List<AchievementData> AchievementClearList;
    void Awake(){
        AchievementList = new List<AchievementData>();
        AchievementClearList = new List<AchievementData>();
    }

    void Start()
    {
        GameManager_CH.Instance.achievementManager_CH = this;
    }

    public void GenerateData(){
        AchievementList.Add(new AchievementData("몬스터를 사냥하자","몬스터를 사냥해주세요",new int[]{100,200,300},0));
        AchievementList.Add(new AchievementData("무기를 수집","다양한 무기를 수집해 보세요",new int[]{5},1));
    }

    
    //음 스테이지 끝날때마다 체크를 해볼까?
    void CheckClear(){
        foreach(AchievementData achievement in AchievementList){
            if (achievement.curCount >= achievement.maxCount[achievement.level])
            {
                achievement.level++;
                if (achievement.level >= achievement.maxCount.Length)
                {
                    AchievementClearList.Add(achievement);
                    AchievementList.Remove(achievement);
                }
                ClearMessage();
            }
        }
    }

    void ClearMessage(){
        
    }

    public void SaveAchievementManager()
    {
        GameManager_CH.Instance.dataManager.data.achievementData = AchievementList;
    }
}

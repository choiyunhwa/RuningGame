using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public enum Type{
    MONSTER,
    WEAPON
}
public class AchievementManager_CH : MonoBehaviour
{
    //얘도 사실상 컨트롤러네
    //Dictionary는 직렬화가 안되요~
    public List<AchievementData> AchievementList;
    public List<AchievementData> AchievementClearList;
    [Header("ClearPanel")]
    public GameObject clearPanel;
    Animator animator;
    public TextMeshProUGUI text;
    void Awake(){
        AchievementList = new List<AchievementData>();
        AchievementClearList = new List<AchievementData>();
    }

    void Start()
    {
        animator = clearPanel.GetComponent<Animator>();
        GameManager_CH.Instance.achievementManager_CH = this;
    }

    public void GenerateData(){
        AchievementList.Add(new AchievementData("몬스터를 사냥하자","몬스터를 사냥해주세요",new int[]{100,200,300},Type.MONSTER));
        AchievementList.Add(new AchievementData("무기를 수집","다양한 무기를 수집해 보세요",new int[]{5},Type.WEAPON));
    }

    
    //음 스테이지 끝날때마다 체크를 해볼까?
    public void CheckClear(){
        foreach(AchievementData achievement in AchievementList){
            //ex 잡은 몬스터가 기준치보다 높을 때 
            if (achievement.curCount >= achievement.maxCount[achievement.level])
            {
                achievement.level++;
                //단계별 업적을 전부 클리어시
                if (achievement.level >= achievement.maxCount.Length)
                {
                    AchievementClearList.Add(achievement);
                    AchievementList.Remove(achievement);
                }
                ClearMessage(achievement);
            }
        }
    }

    void ClearMessage(AchievementData data)
    {
        text.text = $"업적 : {data.name}클리어!";
        clearPanel.SetActive(true);
        animator.SetBool("On",true);
        StartCoroutine(ClearMessageClose());
    }
    IEnumerator ClearMessageClose(){
        yield return new WaitForSeconds(2);
        animator.SetBool("On", false);
        yield return new WaitForSeconds(0.5f);
        clearPanel.SetActive(false);
    }
    public void SaveAchievementManager()
    {
        GameManager_CH.Instance.dataManager.data.achievementData = AchievementList;
    }
    public void LoadAchievementManager(){
        AchievementList = GameManager_CH.Instance.dataManager.data.achievementData;
    }

    //Enemy
    public void MonsterKilled(){
        AchievementList[(int)Type.MONSTER].curCount++;
    }
    //무기획득 코드에서 아 근데 이거는 무기종류도 확인해야함
    public void GetWeapon(){
        //TODO : 무기종류확인하는 로직
        AchievementList[(int)Type.WEAPON].curCount++;
    }

    //되는지 확인 불가
    public void AddData(Type type){
        AchievementList[(int)type].curCount++;
        //이걸 하면 이것만으로 업적 두개다 관리가능 근데 테스트 후 사용해야할듯
    }
}

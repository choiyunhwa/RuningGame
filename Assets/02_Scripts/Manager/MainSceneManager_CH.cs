using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainSceneManager_CH : MonoBehaviour
{
    //YH : Text > TextMeshPro Change
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI remainingMonsterTxt;//남은 몬스터
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        remainingMonsterTxt.text = GameManager_CH.Instance.curMonster.ToString();
        scoreTxt.text = GameManager_CH.Instance.curScore.ToString();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager_CH : MonoBehaviour
{
    #region 싱글톤
    private static GameManager_CH _instance;
    public static GameManager_CH Instance
    {
        get{
            if(_instance == null){
                _instance = new GameObject("GameManager").AddComponent<GameManager_CH>();
            }
            return _instance;
        }
    }
    void Awake(){
        if(_instance != null)
        {
            if(_instance != this)
                Destroy(gameObject);
        }else{
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }
    #endregion

    public DataManager_CH dataManager;
    public ButtonControl buttonControl;
    public bool isStart = false;
    public StageData stageData;
    private int curMonster;
    void Start(){
        Time.timeScale =1;
    }
    void Update(){
        if(isStart){
            //1.로비에서 스테이지를 고른다. 스테이지에 따라서 몬스터의 숫자가 달라질 예정이다.
            //2.몬스터를 다 죽이면 GameOver 호출
            if(curMonster == 0){
                GameClear();
            }
        }
    }
    //시작 버튼을 만들예정
    public void StartGame(){
        curMonster = stageData.monsterCount;
        isStart=true;
    }

    public void Lobby(){
        SceneManager.LoadScene("CHLobby");
    }
    public void GameScene(){
        SceneManager.LoadScene("CHScene");
    }
    //프로그램 종료시 자동 저장
    private void OnApplicationQuit() {
        dataManager.SaveGameData();
    }

    public void GameClear(){
        //EndingPanel이 나오고 게임이 멈춘다.
        buttonControl.OpenEndingPanel();
        Time.timeScale=0;
        isStart=false;
        //스테이지를 받아와서 Data에 클리어 했다고 표시 해준다.
    }

    //일단 여기 놔둔것들 몬스터오브젝트에 붙어있는 스크립트에 넣으면 좋을 것 같음
    //몬스터를 죽였을때
    /*
    if(dataManager.data.level>4) return; 
    public void KillMonster(int monsterLevel){     
        GameManager.Instance.dataManager.ExpCondition(int monsterLevel);
    }
    */
}

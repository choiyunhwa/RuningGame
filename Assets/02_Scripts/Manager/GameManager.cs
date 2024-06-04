using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance{
        get{
            if(_instance == null){
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
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
    public DataManager dataManager;
    
    public void StarGame(){
        SceneManager.LoadScene("CHScene");
    }
    private void OnApplicationQuit() {
        dataManager.SaveGameData();
    }
}

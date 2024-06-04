using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    string FileName = "GameData.json";
    public Data data; 
    void Start(){
        GameManager.Instance.dataManager = this;
    }
    public void LoadGameData(){
        string filePath = Application.persistentDataPath + "/" + FileName;

        if(File.Exists(filePath)){
            //File속 내용을 받아온다.
            string FromJsonData = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<Data>(FromJsonData);
            Debug.Log("불러오기 완료");
        }
        
    }
    public void SaveGameData(){
        //true 는 prettyPrint Json파일이 예쁘게 정리되어있다.
        string ToJsonData = JsonUtility.ToJson(data, true);
        //파일 저장 위치 : 사용자디렉토리/AppData/LocalLow/회사이름/프로덕트이름 (파일 읽기 쓰기 가능)
        string filePath = Application.persistentDataPath+"/"+ FileName;
        
        //이미 저장된 파일이 있다면 덮어쓰고, 없다면 새로 만든다.
        File.WriteAllText(filePath,ToJsonData);

        Debug.Log("저장완료");
    }
}

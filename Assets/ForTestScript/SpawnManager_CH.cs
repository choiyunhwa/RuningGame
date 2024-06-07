using UnityEngine;

public class SpawnManager_CH : MonoBehaviour
{
    public GameObject[] enemyObject;
    public Transform[] spawnPoints;

    public float maxSpawnDelay;
    public float curSpawnDelay;
    public int selectEnemy;
    int curCount=0; //생성을 위한 변수
    private void Update() 
    {
        if(!GameManager_CH.Instance.isStart) return;
        curSpawnDelay += Time.deltaTime;

        if(curSpawnDelay > maxSpawnDelay)
        {
            if(curCount<GameManager_CH.Instance.stageData.monsterCount){
                curCount++;
                spawnEnemy();
                curSpawnDelay = 0;
            }
        }    
    }

    void spawnEnemy()
    {
        int ranPoint = Random.Range(0, 3);

        Instantiate(enemyObject[selectEnemy], spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);
    }
}

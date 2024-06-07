using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyObject;
    public Transform[] spawnPoints;
    public ObjectManager objectManager;
    public StageData stageData;

    public float maxSpawnDelay;
    public float curSpawnDelay;
    public int curEnemyCnt = 0;

    private void Update() 
    {
        if(curEnemyCnt < stageData.monsterCount)
        {
            curSpawnDelay += Time.deltaTime;

            if(curSpawnDelay > maxSpawnDelay)
            {
                SpawnEnemy();
                curEnemyCnt++;

                curSpawnDelay = 0;
            }
        }
        else if(curEnemyCnt == stageData.monsterCount) // 추후에 일반몬스터를 다 없애고 나오는걸로 변경
        {
            SpawnEnemy();
            curEnemyCnt++;
        }    
    }

    void SpawnEnemy()
    {
        int ranPoint = Random.Range(0, 3);
        int ranEnemy = Random.Range(0, 3);
        
        // 보스몬스터 추가
        if(curEnemyCnt == stageData.monsterCount)
        {
            ranEnemy = 3;
        }
        
        GameObject rtnEnemy = objectManager.ActivateObject(enemyObject[ranEnemy].GetComponent<Enemy>().enemySO.name);

        rtnEnemy.transform.position = spawnPoints[ranPoint].position;
        rtnEnemy.transform.rotation = spawnPoints[ranPoint].rotation;
    }
}

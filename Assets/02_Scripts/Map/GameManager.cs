using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyObject;
    public Transform[] spawnPoints;
<<<<<<< HEAD
    public ObjectManager objectManager;
=======
>>>>>>> parent of 8bb921b (FIX)

    public float maxSpawnDelay;
    public float curSpawnDelay;
    public int selectEnemy;

    private void Update() 
    {
<<<<<<< HEAD
        if(curEnemyCnt < GameManager_CH.Instance.stageData.monsterCount)
        {
            curSpawnDelay += Time.deltaTime;

            if(curSpawnDelay > maxSpawnDelay)
            {
                SpawnEnemy();
                curEnemyCnt++;

                curSpawnDelay = 0;
            }
        }
        else if(curEnemyCnt == GameManager_CH.Instance.stageData.monsterCount) // 추후에 일반몬스터를 다 없애고 나오는걸로 변경
=======
        curSpawnDelay += Time.deltaTime;

        if(curSpawnDelay > maxSpawnDelay)
>>>>>>> parent of 8bb921b (FIX)
        {
            spawnEnemy();

            curSpawnDelay = 0;
        }    
    }

    void spawnEnemy()
    {
        int ranPoint = Random.Range(0, 3);
<<<<<<< HEAD
        int ranEnemy = Random.Range(0, 3);
        
        // 보스몬스터 추가
        if(curEnemyCnt == GameManager_CH.Instance.stageData.monsterCount)
        {
            ranEnemy = 3;
        }
        
        GameObject rtnEnemy = objectManager.ActivateObject(enemyObject[ranEnemy].GetComponent<Enemy>().enemySO.name);
=======
>>>>>>> parent of 8bb921b (FIX)

        Instantiate(enemyObject[selectEnemy], spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);
    }
}

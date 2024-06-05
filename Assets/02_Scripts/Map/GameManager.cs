using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyObject;
    public Transform[] spawnPoints;

    public float maxSpawnDelay;
    public float curSpawnDelay;
    public int selectEnemy;

    private void Update() 
    {
        curSpawnDelay += Time.deltaTime;

        if(curSpawnDelay > maxSpawnDelay)
        {
            spawnEnemy();

            curSpawnDelay = 0;
        }    
    }

    void spawnEnemy()
    {
        int ranPoint = Random.Range(0, 3);

        Instantiate(enemyObject[selectEnemy], spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);
    }
}

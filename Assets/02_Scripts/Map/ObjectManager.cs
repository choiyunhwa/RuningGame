using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject uniqueEnemyPrefab;
    public GameObject enemySPrefab;
    public GameObject enemyMPrefab;
    public GameObject enemyLPrefab;
    public GameObject trapSPrefab;
    public GameObject trapMPrefab;
    public GameObject trapLPrefab;

    GameObject[] uniqueEnemy;
    GameObject[] enemyS;
    GameObject[] enemyM;
    GameObject[] enemyL;
    GameObject[] trapS;
    GameObject[] trapM;
    GameObject[] trapL;

    GameObject[] targetPool;

    private void Awake() 
    {
        uniqueEnemy = new GameObject[1];
        enemyS = new GameObject[30];
        enemyM = new GameObject[20];
        enemyL = new GameObject[10];

        trapS = new GameObject[5];
        trapM = new GameObject[3];
        trapL = new GameObject[1];

        Generate();
    }

    void Generate()
    {
        // Enemy
        for (int i = 0; i < uniqueEnemy.Length; i++)
        {
            uniqueEnemy[i] = Instantiate(uniqueEnemyPrefab);
            uniqueEnemy[i].SetActive(false);
        }
        for (int i = 0; i < enemyS.Length; i++)
        {
            enemyS[i] = Instantiate(enemySPrefab);
            enemyS[i].SetActive(false);
        }
        for (int i = 0; i < enemyM.Length; i++)
        {
            enemyM[i] = Instantiate(enemyMPrefab);
            enemyM[i].SetActive(false);
        }
        for (int i = 0; i < enemyL.Length; i++)
        {
            enemyL[i] = Instantiate(enemyLPrefab);
            enemyL[i].SetActive(false);
        }

        // Trap
        for (int i = 0; i < trapS.Length; i++)
        {
            trapS[i] = Instantiate(trapSPrefab);
            trapS[i].SetActive(false);
        }
        for (int i = 0; i < trapM.Length; i++)
        {
            trapM[i] = Instantiate(trapMPrefab);
            trapM[i].SetActive(false);
        }
        for (int i = 0; i < trapL.Length; i++)
        {
            trapL[i] = Instantiate(trapLPrefab);
            trapL[i].SetActive(false);
        }
        
    }

    public GameObject MakeObject(string type)
    {
        switch (type)
        {
            case "uniqueEnemy":
                targetPool = uniqueEnemy;
                break;
            case "enemyS":
                targetPool = enemyS;
                break;
            case "enemyM":
                targetPool = enemyM;
                break;
            case "enemyL":
                targetPool = enemyL;
                break;
            case "trapS":
                targetPool = trapS;
                break;
            case "trapM":
                targetPool = trapM;
                break;
            case "trapL":
                targetPool = trapL;
                break;
        }

        for (int i = 0; i < targetPool.Length; i++)
        {
            if (!targetPool[i].activeSelf)
            {
                targetPool[i].SetActive(true);
                return targetPool[i];
            }
        }

        return null;
    }
}

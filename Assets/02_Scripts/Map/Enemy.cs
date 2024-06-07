using UnityEditor.PackageManager;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    ObjectManager objectManager;
    public AttackSO enemySO;
    public Sprite[] sprites;

    private Transform player;
    Rigidbody rigid;

    private void Awake() 
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update() 
    {
        ChasePlayer();
    }

   public void OnHit(int damage)
    {
        enemySO.health -= damage;
        //    spriteRenderer.sprite = sprites[1]; // 피격시 애니메이션
        Invoke("ReturnSprite", 0.1f);

        if (enemySO.health <= 0)
        {
            Debug.Log("맞았다");
            GameManager_CH.Instance.curMonster--;
            GameManager_CH.Instance.curScore++;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
       
    }
    void ChasePlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // 플레이어 따라서 이동
        if (distanceToPlayer > enemySO.stoppingDistance)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            rigid.MovePosition(transform.position + direction * enemySO.speed * Time.deltaTime);
        }
    }


}

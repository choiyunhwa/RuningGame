using UnityEngine;

public class Enemy : MonoBehaviour
{
    ObjectManager objectManager;
    public AttackSO enemySO;
    Rigidbody rigid;

    private Transform player;

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
    









    // void MoveEnemy()
    // {
    //     transform.position += Vector3.back * speed * Time.deltaTime;
    // }

    // void OnHit(int damage)
    // {
    //     health -= damage;
    //     spriteRenderer.sprite = sprites[1]; // 피격시 애니메이션
    //     Invoke("ReturnSprite", 0.1f);

    //     if (health <= 0)
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    // void ReturnSprite()
    // {
    //     spriteRenderer.sprite = sprites[0];
    // }

    // private void OnTriggerEnter(Collider other) 
    // {
        
    // }


}

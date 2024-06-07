using UnityEditor.PackageManager;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    ObjectManager objectManager;
    public AttackSO enemySO;
    Rigidbody rigid;
    public int health;

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

        if (distanceToPlayer > enemySO.stoppingDistance)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            rigid.MovePosition(transform.position + direction * enemySO.speed * Time.deltaTime);
        }
    }

   public void OnHit(int damage)
    {
        health -= damage;
        //    spriteRenderer.sprite = sprites[1]; // 피격시 애니메이션
        Invoke("ReturnSprite", 0.1f);

        if (health <= 0)
        {
            Debug.Log("맞았다");
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        
    }
       

}

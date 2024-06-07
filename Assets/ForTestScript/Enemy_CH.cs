using UnityEngine;

public class Enemy_CH : MonoBehaviour
{
    ObjectManager objectManager;

    public float speed;
    public int health;
    public Sprite[] sprites;

    SpriteRenderer spriteRenderer;
    Rigidbody rigid;

    private void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }

    void OnHit(int damage)
    {
        health -= damage;
        spriteRenderer.sprite = sprites[1]; // 피격시 애니메이션
        Invoke("ReturnSprite", 0.1f);

        if (health <= 0)
        {
            GameManager_CH.Instance.curMonster--;
            Destroy(gameObject);
        }
    }

    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }

    private void OnTriggerEnter(Collider other) 
    {
        
    }


}

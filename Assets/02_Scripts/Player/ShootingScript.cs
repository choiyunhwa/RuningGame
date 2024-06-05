using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Transform player; // 플레이어의 위치를 나타내는 변수
    public Transform enemy; // 적의 위치를 나타내는 변수
    public GameObject bulletPrefab; // 총알 프리팹
    public float shootingDistance = 40f; // 총을 쏠 거리
    public float bulletSpeed = 10f; // 총알 속도

    void Update()
    {
        // 플레이어와 적 사이의 거리를 계산
        float distanceToEnemy = Vector3.Distance(player.position, enemy.position);

        // 만약 적이 총을 쏠 거리 안에 들어오면
        if (distanceToEnemy <= shootingDistance)
        {
            Shoot(); // 총을 쏘는 함수 호출
        }
    }

    void Shoot()
    {
        // 총알 생성 및 초기 위치 설정
        GameObject bullet = Instantiate(bulletPrefab, transform.position+new Vector3(0,0.4f,0), Quaternion.identity);

        // 총알 방향 설정
        Vector3 shootDirection = (enemy.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = shootDirection * bulletSpeed;



        // 총알이 적과 충돌했을 때의 처리
    //    bullet.GetComponent<bullet>().; // 적과 충돌했을 때의 처리를 담당하는 함수 호출
    }
}

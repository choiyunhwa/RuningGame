using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    // 총알 프리팹
    public GameObject bulletPrefab;

    // 총알 속도
    public float bulletSpeed ;

    // 적 게임 오브젝트 태그
public LayerMask layerMask;

    // 총알 발사 거리
    public float shootingDistance ;

    // Update 함수
    void Update()
    {
        // 플레이어 주변 적 감지
        DetectAndShootEnemy();
        Debug.DrawRay(transform.position + new Vector3(0, 0.4f, 0), transform.forward * 100, Color.red);

    }
    
    // 플레이어 주변 적 감지 및 발사 함수
    void DetectAndShootEnemy()
    {
        // 시선 (ray를 쏘는 위치, 쏘는 방향)
      
        Ray ray = new Ray(transform.position + new Vector3(0, 0.4f, 0), transform.forward);
      
        // 닿은 곳의 정보
        RaycastHit hitInfo;

        // 바라본다
        if (Physics.Raycast(ray, out hitInfo, shootingDistance,layerMask))
        {
                Shoot(hitInfo.transform.gameObject);

            Debug.Log("적");
            // 닿았다 (Raycast가 true일때)
            if (hitInfo.collider.gameObject.layer == 7)
            {
                Debug.Log("총 ");
                // 적 발견 시 총 발사
                Shoot(hitInfo.transform.gameObject);
            }
        }
    }

    // 총 발사 함수
    void Shoot(GameObject enemyObject)
    {
        // 총알 생성 및 초기 위치 설정
        GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, 0.4f, 0), Quaternion.identity);

        // 총알 방향 설정
        Vector3 shootDirection = (enemyObject.transform.position- transform.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = shootDirection * bulletSpeed;
    }
}


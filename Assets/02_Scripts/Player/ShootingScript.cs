using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    // 총알 프리팹
    public GameObject bulletPrefab;
    public ObjectManager objectManager;

    // 총알 속도
    public float bulletSpeed;

    // 적 게임 오브젝트 태그
    public LayerMask layerMask;

    // 총알 발사 거리
    public float shootingDistance;


    float attackCoolTime=0.2f;
    float timer;


    // Update 함수
    void Update()
    {
        // 플레이어 주변 적 감지
        DetectAndShootEnemy();
        Debug.DrawRay(transform.position + new Vector3(0, 0.4f, 0), transform.forward * 100, Color.red);

        timer += Time.deltaTime;

    }

    // 플레이어 주변 적 감지 및 발사 함수
    void DetectAndShootEnemy()
    {
        // 감지 각도 설정
        float detectionAngle = 45f; // 감지할 각도 (예: 45도)

        // 레이 발사 지점과 방향 설정
        Vector3 rayOrigin = transform.position + new Vector3(0, 0.4f, 0); // 레이 발사 위치
        Vector3 forward = transform.forward; // 현재 방향

        // 적을 발견한 경우를 나타내는 변수
        bool enemyDetected = false;

        // 여러 각도로 레이 발사하여 감지
        for (float angle = -detectionAngle / 2; angle <= detectionAngle / 2; angle += 5f)
        {
            // 현재 각도에 따른 방향 계산
            Quaternion rotation = Quaternion.AngleAxis(angle, transform.up);
            Vector3 direction = rotation * forward;

            // 레이 생성
            Ray ray = new Ray(rayOrigin, direction);

            // 레이 쏘기
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, shootingDistance, layerMask))
            {
                // 적을 발견하면 총 발사
                if (hitInfo.collider.gameObject.layer == 7 || hitInfo.collider.gameObject.layer == 8)
                {
                    if (timer >= attackCoolTime)
                    {

                        Shoot(hitInfo.transform.gameObject);

                        timer = 0;

                    }
                    Debug.Log("적 발견!");
                    enemyDetected = true; // 적을 발견했음을 표시
                }
            }
        }
    }

    // 총 발사 함수
    void Shoot(GameObject enemyObject)
    {
        // 총알 생성 및 초기 위치 설정
        GameObject bullet = objectManager.Activatebullet();
        bullet.transform.position = transform.position + new Vector3(0, 0.4f, 0);

        //Instantiate(bulletPrefab, , Quaternion.identity);
        // 총알 방향 설정
        Vector3 shootDirection = (enemyObject.transform.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = shootDirection * bulletSpeed;
    }
}


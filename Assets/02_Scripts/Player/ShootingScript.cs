using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    // �Ѿ� ������
    public GameObject bulletPrefab;

    // �Ѿ� �ӵ�
    public float bulletSpeed;

    // �� ���� ������Ʈ �±�
    public LayerMask layerMask;

    // �Ѿ� �߻� �Ÿ�
    public float shootingDistance ;

    // Update �Լ�
    void Update()
    {
        // �÷��̾� �ֺ� �� ����
        DetectAndShootEnemy();
        Debug.DrawRay(transform.position + new Vector3(0, 0.4f, 0), transform.forward * 100, Color.red);

    }

    // �÷��̾� �ֺ� �� ���� �� �߻� �Լ�
    void DetectAndShootEnemy()
    {
        // ���� ���� ����
        float detectionAngle = 45f; // ������ ���� (��: 45��)

        // ���� �߻� ������ ���� ����
        Vector3 rayOrigin = transform.position + new Vector3(0, 0.4f, 0); // ���� �߻� ��ġ
        Vector3 forward = transform.forward; // ���� ����

        // ���� �߰��� ��츦 ��Ÿ���� ����
        bool enemyDetected = false;

        // ���� ������ ���� �߻��Ͽ� ����
        for (float angle = -detectionAngle / 2; angle <= detectionAngle / 2; angle += 5f)
        {
            // ���� �̹� �߰������� ����
            if (enemyDetected)
                break;

            // ���� ������ ���� ���� ���
            Quaternion rotation = Quaternion.AngleAxis(angle, transform.up);
            Vector3 direction = rotation * forward;

            // ���� ����
            Ray ray = new Ray(rayOrigin, direction);

            // ���� ���
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, shootingDistance, layerMask))
            {
                // ���� �߰��ϸ� �� �߻�
                if (hitInfo.collider.gameObject.layer == 7 || hitInfo.collider.gameObject.layer == 8)
                {
                    Shoot(hitInfo.transform.gameObject);
                    Debug.Log("�� �߰�!");
                    enemyDetected = true; // ���� �߰������� ǥ��
                }
            }
        }
    }

    // �� �߻� �Լ�
    void Shoot(GameObject enemyObject)
    {
        // �Ѿ� ���� �� �ʱ� ��ġ ����
        GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, 0.4f, 0), Quaternion.identity);

        // �Ѿ� ���� ����
        Vector3 shootDirection = (enemyObject.transform.position- transform.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = shootDirection * bulletSpeed;
    }
}


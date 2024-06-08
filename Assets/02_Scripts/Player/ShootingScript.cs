using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    // �Ѿ� ������
    public GameObject bulletPrefab;

    // �Ѿ� �ӵ�
    public float bulletSpeed ;

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
        // �ü� (ray�� ��� ��ġ, ��� ����)
      
        Ray ray = new Ray(transform.position + new Vector3(0, 0.4f, 0), transform.forward);
      
        // ���� ���� ����
        RaycastHit hitInfo;

        // �ٶ󺻴�
        if (Physics.Raycast(ray, out hitInfo, shootingDistance,layerMask))
        {
                Shoot(hitInfo.transform.gameObject);

            Debug.Log("��");
            // ��Ҵ� (Raycast�� true�϶�)
            if (hitInfo.collider.gameObject.layer == 7)
            {
                Debug.Log("�� ");
                // �� �߰� �� �� �߻�
                Shoot(hitInfo.transform.gameObject);
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


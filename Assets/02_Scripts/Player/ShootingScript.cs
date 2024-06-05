using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Transform player; // �÷��̾��� ��ġ�� ��Ÿ���� ����
    public Transform enemy; // ���� ��ġ�� ��Ÿ���� ����
    public GameObject bulletPrefab; // �Ѿ� ������
    public float shootingDistance = 40f; // ���� �� �Ÿ�
    public float bulletSpeed = 10f; // �Ѿ� �ӵ�

    void Update()
    {
        // �÷��̾�� �� ������ �Ÿ��� ���
        float distanceToEnemy = Vector3.Distance(player.position, enemy.position);

        // ���� ���� ���� �� �Ÿ� �ȿ� ������
        if (distanceToEnemy <= shootingDistance)
        {
            Shoot(); // ���� ��� �Լ� ȣ��
        }
    }

    void Shoot()
    {
        // �Ѿ� ���� �� �ʱ� ��ġ ����
        GameObject bullet = Instantiate(bulletPrefab, transform.position+new Vector3(0,0.4f,0), Quaternion.identity);

        // �Ѿ� ���� ����
        Vector3 shootDirection = (enemy.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = shootDirection * bulletSpeed;



        // �Ѿ��� ���� �浹���� ���� ó��
    //    bullet.GetComponent<bullet>().; // ���� �浹���� ���� ó���� ����ϴ� �Լ� ȣ��
    }
}

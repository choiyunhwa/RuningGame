using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
   // public LayerMask layerMask;

    // �ִ� ü��

    public float maxHealth;

    // ���� ü��
    public float currentHealth;

    // �����̴� ������Ʈ 
    public Slider healthSlider;

   
    void Start()
    {
        // ���� �� ���� ü���� �ִ� ü������ ����
        currentHealth = maxHealth;

        // �����̴��� �ִ� ���� �ִ� ü������ ����
        healthSlider.maxValue = maxHealth;

        // �����̴��� ���� ���� ���� ü������ ����
        healthSlider.value = currentHealth;
    }

    // ü�� ���� �Լ�
    public void TakeDamage(float damage) {
        currentHealth -= damage; // ���ظ� ����
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
           Debug.Log("���");
        }
        // �����̴��� ���� ���� ���� ü������ ������Ʈ
    }

    
}
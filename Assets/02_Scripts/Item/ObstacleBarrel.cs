using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectStat
{
    public int maxValue;
    public AttackSO attackSO;
}
public class ObstacleBarrel : Item
{
    [SerializeField] private ObjectStat objectStat;
    [SerializeField] private TextMeshProUGUI text;

    private int currentValue;
    [SerializeField] private int maxValue;

    private void Awake()
    {
        currentValue = maxValue;
    }

    public override void ItemEffect()
    {
        base.ItemEffect();

        //�÷��̾� ���� ������

        if(currentValue > 0)
        {
            currentValue --;
            UpdateText();
        }
        Debug.Log(currentValue);
    }

    private void UpdateText()
    {
        if(text != null)
        {
            text.text = currentValue.ToString();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Attacks/Default", order = 0)]
public class AttackSO : ScriptableObject
{
    public float power;
    public LayerMask terget;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TowerData", menuName = "ScriptableObject/Tower Data Asset", order = 1)]
public class TowerData : ScriptableObject
{
    [SerializeField] Sprite image;
    [SerializeField] float attackPower = 10; // ???
    [SerializeField] float fireTime = 0.15f; // ?? ??
    [SerializeField] [Range(0, 100)]float skillGage = 0; // ?????

    public Sprite sprite => image;
    public float AttackPower => attackPower;
    public float FireTime => fireTime;
    public float SkillGage => skillGage;
}

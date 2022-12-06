using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObject/Enemy Data Asset", order = 2)]
public class EnemyData : ScriptableObject
{
    [SerializeField] Sprite image;
    [SerializeField] float movementspeed = 0.07f;
    [SerializeField] int hp = 200;

    public Sprite sprite => image;

    public float MovementSpeed => movementspeed;

    public int Hp => hp;

}

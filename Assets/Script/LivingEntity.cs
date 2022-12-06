using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IDamageable
{
    ///<summary> 피해량(damage), 맞은 지점(hitPoint), 맞은 표면의 법선 벡터(hitNormal)
    bool OnDamage(float damage);
}
public class Liveingentity : MonoBehaviour, IDamageable
{
    public float health { get; protected set; } = 0; // 현재 체력.
    public bool isDead => (0 >= health); // 죽음 상태 확인.
    public event System.Action OnDamagedEvent;

    public virtual bool OnDamage(float damage)
    {
        if (isDead) return false; // 이미 죽은 상태라면 더 이상 처리하지 않는다.
        health = Mathf.Max(health - damage, 0); // 데미지 만큼 체력 감소.
        OnDamagedEvent?.Invoke();
        return true;
    }
}
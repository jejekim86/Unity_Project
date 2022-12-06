using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour, IPoolingObject
{
    [SerializeField] float speed = 3; // 총알 날라가는 속도
    float time = 0;
    Rigidbody2D rigid;
    Coroutine firecoroutine = null;
    public void Initialize(object value) { }
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        gameObject.SetActive(false);
    }

    public void Movetotarget(Vector3 firepos, Vector3 targetpos)
    {
        time += (Time.deltaTime * 0.03f);
        rigid.position = Vector3.Lerp(firepos, targetpos, time);
            time = 0;
    }
}

// 
// 코루틴으로 발사 속도 
// lerp(플레이어 현재 위치, 몬스터 현재 위치, 0);

// 풀링은 그냥 갖다가 저장하는 거

// 타워의 발사속도라던지 타워의 총알 색깔은 타워가 갖고 있어야 함

// 지금 불릿을 타워에서 셋데이타할때 불릿도 같이 스폰하는데
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : Liveingentity, IPoolingObject
{
    [SerializeField] TextMeshProUGUI HpText;
    float Hp;
    Sprite Sprite;
    public Rigidbody2D Myrigid { get; private set; }
    Vector3 startpos;
    Vector3 endpos;
    Collider2D MyCollider;
    float MovementSpeed;
    float t;
    bool isDead = false;
    int check = 0; // test
    System.Text.StringBuilder strSp = new System.Text.StringBuilder();
    public Vector3 Getpos() { return Myrigid.position; }

    public void Initialize(object value)
    {
        if (value is EnemyData data)
        {
            Hp = data.Hp;
            MovementSpeed = data.MovementSpeed;
        }
        Myrigid = gameObject.AddComponent<Rigidbody2D>();
        Myrigid.gravityScale = 0;
        //임시
        startpos = new Vector3(-4.5f, -2, 0);
        endpos = new Vector3(-4.5f, 4, 0);
    }

    public void Update() // 임시 // 나중에 계산돠는 변수들은 fixupdate에 넣을 예정
    {
        UpdateHp();
    }

    public void Move(Vector3 first, Vector3 Second, Vector3 Third, Vector3 Fourth)
    {
        //test
        t += Time.deltaTime * MovementSpeed;
        Myrigid.position = Vector3.Lerp(startpos, endpos, t);
        if (1 <= t)
        {
 
            startpos = endpos;
            if (startpos == Second)
                endpos = Third;
            else if (startpos == Third)
                endpos = Fourth;
            else if (startpos == Fourth)
            {
                Myrigid.position = first;
                startpos = first;
                endpos = Second;
                gameObject.SetActive(false);
            }
            t = 0;
        }
    }

    public void Initpos(Vector3 start, Vector3 end) // 초기 좌표
    {
        startpos = start;
        endpos = end;
    }

    void UpdateHp()
    {
        strSp.Clear();
        strSp.Append(Hp);
        HpText.text = strSp.ToString();
    }

    // 해당 끝지점으로 가는 함수
    bool Attackpos(Vector3 end)
    {
        if (startpos == end) return true;
        else return false;
    }

    public void Activeobject()
    {
        gameObject.SetActive(true);
    }

    public bool CheckActive()
    {
        if (gameObject.activeSelf)
            return true;
        else
        return false;
    }

    public override bool OnDamage(float Damage)
    {
        if (base.OnDamage(Damage))
        {
            if (isDead)
                gameObject.SetActive(false);
            return true;
        }
            return false;
    }
}

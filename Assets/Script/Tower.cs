using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] new SpriteRenderer renderer;
    public float attackpower { get; private set; }
    public float firetime { get; private set; }
    public float skillgage { get; private set; }
    Coroutine coroutine;
    int count = 1;
    public Rigidbody2D rigid { get; private set; }

    private void Start()
    {
        rigid = gameObject.AddComponent<Rigidbody2D>();
        rigid.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void SetData(TowerData data)
    {
        renderer.sprite = data.sprite;
        //TODO : data set
        attackpower = data.AttackPower;
        firetime = data.FireTime;
        skillgage = data.SkillGage;
        Debug.Log(rigid.position);
    }


    //private IEnumerator Attack(Liveingentity target)
    //{
    //    if (target.isDead) yield break;
    //    yield return new WaitForSeconds(firetime);
    //    if (Bulletspawn.Instance.ActiveObject(count))
    //    Bulletspawn.Instance.Onfire(rigid.position, target.transform.position);
    //    count++;
    //    target.OnDamage(attackpower);
    //}

    //public void AttacktoTarget(Liveingentity target)
    //{
    //    coroutine = StartCoroutine(Attack(target));
    //    coroutine = null;
    //}

}

// 타워는 그냥 해당 불릿이 나가는 초기 좌표 및 타워 공격력, 발사속도, 해당 타겟 위치를 가져주는거
// 불릿은 해당 타워의 값을 들고와서 해당 타워 위치값에서 타겟 위치값까지 가서
// 발사 및 공격 함수 구현


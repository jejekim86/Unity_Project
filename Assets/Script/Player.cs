using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] TowerData[] datas;
    [SerializeField] Tower[] towers;
    List<Tower> tower;
    List<Tower> selecttower;
    List<Enemy> enemiestower;
    
    private void Start()
    {
        tower = new List<Tower>(towers);
        selecttower = new List<Tower>();
    }

    public bool RandomImage()
    {
        if (0 < tower.Count)
        {
            int index = Random.Range(0, datas.Length);
            TowerData data = datas[index];

            index = Random.Range(0, tower.Count);
            tower[index].SetData(data);
            selecttower.Add(tower[index]);
            tower.RemoveAt(index);
            return true;
        }
        else return false;
    }

    public void AttackTarget()
    {
        for(int i = 0; i < selecttower.Count; i++)
        Bulletspawn.Instance.Onfire(selecttower[i], enemiestower[0]);
        //if (enemiesdata[0].isDead)
        //    enemiesdata.RemoveAt(0);
    }

    public void GetenemiesData(Enemy enemy)
    {
        enemiestower.Add(enemy);
    }
}
// 플레이어가 공격하면


// 플레이어가 공격해야하는거라
// 플레이어가 애너미의 데이터를 List로 가져와서 해당 불릿스폰한테 데이터를 줘서
// 플레이어가 공격을 하면 해당 데이터를 불릿스폰으로 주고 (공격력 및 좌표)
// 불릿스폰이 lerp함수를 이용해서 플레이어좌표에서 -> 애너미 좌표까지 가면
// 애너미 채력깎는 함수를 이용하면 됌
// 그리고 불릿은 리스트에 제외 ---> 이건 위에꺼 다하면 나중에 구현
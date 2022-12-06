using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMgr : Spawner<Enemy>
{
    [SerializeField] EnemyData data;
    public Vector3 firstpos { get; private set; }
    public Vector3 secondpos { get; private set; }
    public Vector3 thirdpos { get; private set; }
    public Vector3 fourthpos { get; private set; }
    [SerializeField] [Range(0.01f, 2)]float spawntime = 0.7f;
    int i = 0;
    float t = 0; // 임시 타임 변수
    int maxenemiescount;

    List<Enemy> enemies = new List<Enemy>();
    public void Initialize()
    {

        Clear();
        EnemyDirection();
        InitializeSpawner(data);
        //enemy.Initpos(firstpos, secondpos);

    }

    public void EnemyDirection() // 몬스터 이동 방향
    {
        firstpos = new Vector3(-4.5f, -2, 0);
        secondpos = new Vector3(-4.5f, 4, 0);
        thirdpos = new Vector3(4.5f, 4, 0);
        fourthpos = new Vector3(4.5f, -2, 0);
    }

    public void spawnEnemy(int count) // 몬스터 생성
    {
        if (count == 0) return;
        Enemy enemy = null;
        for (int i = 0; count > i; i++)
        {
            enemy = Spawn(0);
            enemies.Add(enemy);
            //GameMgr.Instance.UpdateGUIEnemiesCount(SpawnCount);
        }

        return;
    }

    public void EnemyActive()
    {
        if (3 < (t += Time.deltaTime))
        {
            if (maxenemiescount < enemies.Count)
            {
                enemies[maxenemiescount].Activeobject();
                maxenemiescount++;
            }
            t = 0;
        }
    }

    public void EnemyMove()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].CheckActive())
                enemies[i].Move(firstpos, secondpos, thirdpos, fourthpos);
            //enemies[0].Activeobject();

        }
    }

    public Enemy SetEneiesData(int count)
    {
        if (enemies.Count < count) return null;
        return enemies[count];
    }

    //public void SpawnTime(int count) // 일정 시간 만큼 스폰
    //{
    //    spawnEnemy(count);
    //    t = 0;

    //    Debug.Log(t);
    //}

}


// Hp가 0이면 풀링오브젝트를 사용하고
// 해당 위치까지 도달하면 그냥 초기 좌표를 줘서 이동하겠끔

// EnemyMgr는 이동 경로, 데이터입력(초기좌표, 이동속, hp 등...), 생성, 죽음

// Enemy는 이동, 모션, 피격
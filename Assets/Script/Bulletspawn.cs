using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bulletspawn : Spawner<Bullet>
{
    List<Bullet> bullets = new List<Bullet>();
    Coroutine coroutine;
    float t;
    static Bulletspawn instance = null;
    public static Bulletspawn Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<Bulletspawn>();
                instance.Initialize();
                //DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }
    public void Initialize()
    {
        Clear();
        InitializeSpawner();
    }
    private void Awake()
    {
        if(this != Instance)
        Destroy(gameObject);
    }

    public void spawnbullet(int Maxbullet)
    {
        if (Maxbullet == 0) return;
        Bullet bullet = null;
        for (int i = 0; i < Maxbullet; i++)
        {
            bullet = Spawn(0);
            bullets.Add(bullet);
            //Debug.Log(i);
        }
    }

    public void Onfire(Tower tower, Liveingentity target)
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!target.isDead)
            {
                bullets[i].gameObject.SetActive(true);
                bullets[i].Movetotarget(tower.rigid.position, target.transform.position);
                target.OnDamage(tower.attackpower);
            }
        }
    }

    //public bool ActiveObject(int count)
    //{
    //    if (bullets.Count > count) return false;
    //    else
    //    {
    //        bullets[count].gameObject.SetActive(true);
    //        return true;
    //    }
    //}
}

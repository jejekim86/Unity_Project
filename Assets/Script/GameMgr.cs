using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
public enum GameState
{ 
    Mainstate,
    Startstate,
}

public sealed class GameMgr : MonoBehaviour
{
    Button PlayerButton; 
    //[SerializeField] Button UIButton;
    GameState state;
    [Header("Game Rule")]
    [SerializeField] int Life = 3;
    [SerializeField] int Wave = 1;
    [SerializeField] int Timer = 0; // Test
    [SerializeField] int Sp = 0; // 현재 내가 들고있
    int PlayerSp = 0; // Dice?????? ?????? Sp??

    [Header("Dice")]
    [SerializeField] Player player;
    [SerializeField] EnemyMgr enemymgr;
    [SerializeField] Bulletspawn bulletspawn;

    [Header("MAP")]
    [SerializeField] GameObject MainUI;
    [SerializeField] GameObject GameUI;
    [SerializeField] TextMeshProUGUI SpText;


    int count = 0;
    int Maxbullet = 100;
    System.Text.StringBuilder strSp = new System.Text.StringBuilder();
    public int MaxEnemiesSpawnCount => Mathf.RoundToInt(10 * Wave);

    //MoveTowards 

    static GameMgr instance = null;
    public static GameMgr Instance
    {
        get
        {
            if(!instance)
            {
                instance = FindObjectOfType<GameMgr>();
                instance.Initialize();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (this != Instance)
            Destroy(gameObject);
    }

    private void Initialize()
    {
        state = GameState.Mainstate;
        StartGame();
    }

    void StartGame()
    {
        state = GameState.Startstate;
        enemymgr.Initialize();
        UpdateGUIEnemiesCount(0);

        Bulletspawn.Instance.Initialize();
        Bulletspawn.Instance.spawnbullet(Maxbullet);

        for (int i = 0; i < MaxEnemiesSpawnCount; i++)
            player.GetenemiesData(enemymgr.SetEneiesData(i));
    }

    public void Update()
    {
        // Test
        enemymgr.EnemyActive();
        enemymgr.EnemyMove();
        //player.AttackTarget();
        UpdateSp();
    }
    public void UpdateGUIEnemiesCount(int value) // value 일단 임시 나중에 수정해야함
    {
        if (1 > value)
            enemymgr.spawnEnemy(MaxEnemiesSpawnCount);
    }
    public void CreateDice()
    {
        if (Sp >= PlayerSp)
        {
            if(player.RandomImage())
                Sp -= PlayerSp;
            if (PlayerSp < 200)
                PlayerSp += 20;
        }
    }
    public void SettingGameState()
    {
        /*        bool main = (GameState.Mainstate == state);
                MainUI.SetActive(main);
                GameUI.SetActive(!main);
                if (!main)
                    Debug.Log("!main");
        */
        switch (state)
        {
            case GameState.Mainstate:
                {
                    MainUI.SetActive(true);
                    GameUI.SetActive(false);
                    state = GameState.Startstate;
                }
                break;
            case GameState.Startstate:
                {
                    GameUI.SetActive(true);
                    MainUI.SetActive(false);
                    state = GameState.Mainstate;
                }
                break;
        }
    }

    //void AddScore()
    //{ 
    //}

    public void NextWave()
    {
        Wave++;
    }

    void UpdateSp()
    {
        strSp.Clear();
        strSp.Append("sp : ");
        strSp.Append(Sp);
        SpText.text = strSp.ToString();
    }
}
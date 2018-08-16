using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGameDifficulty : MonoBehaviour {

    private GameManager game;
    private GameUI gameUI;
    private EnemySpawner enemySpawner;
    private EnemySpawner friendSpawner;
    private PlayerController play;
    public int DifLv = 1;
    public int DifEnemyBasisNum = 10;
    public int DifFriendBasisNum = 4;
    float timeF;
    float timeD;
    float timeP;
    float timeE;

    private void Start()
    {
        game = (GameManager)GameObject.FindObjectOfType(typeof(GameManager));
        play = (PlayerController)GameObject.FindObjectOfType(typeof(PlayerController));
        gameUI = (GameUI)GameObject.FindObjectOfType(typeof(GameUI));
        enemySpawner = GameObject.Find("SpawnerEnemy").GetComponent<EnemySpawner>();
        friendSpawner = GameObject.Find("SpawnerFriend").GetComponent<EnemySpawner>();
        friendSpawner.enemyCount = DifFriendBasisNum;
        timeD = 0;
        timeP = 0;
        timeE = 0;
        timeF = 0;
    }

    private void Update()
    {
        if (!play.Active) return;

        timeD += Time.deltaTime;
        timeP += Time.deltaTime;
        timeE += Time.deltaTime;
        timeF += Time.deltaTime;

        if (timeD >= game.timeAddDif) {
            AddDif();
            timeD = 0;
        }

        if (timeP >= game.timePOPShow) {            
            ShowPop();
            timeP = 0;
        }

        if (timeE >= game.timeEndGame) {
            EndGame();
            timeE = 0;
        }
        //Debug.Log(timeF);
    }

    void AddDif() {
        Debug.Log("增加了难度: " + timeD + "---" + timeF);
        if (DifLv >= game.DifLvMax) return;
        friendSpawner.enemyCount -= DifLv;
        DifLv++;
        enemySpawner.enemyCount = DifEnemyBasisNum * DifLv;
        
    }
    void ShowPop() {
        if (!game.isOpenAD) return;
        Debug.Log("弹出AD: " + timeP + "---" + timeF);        
        gameUI.ShowPop();
    }
    void EndGame() {
        Debug.Log("地狱死亡模式: " + timeE + "---" + timeF);

    }
}

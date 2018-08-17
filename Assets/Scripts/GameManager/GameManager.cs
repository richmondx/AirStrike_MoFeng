using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = (GameManager)GameObject.FindObjectOfType(typeof(GameManager));
            return instance;
        }
        set { }
    }

    // basic game score
    public int Killed;
    public int Score;
    public int GetGold;
    public int Ranking;

    public bool isOpenAD = false;
    public bool isUGUI = true;

    public int MultipleGoldKills = 3;
    public float MultipleGoldLv = .2f;
    public int MultipleScoreKills = 3;
    public float MultipleScoreLv = .37f;

    public int DifLvMax = 3;
    public int BasisScoreMax = 25;
    public int BasisGoldMax = 20;
    public int UpSkillLvMax = 50;

    public float MultipleUpHp = 1.09f;
    public float MultipleUpAtk = 1.08f;
    public int BasisUpHp = 5;
    public int BasisUpAtk = 7;

    public int BasisRanking = 1000;
    public int MultipleRankKill = 100;
    public int MultipleRankLv = 50;
    public int MultipleRankRandomLv = 10;

    public float timePOPShow = 5;
    public float timeAddDif = 20;
    public float timeEndGame = 120;

    public int HpLvMax = 50;
    public int AtkLvMax = 50;
    private PlayerDate playDate;

    void Start () {
        ClearDate();
        playDate = this.GetComponent<PlayerDate>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClearDate() {
        Killed = 0;
        Score = 0;
        GetGold = 0;
    }

	// add score function
	public void AddKilled(){
        Score += CountScoreAdd();
		Killed +=1;
        GetGold = CountGold();
        Ranking = CountRanking();

    }
    public int GetUpHpPay() {
        return BasisUpHp * (int)(playDate.LvHp* MultipleUpHp);
    }
    public int GetUpAtkPay() {
        return BasisUpAtk * (int)(playDate.LvWeapon * MultipleUpAtk);
    }

    public int CountScoreAdd() {
        return BasisScoreMax + (int)(1 + PlayerDate.Instance.LvWeapon * MultipleScoreLv);
    }

    private int CountGold() {
        return (Random.Range(1, BasisGoldMax) + Killed * MultipleGoldKills) *
            (int)(1 + PlayerDate.Instance.LvWeapon * MultipleGoldLv);
    }
    
    private int CountRanking() {
        return 1*(1000 + (Killed * MultipleRankKill)+(PlayerDate.Instance.LvWeapon * MultipleRankLv)+ Random.Range(0,(MultipleRankRandomLv * PlayerDate.Instance.LvWeapon)));
    }

    void OnGUI(){
		//GUI.Label(new Rect(20,20,300,30),"Kills "+Score);
	}

	// game over fimction
	public void GameOver(){
		GameUI menu = (GameUI)GameObject.FindObjectOfType(typeof(GameUI));
        playDate.AddGold(GetGold);
        if (menu){
			menu.Mode = 1;	
		}
    }
}

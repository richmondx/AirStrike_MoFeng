using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	// basic game score
	public int Killed { get; private set; }
    public int Score { get; private set; }
    public int GetGold { get; private set; }

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

    public float timePOPShow = 5;
    public float timeAddDif = 20;
    public float timeEndGame = 120;

    private PlayerDate playDate;
    void Start () {
		Killed = 0;
        Score = 0;
        GetGold = 0;
        playDate = (PlayerDate)GameObject.FindObjectOfType(typeof(PlayerDate));

    }
	
	// Update is called once per frame
	void Update () {
		
	}
	// add score function
	public void AddKilled(){
        Score += CountScoreAdd();
		Killed +=1;
        GetGold = CountGold();

    }

    public int CountScoreAdd() {
        return BasisScoreMax + (int)(1 + PlayerDate.Instance.LvWeapon * MultipleScoreLv);
    }
    public int CountGold() {
        return (Random.Range(1, BasisGoldMax) + Killed * MultipleGoldKills) *
            (int)(1 + PlayerDate.Instance.LvWeapon * MultipleGoldLv);
    }
    public void CountRanking() {

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

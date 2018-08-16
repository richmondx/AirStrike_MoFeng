using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	// basic game score
	public int Killed = 0;
    public int Score = 0;
    public int GetGold = 0;
    public bool isOpenAD = true;
    public bool isUGUI = true;
    public int AirScore = 250;
    public int MultipleGoldKills = 3;
    public float MultipleGoldLv = .2f;
    public int MultipleScoreKills = 3;
    public float MultipleScoreLv = .37f;


    public int BasisScoreMax = 25;
    public int BasisGoldMax = 20;
    public int UpSkillLvMax = 50;

    private PlayerDate playDate;
    void Start () {
		Killed = 0;
        Score = 0;
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
        return BasisScoreMax + (int)(1 + playDate.LvWeapon * MultipleScoreLv);
    }
    public int CountGold() {
        return (Random.Range(1, BasisGoldMax) + Killed * MultipleGoldKills) *
            (int)(1 + playDate.LvWeapon * MultipleGoldLv);
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

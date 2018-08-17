using UnityEngine;
//using System;

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


    public int BasisHp = 100;
    public int MultipleHp = 10;
    public int HpLvMax = 50;
    public int AtkLvMax = 50;

    public float ToastTime = 1f;
    

    public int GetUpHpPay() {
        return BasisUpHp * (int)(JsonManager.playerData.basedata.LvHp* MultipleUpHp);
    }

    public int GetUpAtkPay() {
        return BasisUpAtk * (int)(JsonManager.playerData.basedata.LvWeapon * MultipleUpAtk);
    }

    public int CountScoreAdd() {
        return BasisScoreMax + (int)(1 + JsonManager.playerData.basedata.LvWeapon * MultipleScoreLv);
    }

    public int GetUpHp() {
        return 1*(BasisHp + (JsonManager.playerData.basedata.LvHp - 1) * MultipleHp);
    }   

    
    void OnGUI(){
		//GUI.Label(new Rect(20,20,300,30),"Kills "+Score);
	}




}

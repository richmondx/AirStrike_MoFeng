using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightManager : MonoBehaviour {

    public int Killed;
    public int Score;
    public int GetGold;
    public int Ranking;

    private GameUI gameUI;

    // Use this for initialization
    void Start () {
        ClearDate();
        gameUI = (GameUI)FindObjectOfType(typeof(GameUI));
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void ClearDate()
    {
        Killed = 0;
        Score = 0;
        GetGold = 0;
    }

    // add score function
    public void AddKilled()
    {
        int GetScore = GameManager.Instance.CountScoreAdd();
        Score += GetScore;
        gameUI.ToastKill(GetScore);
        Killed += 1;
        GetGold = CountGold();
        Ranking = CountRanking();

    }
    private int CountGold()
    {
        return (Random.Range(1, GameManager.Instance.BasisGoldMax) + Killed * GameManager.Instance.MultipleGoldKills) *
            (int)(1 + JsonManager.playerData.basedata.LvWeapon * GameManager.Instance.MultipleGoldLv);
    }
    private int CountRanking()
    {
        return 1 * (1000 + (Killed * GameManager.Instance.MultipleRankKill) + 
            (JsonManager.playerData.basedata.LvWeapon * GameManager.Instance.MultipleRankLv) +
            Random.Range(0, (GameManager.Instance.MultipleRankRandomLv * JsonManager.playerData.basedata.LvWeapon)));
    }
    // game over fimction
    public void GameOver()
    {
        JsonManager.addGold(GetGold);
        if (gameUI)
        {
            gameUI.Mode = 1;
        }
    }
}

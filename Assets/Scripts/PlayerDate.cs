using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDate : MonoBehaviour {  

    public int LvWeapon { get;private set; }
    public int LvHp { get; private set; }
    public int Gold { get; private set; }
    private GameManager game;
    private GameUI gameUI;
    private void Start()
    {
        InitDate();
        game = (GameManager)GameObject.FindObjectOfType(typeof(GameManager));
        gameUI = (GameUI)GameObject.FindObjectOfType(typeof(GameUI));
    }

    void InitDate() {
        LvWeapon = 1;
        LvHp = 1;
        Gold = 500;
    }

    public void AddGold(int num) {
        Gold += num;
    }

    public bool PayGold(int Num) {
        if (Gold < Num) return false;
        else {
            Gold -= Num;
            return true;
        }
    }

    public void WeaponLvUp() {
        if (LvWeapon >= game.UpSkillLvMax) {
            gameUI.ShowLvIsMax();
            return;
        }
        if (PayGold(100)) LvWeapon++;
        else {
            gameUI.ShowGoldNotEnough();
        }
    }

    public void HpLvUp()
    {
        if (LvHp >= game.UpSkillLvMax) {
            gameUI.ShowLvIsMax();
            return;
        }
        if (PayGold(100)) LvHp++;
        else{
            gameUI.ShowGoldNotEnough();
        }
    }
}

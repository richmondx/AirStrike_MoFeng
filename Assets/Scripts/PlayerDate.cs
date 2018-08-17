using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDate : MonoBehaviour {

    private static PlayerDate instance;
    public static PlayerDate Instance
    {
        get
        {
            if (instance == null)
                instance = (PlayerDate)GameObject.FindObjectOfType(typeof(PlayerDate));
            return instance;
        }
        set { }
    }

    public int LvWeapon { get;private set; }
    public int LvHp { get; private set; }
    public int Gold;
    
    private void Start()
    {
        InitDate();
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
    public bool LvIsMaxHp() {
        if (LvHp < GameManager.Instance.HpLvMax) return false;
        else return true;

    }
    public bool LvIsMaxAtk()
    {
        if (LvWeapon < GameManager.Instance.AtkLvMax) return false;
        else return true;
    }
    public bool WeaponLvUp() {

        if (PayGold(GameManager.Instance.GetUpAtkPay())) {
            LvWeapon++;
            return true;
        }
        else {
            return false;
        }
    }

    public bool HpLvUp()
    {
        if (PayGold(GameManager.Instance.GetUpHpPay())) { 
            LvHp++;
            return true;
        }
        else{
            return false;
        }
    }
}

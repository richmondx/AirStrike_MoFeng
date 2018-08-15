using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDate : MonoBehaviour {  

    public int LevelWeapon { get;private set; }
    public int LevelHp { get; private set; }
    public int LevelWeaponMax { get; private set; }
    public int LevelHpMax { get; private set; }
    public int Gold { get; private set; }

    private void Start()
    {
        InitDate();
    }

    void InitDate() {
        LevelWeapon = 1;
        LevelHp = 1;
        LevelWeaponMax = 5;
        LevelHpMax = 5;
        Gold = 9999;
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
        if (PayGold(100)) LevelWeapon++;
        else {
            //提示错误
        }
    }

    public void HpLvUp()
    {
        if(PayGold(100)) LevelHp++;
        else{
            //提示错误
        }
    }
}

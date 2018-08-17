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
    

    public bool PayGold(int Num) {
        
        if (JsonManager.playerData.basedata.Gold < Num) return false;
        else {
            JsonManager.playerData.basedata.Gold -= Num;
            return true;
        }
        return true;
    }
    public bool LvIsMaxHp() {
        if (JsonManager.playerData.basedata.LvHp < GameManager.Instance.HpLvMax) return false;
        else return true;

    }
    public bool LvIsMaxAtk()
    {
        if (JsonManager.playerData.basedata.LvWeapon < GameManager.Instance.AtkLvMax) return false;
        else return true;
    }
    public bool WeaponLvUp() {

        if (PayGold(GameManager.Instance.GetUpAtkPay())) {
            JsonManager.addLvWeapon(1);
            return true;
        }
        else {
            return false;
        }
    }

    public bool HpLvUp()
    {
        if (PayGold(GameManager.Instance.GetUpHpPay())) {
            JsonManager.addLvHp(1);
            return true;
        }
        else{
            return false;
        }
    }
}

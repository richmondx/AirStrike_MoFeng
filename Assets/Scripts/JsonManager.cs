using UnityEngine;


[System.Serializable]
public class Basedata
{
    /// <summary>
    /// 10
    /// </summary>
    public int Gold;
    /// <summary>
    /// 1
    /// </summary>
    public int LvWeapon;
    /// <summary>
    /// 1
    /// </summary>
    public int LvHp;
}
[System.Serializable]
public class PlayerData
{
    /// <summary>
    /// Base
    /// </summary>
    public Basedata basedata;
}

public class JsonManager  {
    private static string Key = "the_player_data";
    private static string init_player_data = "{\"basedata\":{\"Gold\":\"10\",\"LvHp\":\"1\",\"LvWeapon\":\"1\"}}";

    public static PlayerData playerData = null;
    static JsonManager()
    {

        if (playerData == null)
        {
            if (PlayerPrefs.HasKey(Key))
            {
                string tempS = PlayerPrefs.GetString(Key);
                playerData = JsonUtility.FromJson<PlayerData>(tempS);
            }
            else
            {
                playerData = JsonUtility.FromJson<PlayerData>(init_player_data);
            }

        }
        SaveDate();
    }

    public static void SaveDate() {
        Debug.Log("JsonUtility.ToJson(playerData)===save===" + JsonUtility.ToJson(playerData));
        PlayerPrefs.SetString(Key, JsonUtility.ToJson(playerData));
    }

    public static void addGold(int value)
    {
        JsonManager.playerData.basedata.Gold = (JsonManager.playerData.basedata.Gold + value);
        SaveDate();
    }

    public static void addLvHp(int value)
    {
        JsonManager.playerData.basedata.LvHp = (JsonManager.playerData.basedata.LvHp + value);
        SaveDate();
    }
    public static void addLvWeapon(int value)
    {
        JsonManager.playerData.basedata.LvWeapon = (JsonManager.playerData.basedata.LvWeapon + value);
        SaveDate();
    }
}

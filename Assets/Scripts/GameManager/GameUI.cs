using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameUI : MonoBehaviour
{

	public GUISkin skin;
	public Texture2D Logo;
	public int Mode;
    public bool isUgui = false;
	private GameManager game;
	private PlayerController play;
	private WeaponController weapon;

    public Button btnPause;
    public Button btnRestartAndResume;
    public Button btnMainMenu;

    //死亡界面
    public Text textDeathKills;
    public Text textDeathScore;
    public Text textGetGold;

    public Text textArmorLv;
    public Text textWeaponLv;
    public Text textUpHpPay;
    public Text textUpAtkPay;
    public Text textDefectNum;
    public Text textGoldNum;

    //战斗界面
    public Text textKills;
    public Text textScore;
    public Text textHP;     

    public Slider sliderHP;
    public GameObject Toast;
    public Text toastText;
    public Button BtnAtk;
    public Button BtnChangeWeapon;
    public Text textAmmoNum;
    public GameObject planePause;
    public GameObject planeDeath;
    public GameObject planeGaming;
    public GameObject planePop;

    void Start ()
	{
		game = (GameManager)GameObject.FindObjectOfType (typeof(GameManager));
		play = (PlayerController)GameObject.FindObjectOfType (typeof(PlayerController));
        weapon = play.GetComponent<WeaponController> ();
        // define player
        if(isUgui) ShowUGUI();

    }
    /*    
    //异步加载场景
    IEnumerator LoadScene(string scene_name)
    {
        async_operation = SceneManager.LoadSceneAsync(scene_name);
        async_operation.allowSceneActivation = false;
        yield return async_operation;
    }*/
    void ShowUGUI() {
        planeGaming.SetActive(true);

        planePause.SetActive(false);
        planePause.SetActive(false);
        planePop.SetActive(false);
        planeDeath.SetActive(false);
    }
    private void Update()
    {
        if (isUgui) {            
            switch (Mode)
            {
                case 0:
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        OnPauseClick();
                    }

                    if (play)
                    {
                        //开始游戏
                        play.Active = true;
                        //显示战斗UI
                        //ShowUGUI();
                        //更新数据
                        textKills.text = game.Killed.ToString();
                        textScore.text = game.Score.ToString();

                        float hp = play.GetComponent<DamageManager>().HP / play.GetComponent<DamageManager>().HPmax;
                        sliderHP.value = hp;
                        textHP.text = hp * 100 + "%";

                        UpdateAmmo();
                    }
                    break;

                case 1://玩家死亡
                    if (play)
                        play.Active = false;
                    MouseLock.MouseLocked = false;
                    planeGaming.SetActive(false);
                    //显示死亡UI
                    ShowDeathUI();
                    break;

                case 2://暂停
                    if (play)
                        play.Active = false;
                    MouseLock.MouseLocked = false;
                    Time.timeScale = 0;

                    planeGaming.SetActive(false);
                    //显示暂停UI
                    ShowPauseUI();
                    break;
                case 3://AD
                    if (play)
                        play.Active = false;
                    MouseLock.MouseLocked = false;
                    Time.timeScale = 0;
                    planeGaming.SetActive(false);
                    planePop.SetActive(true);
                    break;
            }
        }
    }


    #region ADUI部分
    public void OnClosePop() {
        Debug.Log("This is Close");
        Mode = 0;
        Time.timeScale = 1;
        planePop.SetActive(false);
    }
    public void ShowPop() {
        Mode = 3;        
    }
    public void OnADClick() {
        Debug.Log("This is AD");
    }
    #endregion

    #region PuseUI部分
    private void ShowPauseUI()
    {        
        planePause.SetActive(true);
    }

    public void OnPauseClick()
    {
        Mode = 2;
    }
    #endregion

    #region DeathUI部分
    /// <summary>
    /// 显示死亡UI界面
    /// </summary>
    void ShowDeathUI()
    {
        planeDeath.SetActive(true);

        textGetGold.text = game.GetGold.ToString();
        textDeathKills.text = game.Killed.ToString();
        textDeathScore.text = game.Score.ToString();
        textDefectNum.text = game.Ranking.ToString();
        textGoldNum.text = PlayerDate.Instance.Gold.ToString();

        textWeaponLv.text = PlayerDate.Instance.LvWeapon.ToString();
        textArmorLv.text = PlayerDate.Instance.LvHp.ToString();
        textUpHpPay.text = game.GetUpHpPay(PlayerDate.Instance.LvHp).ToString();
        textUpAtkPay.text = game.GetUpAtkPay(PlayerDate.Instance.LvWeapon).ToString();    

    } 

    public void OnBackToMainMenuClick() {

        if (Mode == 2) {
            Mode = 0;
            Time.timeScale = 1;
        }
        //Application.LoadLevel("MainMenu");
        SceneManager.LoadScene("MainMenu");
    }

    public void OnGameGoClick(int type) {
        
        switch (type) {
            case 1:
                SceneManager.LoadScene(Application.loadedLevelName);
                break;
            case 2:
                Mode = 0;
                Time.timeScale = 1;
                ShowUGUI();
                break;
        }
    }
    public void OnUpWeaponClick() {        
            PlayerDate.Instance.WeaponLvUp();
            ShowDeathUI();       
    }
    public void OnUpArmorClick() {
            PlayerDate.Instance.HpLvUp();
            ShowDeathUI();      
    }
    public void ShowLvIsMax() {
        Toast.SetActive(true);
        toastText.text = "等级已经满了";
    }
    public void ShowGoldNotEnough()
    {
        Toast.SetActive(true);
        toastText.text = "金币不足";
    }
    public void OnToastOkClick() {
        Toast.SetActive(false);
    }
    #endregion

    #region WeaponButton   
    public void OnChangeWeapon()
    {
        weapon.SwitchWeapon();
        if (weapon.WeaponLists[weapon.CurrentWeapon].Icon)
            BtnAtk.image.sprite = weapon.WeaponLists[weapon.CurrentWeapon].Icon;

    }
    public void UpdateAmmo() {

        if (weapon.CurrentWeapon == 0) {
            textAmmoNum.text = "无限";
            return;
        }
            
        if (weapon.WeaponLists[weapon.CurrentWeapon].Ammo <= 0 && weapon.WeaponLists[weapon.CurrentWeapon].ReloadingProcess > 0)
        {
            textAmmoNum.text = "Reloading " + Mathf.Floor((1 - weapon.WeaponLists[weapon.CurrentWeapon].ReloadingProcess) * 100) + "%";
        }
        else
        {
            if (!weapon.WeaponLists[weapon.CurrentWeapon].InfinityAmmo)
                textAmmoNum.text = weapon.WeaponLists[weapon.CurrentWeapon].Ammo.ToString();
        }
    }
    #endregion


    #region GUI部分
    public void OnGUI ()
	{
        if (!isUgui) {
            planeGaming.SetActive(false);
            planePause.SetActive(false);
            if (skin)
                GUI.skin = skin;


            switch (Mode)
            {
                case 0:
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        Mode = 2;
                    }

                    if (play)
                    {

                        play.Active = true;

                        GUI.skin.label.alignment = TextAnchor.UpperLeft;
                        GUI.skin.label.fontSize = 30;
                        GUI.Label(new Rect(20, 20, 200, 50), "Kills " + game.Killed.ToString());
                        GUI.Label(new Rect(20, 60, 200, 50), "Score " + game.Score.ToString());
                                                
                        GUI.skin.label.alignment = TextAnchor.UpperRight;
                        GUI.Label(new Rect(Screen.width - 220, 20, 200, 50), "ARMOR " + play.GetComponent<DamageManager>().HP);
                        GUI.skin.label.fontSize = 16;

                        // Draw Weapon system
                        //if (weapon != null && weapon.WeaponLists.Length > 0 && weapon.WeaponLists.Length < weapon.CurrentWeapon && weapon.WeaponLists [weapon.CurrentWeapon] != null) {
                        if (weapon.WeaponLists[weapon.CurrentWeapon].Icon)
                            GUI.DrawTexture(new Rect(Screen.width - 200, Screen.height - 200, 160, 160), weapon.WeaponLists[weapon.CurrentWeapon]._Icon);

                        GUI.skin.label.alignment = TextAnchor.UpperRight;
                        if (weapon.WeaponLists[weapon.CurrentWeapon].Ammo <= 0 && weapon.WeaponLists[weapon.CurrentWeapon].ReloadingProcess > 0)
                        {
                            if (!weapon.WeaponLists[weapon.CurrentWeapon].InfinityAmmo)
                                GUI.Label(new Rect(Screen.width - 230, Screen.height - 120, 200, 30), "Reloading " + Mathf.Floor((1 - weapon.WeaponLists[weapon.CurrentWeapon].ReloadingProcess) * 100) + "%");
                        }
                        else
                        {
                            if (!weapon.WeaponLists[weapon.CurrentWeapon].InfinityAmmo)
                                GUI.Label(new Rect(Screen.width - 230, Screen.height - 120, 200, 30), weapon.WeaponLists[weapon.CurrentWeapon].Ammo.ToString());
                        }
                        //}else{
                        //weapon = play.GetComponent<WeaponController> ();
                        //}

                        GUI.skin.label.alignment = TextAnchor.UpperLeft;
                        GUI.Label(new Rect(20, Screen.height - 50, 250, 30), "R Mouse : Switch Guns  C : Change Camera");

                    }
                    else
                    {
                        play = (PlayerController)GameObject.FindObjectOfType(typeof(PlayerController));
                        weapon = play.GetComponent<WeaponController>();
                    }
                    break;
                case 1:
                    if (play)
                        play.Active = false;

                    MouseLock.MouseLocked = false;

                    GUI.skin.label.alignment = TextAnchor.MiddleCenter;
                    GUI.Label(new Rect(0, Screen.height / 2 + 10, Screen.width, 30), "Game Over");

                    GUI.DrawTexture(new Rect(Screen.width / 2 - Logo.width / 2, Screen.height / 2 - 150, Logo.width, Logo.height), Logo);

                    if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 50, 300, 40), "Restart"))
                    {
                        Application.LoadLevel(Application.loadedLevelName);

                    }
                    if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 100, 300, 40), "Main menu"))
                    {
                        Application.LoadLevel("Mainmenu");
                    }
                    break;

                case 2:
                    if (play)
                        play.Active = false;
                    MouseLock.MouseLocked = false;
                    Time.timeScale = 0;
                    GUI.skin.label.alignment = TextAnchor.MiddleCenter;
                    GUI.Label(new Rect(0, Screen.height / 2 + 10, Screen.width, 30), "Pause");

                    GUI.DrawTexture(new Rect(Screen.width / 2 - Logo.width / 2, Screen.height / 2 - 150, Logo.width, Logo.height), Logo);

                    if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 50, 300, 40), "Resume"))
                    {
                        Mode = 0;
                        Time.timeScale = 1;
                    }
                    if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 100, 300, 40), "Main menu"))
                    {
                        Time.timeScale = 1;
                        Mode = 0;
                        Application.LoadLevel("Mainmenu");
                    }
                    break;

            }
        }
		
		
	}
    #endregion
}

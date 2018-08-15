using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour {

	public GUISkin skin;
	public Texture2D Logo;

    public GameObject planeMainMenu;
    public GameObject planeShopping;
    public GameObject planeAD;
    public GameObject planeChangeAir;
    public GameObject planePOPUp;
    public bool isUGUI = true;
    public bool OpenPop = true;

	void Start () {
        if (isUGUI)
        {
            OnBackToMainClick();
            if(OpenPop) ShowPOP();
        }

    }
	
	void Update () {
	
	}
    void ShowPOP() {
        planePOPUp.SetActive(true);
        textPOP.text = strPOP[0];
    }
    #region MainMenuUI
    public void OnBeginGameClick() {
        SceneManager.LoadScene("Modern");
        //Application.LoadLevel("Modern");
    }
    public void OnChangeAirClick() {
        planeMainMenu.SetActive(false);
        planeChangeAir.SetActive(true);
    }
    public void OnShoppingClick() {
        planeMainMenu.SetActive(false);
        planeShopping.SetActive(true);
    }
    public void OnShowADClick() {
        planeMainMenu.SetActive(false);
        planeAD.SetActive(true);
    }
    public void OnMusicClick(){

    }
    public void OnBackToMainClick(){
        planeMainMenu.SetActive(false);
        planeShopping.SetActive(false);
        planeAD.SetActive(false);
        planeChangeAir.SetActive(false);
        planePOPUp.SetActive(false);
        planeMainMenu.SetActive(true);
    }
    #endregion


    #region ChangeAirUI


    #endregion

    #region ShoppingUI
    public void OnBuyGoldClick() {

    }

    #endregion

    #region ADUI

    #endregion

    #region POPupUI
    public Text textPOP;
    public Text textBuy;
    public Button btnBGBuy;
    public GameObject btnX;
    public string[] strPOP = { "", "", "" };
    int POPTextNum = 1;

    public void OnNextBtnClick() {
        if (POPTextNum <= strPOP.Length - 1)
        {
            textPOP.text = strPOP[POPTextNum];
            if (POPTextNum == strPOP.Length - 1)
            {
                textBuy.text = "观看广告";
                btnX.SetActive(true);
                btnBGBuy.onClick.AddListener(OnBuyClick);
            }
            POPTextNum++;
        }
        else if (POPTextNum > strPOP.Length - 1) {
            OnBuyClick();
        }
    }

    public void OnXBtnClick() {
        OnBackToMainClick();
    }
    /// <summary>
    /// 误操作触发
    /// </summary>
    public void OnBuyClick() {
        Debug.Log("Buy");
    }
    #endregion

    
	public void OnGUI(){
        if (!isUGUI)
        {
            if (skin)
                GUI.skin = skin;

            GUI.DrawTexture(new Rect(Screen.width / 2 - Logo.width / 2, Screen.height / 2 - 150, Logo.width, Logo.height), Logo);

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 50, 300, 40), "Classic"))
            {
                Application.LoadLevel("Classic");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 100, 300, 40), "Modern"))
            {

                SceneManager.LoadScene("Modern");
                //Application.LoadLevel("Modern");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 150, 300, 40), "Invasion"))
            {
                Application.LoadLevel("Invasion");
            }

            GUI.skin.label.alignment = TextAnchor.MiddleCenter;
            GUI.Label(new Rect(0, Screen.height - 90, Screen.width, 50), "Air strike starter kit. by Rachan Neamprasert\n www.hardworkerstudio.com");
        }
    }
}

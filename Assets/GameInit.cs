using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameInit : MonoBehaviour {

    public GameObject PlayerDate;
    public Slider slider;
    private AsyncOperation async_operation;
    private int curProgressVaule = 0;//计数器

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(PlayerDate);
        StartCoroutine(LoadScene("Mainmenu"));
    }

    //异步加载场景
    IEnumerator LoadScene(string scene_name)
    {
        async_operation = SceneManager.LoadSceneAsync(scene_name);
        async_operation.allowSceneActivation = false;
        yield return async_operation;
    } 
    
    // Update is called once per frame
    void Update () {

        if (async_operation == null)
        {
            return;
        }

        int progressVaule = 0;

        if (async_operation.progress < 0.9f)
        {
            progressVaule = (int)async_operation.progress * 100;
        }
        else
        {
            progressVaule = 100;
        }

        if (curProgressVaule < progressVaule)
        {
            curProgressVaule++;
        }
        slider.value = progressVaule;
        /*
         * text.text = curProgressVaule + "%";
         * progressImg.fillAmount = curProgressVaule/100f;
        */
        if (curProgressVaule == 100)
        {
            async_operation.allowSceneActivation = true;
        }


    }
}

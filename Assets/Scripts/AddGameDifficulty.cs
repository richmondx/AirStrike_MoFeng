using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGameDifficulty : MonoBehaviour {

    public float timePOPShow = 60;
    public float timeAddDif = 20;
    public float timeEndGame = 120;

    float timeF;
    int timeI;
    private void Update()
    {
        timeF = Time.time;
        timeI = Mathf.FloorToInt(timeF);
        //Debug.Log(timeI);
    }
}

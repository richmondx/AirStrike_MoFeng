using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToastKill : MonoBehaviour {
    public float time = 0;

	// Use this for initialization
	void Start () {        
        Destroy(this.gameObject,GameManager.Instance.ToastTime);
    }
    public void SetText(string text) {
        GetComponent<Text>().text = text;
    }
	// Update is called once per frame
	void Update () {
            
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toast : MonoBehaviour {

    public void CloseToast() {
        Destroy(this.gameObject);
    }
    public void SetText(string text) {
        GetComponentInChildren<Text>().text = text;
    }
}

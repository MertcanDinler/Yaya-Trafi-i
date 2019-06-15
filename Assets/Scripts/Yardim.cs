#pragma warning disable 0649
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Yardim : MonoBehaviour {
    [SerializeField]
    ScrollRect scroll;
    // Start is called before the first frame update
    private void Awake () {
        scroll.verticalNormalizedPosition = 1;
    }

    public void Geri () {
        Yonetici.Instance.sahne.Baslangic ();
    }
}
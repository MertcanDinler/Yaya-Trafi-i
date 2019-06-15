#pragma warning disable 0649
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeviyeSec : MonoBehaviour {
    [SerializeField]
    Button[] seviyeler;
    [SerializeField]
    Text uyari;

    void Awake () {
        print (Yonetici.Instance.ayarlar.bitirilenSeviye);
        for (int i = 0; i < seviyeler.Length; i++) {
            ColorBlock color = seviyeler[i].colors;
            if (i <= Yonetici.Instance.ayarlar.bitirilenSeviye) {
                color.normalColor = Color.white;
                color.highlightedColor = Color.white;
            } else {
                color.normalColor = Color.red;
                color.highlightedColor = Color.red;
            }
            seviyeler[i].colors = color;
        }
    }
    public void Baslat (int seviye) {
        if (Yonetici.Instance.ayarlar.bitirilenSeviye + 1 >= seviye) {
            Yonetici.Instance.sahne.Seviye (seviye);
        } else {
            Uyari ();
        }
    }

    void Uyari () {
        uyari.text = "Bu seviyeyi oynayabilmek için önceki seviyeyi bitirmeniz gerekiyor.";
        Invoke ("UyariSil", 5);
    }

    void UyariSil () {
        uyari.text = "";
    }
}
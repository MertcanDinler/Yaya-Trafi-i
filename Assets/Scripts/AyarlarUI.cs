#pragma warning disable 0649
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AyarlarUI : MonoBehaviour {
    [SerializeField]
    Button karakter1;
    [SerializeField]
    Button karakter2;

    [SerializeField]
    Button aracSesi;
    [SerializeField]
    Button arkaplanMuzik;
    private void Start () {
        KarakterRenkGuncelle ();
    }

    public void KarakterSec (int karakter) {
        Yonetici.Instance.ayarlar.karakter = karakter;
        KarakterRenkGuncelle ();
        ColorBlock colors = aracSesi.colors;
        colors.normalColor = Yonetici.Instance.ayarlar.aracSesi ? Color.green : Color.white;
        colors.highlightedColor = Yonetici.Instance.ayarlar.aracSesi ? Color.green : Color.white;
        aracSesi.colors = colors;
        ColorBlock colors2 = arkaplanMuzik.colors;
        colors2.normalColor = Yonetici.Instance.ayarlar.arkaPlanMuzik ? Color.green : Color.white;
        colors2.highlightedColor = Yonetici.Instance.ayarlar.arkaPlanMuzik ? Color.green : Color.white;
        arkaplanMuzik.colors = colors2;

    }

    public void AracSesiAcKapa () {
        Yonetici.Instance.ayarlar.aracSesi = !Yonetici.Instance.ayarlar.aracSesi;
        ColorBlock colors = aracSesi.colors;
        colors.normalColor = Yonetici.Instance.ayarlar.aracSesi ? Color.green : Color.white;
        colors.highlightedColor = Yonetici.Instance.ayarlar.aracSesi ? Color.green : Color.white;
        aracSesi.colors = colors;

    }
    public void ArkaplanMuzikAcKapa () {
        Yonetici.Instance.ayarlar.arkaPlanMuzik = !Yonetici.Instance.ayarlar.arkaPlanMuzik;
        ColorBlock colors = arkaplanMuzik.colors;
        colors.normalColor = Yonetici.Instance.ayarlar.arkaPlanMuzik ? Color.green : Color.white;
        colors.highlightedColor = Yonetici.Instance.ayarlar.arkaPlanMuzik ? Color.green : Color.white;
        arkaplanMuzik.colors = colors;
    }

    public void Kaydet () {
        Yonetici.Instance.sahne.Baslangic ();
    }

    void KarakterRenkGuncelle () {
        if (Yonetici.Instance.ayarlar.karakter == 1) {
            ColorBlock colors = karakter1.colors;
            colors.normalColor = Color.green;
            colors.highlightedColor = Color.green;
            karakter1.colors = colors;
            colors.highlightedColor = Color.white;
            colors.normalColor = Color.white;
            karakter2.colors = colors;
        } else if (Yonetici.Instance.ayarlar.karakter == 2) {
            ColorBlock colors = karakter2.colors;
            colors.normalColor = Color.green;
            colors.highlightedColor = Color.green;
            karakter2.colors = colors;
            colors.highlightedColor = Color.white;
            colors.normalColor = Color.white;
            karakter1.colors = colors;
        }
    }
}
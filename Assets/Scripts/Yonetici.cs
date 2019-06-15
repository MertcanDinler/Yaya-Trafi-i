using System;
using UnityEngine;
public class Yonetici {
    /* SINGLETON */
    static Yonetici _instance;
    public static Yonetici Instance {
        get {
            if (_instance == null) {
                _instance = new Yonetici ();
            }
            return _instance;
        }
    }
    /* SINGLETON */
    private Yonetici () { }
    public bool mola = false;
    public int oynananSeviye = 0;
    public bool karakterSecVeGit = true;
    public readonly Sahne sahne = new Sahne ();
    public readonly Ayarlar ayarlar = new Ayarlar ();
    public readonly Skor skor = new Skor ();
    
}
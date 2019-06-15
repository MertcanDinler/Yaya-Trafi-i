using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Level2 : Level {
    public IsikYaya isikYaya;
    public int kirmiziSure;
    public int yesilSure;
    protected override void StartImpl () {
        StartCoroutine ("LambaKontrol");
    }

    private IEnumerator LambaKontrol () {
        while (true) {
            isikYaya.Kirmizi ();
            yield return new WaitForSeconds (kirmiziSure);
            isikYaya.Yesil ();
            yield return new WaitForSeconds (yesilSure);
        }

    }
    protected override void KarakterOdulAlincaImpl (GameObject odul) {
        Yonetici.Instance.skor.Suan += 10;
        Destroy (odul);
    }

    protected override void KarakterYolaCikincaImpl () {
        Yonetici.Instance.sahne.TekrarDene ();
    }

    protected override void KarakterYayaYoluncaCikincaImpl () {
        if (isikYaya.durum == 0) {
            Yonetici.Instance.sahne.TekrarDene ();
        }
    }
}
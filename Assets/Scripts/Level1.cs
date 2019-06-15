using UnityEngine;
public class Level1 : Level {
    protected override void KarakterOdulAlincaImpl (GameObject odul) {
        Yonetici.Instance.skor.Suan += 10;
        Destroy (odul);
    }
    protected override void KarakterYolaCikincaImpl () {
        Yonetici.Instance.sahne.TekrarDene ();
    }
}
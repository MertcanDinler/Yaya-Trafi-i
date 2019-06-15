using UnityEngine;
public class Baslangic : MonoBehaviour {
    public void Baslat () {
        Yonetici.Instance.sahne.SeviyeSec ();
    }

    public void Yardim () {
        Yonetici.Instance.sahne.Yardim ();
    }

    public void Hakkinda () {
        Yonetici.Instance.sahne.Hakkinda ();
    }

    public void Ayarlar () {
        Yonetici.Instance.sahne.Ayarlar ();
    }
}
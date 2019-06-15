using System.Reflection;
using UnityEngine;
public class TekrarDene : MonoBehaviour {
    public void Tekrar () {
        Yonetici.Instance.sahne.Seviye(Yonetici.Instance.oynananSeviye);
    }
    public void AnaMenu () {
        Yonetici.Instance.sahne.Baslangic ();
    }
}
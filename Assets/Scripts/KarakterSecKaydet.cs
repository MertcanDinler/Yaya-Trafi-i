using UnityEngine;
public class KarakterSecKaydet : MonoBehaviour {
    private void OnMouseDown () {
        if (Yonetici.Instance.karakterSecVeGit) {
            Yonetici.Instance.sahne.Baslangic ();
        } else {
            Yonetici.Instance.sahne.Seviye (1);
        }
    }
}
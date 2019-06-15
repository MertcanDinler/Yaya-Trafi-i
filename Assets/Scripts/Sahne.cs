using UnityEngine.SceneManagement;
public class Sahne {
    public void Baslangic () {
        SceneManager.LoadScene ("Baslangic");
    }
    public void KarakterSec () {
        SceneManager.LoadScene ("KarakterSec");
    }
    public void Tebrikler () {
        SceneManager.LoadScene ("Tebrikler");
    }
    public void TekrarDene () {
        SceneManager.LoadScene ("TekrarDene");
    }

    public void Yardim () {
        SceneManager.LoadScene ("Yardim");
    }

    public void Hakkinda () {
        SceneManager.LoadScene ("Hakkinda");
    }

    public void Ayarlar () {
        SceneManager.LoadScene ("Ayarlar");
    }

    public void SeviyeSec () {
        SceneManager.LoadScene ("SeviyeSec");
    }
    public void Seviye (int no) {
        Yonetici.Instance.oynananSeviye = no;
        Yonetici.Instance.skor.SeviyeDegis ();
        SceneManager.LoadScene ("Level" + no.ToString ());
    }
}
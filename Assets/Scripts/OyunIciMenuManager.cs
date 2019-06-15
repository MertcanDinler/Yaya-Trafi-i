using UnityEngine;
using UnityEngine.UI;
public class OyunIciMenuManager : MonoBehaviour {
    public string Baslik;
    [TextArea]
    public string Aciklama;
    public Text baslikObj;
    public Text aciklamaObj;
    public GameObject infoPanel;
    public GameObject escMenu;
    public GameObject skorPanel;
    public Text skor;
    public Text enYuksekSkor;
    void Start () {
        baslikObj.text = Baslik;
        aciklamaObj.text = Aciklama;
        infoPanel.SetActive (true);
        escMenu.SetActive (false);
        skorPanel.SetActive (false);
        skor.text = "0";
        enYuksekSkor.text = Yonetici.Instance.skor.EnYuksek.ToString ();
        Yonetici.Instance.skor.skorDegisince = skorDegisince;
        Yonetici.Instance.mola = true;
    }
    void Update () {
        handleEsc ();
    }
    public void KillMe () {
        Destroy (gameObject);
    }
    public void hideInfo () {
        infoPanel.SetActive (false);
        skorPanel.SetActive (true);
        Yonetici.Instance.mola = false;
    }
    void handleEsc () {
        if (Input.GetKeyDown (KeyCode.Escape) && !infoPanel.activeSelf) {
            skorPanel.SetActive (escMenu.activeSelf);
            escMenu.SetActive (!escMenu.activeSelf);
            Yonetici.Instance.mola = escMenu.activeSelf;
        }
    }
    public void hideEscMenu () {
        escMenu.SetActive (false);
        skorPanel.SetActive (true);
        Yonetici.Instance.mola = false;
    }
    public bool skorDegisince (int yeniSkor, int enYuksek) {
        skor.text = yeniSkor.ToString ();
        enYuksekSkor.text = enYuksek.ToString ();
        return true;
    }
    private void OnDestroy () {
        Yonetici.Instance.skor.skorDegisince = null;
    }
}
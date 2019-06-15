using UnityEngine;
public abstract class Level : MonoBehaviour, ILevel {
    public int Seviye => Yonetici.Instance.oynananSeviye;
    AudioSource ses;
    void Start () {
        GameObject a =  Resources.Load<GameObject> ("Prefabs/OdulSes") as GameObject;
        a = Instantiate(a, Vector3.zero, new Quaternion());
        ses = a.GetComponent<AudioSource>();
        KarakterOlustur ();
        StartImpl ();
    }
    void Update () {
        UpdateImpl ();
    }
    public void KarakterYolaCikinca () {
        KarakterYolaCikincaImpl ();
    }
    public void KarakterKaldirimKenarinaGelince () {
        KarakterKaldirimKenarinaGelinceImpl ();
    }
    public void KarakterYayaYolunaCikinca () {
        KarakterYayaYoluncaCikincaImpl ();
    }
    public void KarakterOdulAlinca (GameObject odul) {
        //odul.gameObject.GetComponent<Seker>().ses.Play();
        ses.Play();
        KarakterOdulAlincaImpl (odul);
    }
    public void KarakterBitiseGelince () {
        KarakterBitiseGelinceImpl ();
        Yonetici.Instance.mola = true;
        Yonetici.Instance.sahne.Tebrikler ();
        Yonetici.Instance.ayarlar.bitirilenSeviye = Seviye;
    }
    void KarakterOlustur () {
        Vector2 baslamaNoktasi = GameObject.Find ("BaslangicNoktasi").transform.position;
        int _karakter = Yonetici.Instance.ayarlar.karakter;
        GameObject karakter = Resources.Load<GameObject> ("Prefabs/karakter" + _karakter) as GameObject;
        karakter.transform.localScale = new Vector3 (.3f, .3f, .3f);
        Instantiate (karakter, baslamaNoktasi, new Quaternion ());
    }

    public void AracIsikBolgesineGelince (GameObject arac) {
        AracIsikBolgesineGelinceImpl (arac);
    }

    public void AracIsikBolgesindeyse (GameObject arac) {
        AracIsikBolgesindeyseImpl (arac);
    }

    public void AracIsikBolgesindenCikinca (GameObject arac) {
        AracIsikBolgesindenCikincaImpl (arac);
    }
    protected void OnDestroy () {
        print ("asd");
        StopAllCoroutines ();
    }
    protected virtual void StartImpl () { }
    protected virtual void UpdateImpl () { }
    protected virtual void KarakterYolaCikincaImpl () { }
    protected virtual void KarakterKaldirimKenarinaGelinceImpl () { }
    protected virtual void KarakterYayaYoluncaCikincaImpl () { }
    protected virtual void KarakterOdulAlincaImpl (GameObject odul) { }
    protected virtual void KarakterBitiseGelinceImpl () { }

    protected virtual void AracIsikBolgesineGelinceImpl (GameObject arac) { }
    protected virtual void AracIsikBolgesindeyseImpl (GameObject arac) { }

    protected virtual void AracIsikBolgesindenCikincaImpl (GameObject arac) { }
}
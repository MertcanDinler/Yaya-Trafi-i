#pragma warning disable 0649
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Level3 : Level {
    [SerializeField]
    IsikYaya isikYaya;
    [SerializeField]
    int aracKirmiziSure;

    [SerializeField]
    int aracSariSure;
    [SerializeField]
    int aracYesilSure;
    [SerializeField]
    IsikArac[] isikArac1;

    [SerializeField]
    Transform aracBaslamaNoktasiSag;
    [SerializeField]
    Transform aracBaslamaNoktasiSol;
    List<GameObject> araclar = new List<GameObject> ();
    GameObject aracSag;
    GameObject aracSol;

    protected override void StartImpl () {
        araclar.Add (Resources.Load<GameObject> ("Prefabs/arac1"));
        araclar.Add (Resources.Load<GameObject> ("Prefabs/arac2"));
        araclar.Add (Resources.Load<GameObject> ("Prefabs/arac3"));
        araclar.Add (Resources.Load<GameObject> ("Prefabs/arac4"));
        StartCoroutine ("LambaKontrol");
    }

    private IEnumerator LambaKontrol () {
        while (true) {
            aracUret ();
            aracLamba ("Kirmizi");
            isikYaya.Yesil ();
            yield return new WaitForSeconds (aracKirmiziSure - aracSariSure * 2);
            isikYaya.Kirmizi ();
            yield return new WaitForSeconds (aracSariSure);
            aracLamba ("Sari");
            yield return new WaitForSeconds (aracSariSure);
            aracLamba ("Yesil");
            aracUret ();
            yield return new WaitForSeconds (aracYesilSure);
            aracLamba ("Sari");
            yield return new WaitForSeconds (aracSariSure);
            aracLamba ("Kirmizi");
            yield return new WaitForSeconds (aracSariSure);
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

    protected override void AracIsikBolgesineGelinceImpl (GameObject arac) {
        if (isikArac1[0].durum < 2)
            arac.GetComponent<Arac> ()?.Stop ();
    }

    protected override void AracIsikBolgesindeyseImpl (GameObject arac) {
        if (isikArac1[0].durum == 2) {
            Arac a = arac.GetComponent<Arac> ();
            a.Run (a.characterRotation);
        }
    }

    void aracLamba (string durum) {
        foreach (IsikArac isik in isikArac1) {
            isik.DurumDegistir (durum);
        }
    }

    void aracUret () {
        aracSag = araclar[Random.Range (0, araclar.Count)];
        aracSol = araclar[Random.Range (0, araclar.Count)];
        aracSag.transform.localScale = new Vector3 (.4f, .4f, .4f);
        aracSol.transform.localScale = new Vector3 (.4f, .4f, .4f);
        aracSag = Instantiate (aracSag, aracBaslamaNoktasiSag.position, new Quaternion ());
        aracSol = Instantiate (aracSol, aracBaslamaNoktasiSol.position, new Quaternion ());
        aracSag.GetComponent<Arac> ()?.Run (CharacterRotation.LEFT);
        aracSol.GetComponent<Arac> ()?.Run (CharacterRotation.RIGHT);
    }
}
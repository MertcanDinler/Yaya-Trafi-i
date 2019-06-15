#pragma warning disable 0649
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class IsikArac : MonoBehaviour {
    [SerializeField]
    Sprite kirmizi;
    [SerializeField]
    Sprite sari;
    [SerializeField]
    Sprite yesil;
    int _durum = 0;
    public int durum {
        get {
            return _durum;
        }
        private set {
            _durum = value;
        }
    }

    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer> ();
        Kirmizi ();
    }

    public void Kirmizi () {
        spriteRenderer.sprite = kirmizi;
        durum = 0;
    }
    public void Sari () {
        spriteRenderer.sprite = sari;
        durum = 1;
    }
    public void Yesil () {
        spriteRenderer.sprite = yesil;
        durum = 2;
    }

    public void DurumDegistir (string renk) {
        Invoke (renk, 0);
    }
}
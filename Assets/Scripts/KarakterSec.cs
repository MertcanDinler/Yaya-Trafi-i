using UnityEngine;
public class KarakterSec : MonoBehaviour {
    public int karakter = 0;
    public SpriteRenderer buSpriteRenderer;
    public SpriteRenderer digerSpriteRenderer;
    void Start () {
        if (Yonetici.Instance.ayarlar.karakter == karakter) {
            buSpriteRenderer.color = Color.green;
            digerSpriteRenderer.color = Color.white;
        }
    }
    private void OnMouseDown () {
        Yonetici.Instance.ayarlar.karakter = karakter;
        buSpriteRenderer.color = Color.green;
        digerSpriteRenderer.color = Color.white;
    }
}
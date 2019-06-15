#pragma warning disable 0649
using UnityEngine;
public class Seker : MonoBehaviour {
    public Sprite yesil;
    public Sprite kirmizi;
    SpriteRenderer spriteRenderer;
    int rotateFPS = 1;
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer> ();
        Yesil ();
    }
    void Update () {
        if (Yonetici.Instance.mola) {
            return;
        }
        rotateFPS++;
        if (rotateFPS % 4 == 0) {
            gameObject.transform.Rotate (new Vector2 (0, transform.rotation.y + 10));
            rotateFPS = 1;
        }
    }
    public void Yesil () {
        spriteRenderer.sprite = yesil;
    }
    public void Kirmizi () {
        spriteRenderer.sprite = kirmizi;
    }
}
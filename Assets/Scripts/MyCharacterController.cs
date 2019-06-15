using System.Collections;
using UnityEngine;
public enum CharacterRotation {
    TOP,
    RIGHT,
    BOTTOM,
    LEFT
}
public class MyCharacterController : MonoBehaviour {
    SpriteRenderer spriteRenderer;
    CharacterRotation characterRotation = CharacterRotation.TOP;
    Vector2 moveDirection = Vector3.zero;
    int animationCounter = 0;
    bool animationPlaying = false;
    Level level;
    public Sprite[] animationSprites;
    public Sprite stoppedSprite;
    // Start is called before the first frame update
    void Start () {
        level = FindObjectOfType<Level> ();
        spriteRenderer = GetComponent<SpriteRenderer> ();
        spriteRenderer.sprite = stoppedSprite;
    }
    // Update is called once per frame
    void Update () {
        if (Yonetici.Instance.mola) {
            return;
        }
        HandleKeyInput ();
    }
    void HandleKeyInput () {
        if (Input.anyKey) {
            if (Input.GetKey (KeyCode.UpArrow)) {
                Rotate (CharacterRotation.TOP);
                PlayAnimation ();
                moveDirection = transform.TransformDirection (Vector2.up);
                transform.Translate (moveDirection * Time.deltaTime);
            } else if (Input.GetKey (KeyCode.RightArrow)) {
                Rotate (CharacterRotation.RIGHT);
                PlayAnimation ();
                moveDirection = transform.TransformDirection (Vector2.left);
                transform.Translate (moveDirection * Time.deltaTime);
            } else if (Input.GetKey (KeyCode.DownArrow)) {
                Rotate (CharacterRotation.BOTTOM);
                PlayAnimation ();
                moveDirection = transform.TransformDirection (Vector3.down);
                transform.Translate (moveDirection * Time.deltaTime);
            } else if (Input.GetKey (KeyCode.LeftArrow)) {
                Rotate (CharacterRotation.LEFT);
                PlayAnimation ();
                moveDirection = transform.TransformDirection (Vector3.right);
                transform.Translate (moveDirection * Time.deltaTime);
            }
        } else {
            StopAnimation ();
        }
    }
    IEnumerator Animate () {
        while (true) {
            int selectSprite = animationCounter % animationSprites.Length;
            spriteRenderer.sprite = animationSprites[selectSprite];
            animationCounter++;
            if (animationCounter == animationSprites.Length) animationCounter = 0;
            yield return new WaitForSeconds (.3f);
        }
    }
    void PlayAnimation () {
        if (!animationPlaying) {
            animationPlaying = true;
            StartCoroutine ("Animate");
        }
    }
    void StopAnimation () {
        if (animationPlaying) {
            StopCoroutine ("Animate");
            spriteRenderer.sprite = stoppedSprite;
            animationPlaying = false;
        }
    }
    public void Rotate (CharacterRotation characterRotation) {
        if (this.characterRotation != characterRotation) {
            int rotationDegree = ((int) this.characterRotation - (int) characterRotation) * 90;
            this.characterRotation = characterRotation;
            gameObject.transform.Rotate (0, 0, rotationDegree);
        }
    }
    private void OnCollisionEnter2D (Collision2D collision) {
        switch (collision.gameObject.tag) {
            case "Odul":
                level.KarakterOdulAlinca (collision.gameObject);
                break;
            case "Yol":
                level.KarakterYolaCikinca ();
                break;
            case "YolYayaGecit":
                level.KarakterYayaYolunaCikinca ();
                break;
            case "KaldirimKenari":
                level.KarakterKaldirimKenarinaGelince ();
                break;
            case "Finish":
                level.KarakterBitiseGelince ();
                break;
            default:
                break;
        }
    }
}
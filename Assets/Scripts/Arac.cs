using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arac : MonoBehaviour {
    Level level;
    CharacterRotation _characterRotation = CharacterRotation.TOP;
    public CharacterRotation characterRotation {
        get {
            return _characterRotation;
        }
        private set {
            _characterRotation = value;
        }
    }
    Vector2 moveDirection = Vector3.zero;
    bool _isRunning = false;
    public float speed = 1.5f;
    public bool isRunning {
        get {
            return _isRunning;
        }
        private set {
            _isRunning = value;
        }
    }
    bool isikBolgesiniGectimi = false;
    private void Start () {
        speed = Random.Range (150, 300) / 100.0f;
        print (speed);
        level = FindObjectOfType<Level> ();
    }
    void Update () {
        if (Yonetici.Instance.mola) {
            return;
        }
        if (isRunning) {
            switch (characterRotation) {
                case CharacterRotation.TOP:
                    moveDirection = transform.TransformDirection (Vector2.up);
                    break;
                case CharacterRotation.RIGHT:
                    moveDirection = transform.TransformDirection (Vector2.left);
                    break;
                case CharacterRotation.BOTTOM:
                    moveDirection = transform.TransformDirection (Vector3.down);
                    break;
                case CharacterRotation.LEFT:
                    moveDirection = transform.TransformDirection (Vector3.right);
                    break;
                default:
                    break;
            }
            transform.Translate (moveDirection * Time.deltaTime * speed);
        }
    }

    public void Run (CharacterRotation rotate) {
        Rotate (rotate);
        isRunning = true;
    }

    public void Stop () {
        isRunning = false;
    }

    public void Rotate (CharacterRotation characterRotation) {
        if (this.characterRotation != characterRotation) {
            int rotationDegree = ((int) this.characterRotation - (int) characterRotation) * 90;
            this.characterRotation = characterRotation;
            gameObject.transform.Rotate (0, 0, rotationDegree);
        }
    }

    private void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "IsikBolgesi" || other.gameObject.tag == "Arac") {
            if (other.gameObject.tag == "Arac") {
                speed = other.gameObject.GetComponent<Arac> ().speed;
            }
            if (!isikBolgesiniGectimi)
                level.AracIsikBolgesineGelince (gameObject);
        }
    }
    private void OnCollisionStay2D (Collision2D other) {
        if (other.gameObject.tag == "IsikBolgesi" || other.gameObject.tag == "Arac") {
            level.AracIsikBolgesindeyse (gameObject);
            if (other.gameObject.tag == "IsikBolgesi") {
                isikBolgesiniGectimi = true;
            }
        }
    }
    private void OnCollisionExit2D (Collision2D other) {
        if (other.gameObject.tag == "IsikBolgesi") {
            level.AracIsikBolgesindenCikinca (gameObject);
        }
    }
}
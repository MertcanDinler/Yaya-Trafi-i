using System;
using UnityEngine;
public class Skor {
    int _enYuksek = 0;
    int _suan = 0;
    public Func<int, int, bool> skorDegisince;

    public int EnYuksek {
        get => _enYuksek;
        private set {
            _enYuksek = value;
            PlayerPrefs.SetInt ("enSkorSeviye" + Yonetici.Instance.oynananSeviye, value);
        }
    }
    public int Suan {
        get => _suan;
        set {
            if (value > EnYuksek) {
                EnYuksek = value;
            }
            _suan = value;
            skorDegisince?.Invoke (value, EnYuksek);
        }
    }
    public void SeviyeDegis () {
        Suan = 0;
        EnYuksek = PlayerPrefs.GetInt ("enSkorSeviye" + Yonetici.Instance.oynananSeviye, 0);
    }
}
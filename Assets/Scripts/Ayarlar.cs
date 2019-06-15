using UnityEngine;
public class Ayarlar {
    private int _karakter = 1;
    public int karakter {
        get => _karakter;
        set {
            _karakter = value;
            PlayerPrefs.SetInt ("karakter", value);
        }
    }
    private bool _arkaplanMuzik = true;
    public bool arkaPlanMuzik {
        get {
            return _arkaplanMuzik;
        }
        set {
            _arkaplanMuzik = value;
            PlayerPrefs.SetInt ("arkaplan", value ? 1 : 0);
        }
    }

    private bool _aracSesi = true;
    public bool aracSesi {
        get {
            return _aracSesi;
        }
        set {
            _aracSesi = value;
            PlayerPrefs.SetInt ("aracses", value ? 1 : 0);
        }
    }

    private int _bitirilenSeviye = 0;
    public int bitirilenSeviye {
        get {
            return _bitirilenSeviye;
        }
        set {
            _bitirilenSeviye = value;
            PlayerPrefs.SetInt ("bitirilen", value);
        }
    }
    public Ayarlar () {
        _karakter = PlayerPrefs.GetInt ("karakter", 1);
        _arkaplanMuzik = PlayerPrefs.GetInt ("arkaplan", 1) == 1 ? true : false;
        _aracSesi = PlayerPrefs.GetInt ("aracses", 1) == 1 ? true : false;
        _bitirilenSeviye = PlayerPrefs.GetInt ("bitirilen", 0);
    }
}
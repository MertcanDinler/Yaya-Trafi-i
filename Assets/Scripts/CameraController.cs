using UnityEngine;
[RequireComponent (typeof (Camera))]
public class CameraController : MonoBehaviour {
    private float DesignOrthographicSize;
    private float DesignAspect;
    private float DesignWidth;
    public float DesignAspectHeight;
    public float DesignAspectWidth;
    Camera myCamera;
    void Awake () {
        myCamera = GetComponent<Camera> ();
        DesignOrthographicSize = myCamera.orthographicSize;
        DesignAspect = DesignAspectHeight / DesignAspectWidth;
        DesignWidth = DesignOrthographicSize * DesignAspect;
        this.Resize ();
    }
    public void Resize () {
        float wantedSize = DesignWidth / myCamera.aspect;
        myCamera.orthographicSize = Mathf.Max (wantedSize,
            DesignOrthographicSize);
    }
}
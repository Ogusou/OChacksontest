
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SetCameraOnJack : UdonSharpBehaviour
{

    public Camera _JackCamera;

    void Start()
    {
        
    }

    public override void Interact()
    {
        _JackCamera.enabled = true;
    }
}


using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class JackCube : UdonSharpBehaviour
{
    public Camera _JackCamera;
    public Camera _JackCamera2;
    void Start()
    {
        
    }
     private void OnTriggerEnter(Collider other)
    {
          _JackCamera2.enabled = false;
          _JackCamera.enabled = true;
    }
}


using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.SDK3.Components;

public class Button : UdonSharpBehaviour
{
    public VRCObjectPool myPool;

    public bool IsSpawn = false;

    void Start()
    {
        IsSpawn = false;
    }

    public override void Interact()
    {
        for(int i=0; i<myPool.Pool.Length; i++)
        {
            myPool.TryToSpawn();
        }
        
        IsSpawn = false;
    }
}

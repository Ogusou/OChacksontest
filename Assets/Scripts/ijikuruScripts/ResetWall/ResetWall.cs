
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.SDK3.Components;

public class ResetWall : UdonSharpBehaviour
{
    // 壁のプール
    public VRCObjectPool mypool;
    // リセット用の真っ白なマテリアル
    public Material newMaterial;
    // 壁のレンダラー
    public Renderer wallRenderer;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // 真っ白のテクスチャを壁に適用
        wallRenderer.material = newMaterial;
        //壁収納
        for (int i=0; i < mypool.Pool.Length; i++)
        {
            Renderer targetRenderer = mypool.Pool[i].GetComponent<Renderer>();
            targetRenderer.material = newMaterial;
            mypool.Return(mypool.Pool[i]);
        }
        
    }
}

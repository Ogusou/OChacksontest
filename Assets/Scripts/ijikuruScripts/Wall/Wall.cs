
// using UdonSharp;
// using UnityEngine;
// using VRC.SDKBase;
// using VRC.Udon;

// public class Wall : UdonSharpBehaviour
// {
//     // アバターのシルエットをキャプチャするカメラ
//     public Camera captureCamera;
//     // 壁のレンダラー
//     public Renderer wallRenderer;
//     // レンダラーテクスチャ
//     public RenderTexture renderTexture;

//     // 半透明アバター用のテクスチャ
//     public RenderTexture TranslucentTexture;

//     // リセット用の真っ白なマテリアル
//     public Material newMaterial;

//     //アルファ反転用マテリアル
//     public Material invertAlphaMaterial;
//     //アルファ反転用レンダーテクスチャ
//     public RenderTexture targetTexture;

//     //壁移動の速度
//     public float velocity = 0.01f;


//     void Start()
//     {
        
//     }

//     void Update()
//     {
//         this.transform.Translate(0, 0, velocity);
//     }

//     public override void OnPlayerTriggerEnter(VRCPlayerApi player)
//     {
//         if (player != null && player.IsValid())
//         {
//             // 真っ白のテクスチャを壁に適用
//             wallRenderer.material = newMaterial;

//             // カメラにレンダーテクスチャを設定
//             captureCamera.targetTexture = renderTexture;

//             captureCamera.Render();

//             //アルファ反転処理
//             VRCGraphics.Blit(renderTexture, targetTexture, invertAlphaMaterial);

//             //反転したを壁のマテリアルに直接適用
//             wallRenderer.material.mainTexture = targetTexture;


//             // キャプチャしたテクスチャをquadのマテリアルに適用
//             quadRenderer.material.mainTexture = TranslucentTexture;
//             // カメラのターゲットテクスチャをリセット
//             //captureCamera.targetTexture = null;
//         }
//     }
// }
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Wall : UdonSharpBehaviour
{
    // アバターのシルエットをキャプチャするカメラ
    public Camera captureCamera;

    // 壁のレンダラー
    public Renderer wallRenderer;
    // レンダラーテクスチャ
    public RenderTexture renderTexture;

 // 半透明のアバター結果をキャプチャするカメラ
    public Camera AvatarResultcaptureCamera;
    // 半透明アバター用のテクスチャ
    public RenderTexture TranslucentTexture;

    // リセット用の真っ白なマテリアル
    public Material newMaterial;

    // アルファ反転用マテリアル
    public Material invertAlphaMaterial;
    // アルファ反転用レンダーテクスチャ
    public RenderTexture targetTexture;

    // 壁移動の速度
    public float velocity = 0.01f;

    // Quadのレンダラー
    public Renderer quadRenderer;

    void Start()
    {
        
    }

    void Update()
    {
        this.transform.Translate(0, 0, velocity);
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (player != null && player.IsValid())
        {
            // 壁に衝突した場合の処理

            //  真っ白のテクスチャを壁に適用
            wallRenderer.material = newMaterial;

            // カメラにレンダーテクスチャを設定
            captureCamera.targetTexture = renderTexture;

            captureCamera.Render();

              // カメラにTranslucentTextureを設定
            AvatarResultcaptureCamera.targetTexture = TranslucentTexture;
            AvatarResultcaptureCamera.Render();

            // キャプチャしたテクスチャをquadのマテリアルに適用
            quadRenderer.material.mainTexture = TranslucentTexture;
            AvatarResultcaptureCamera.targetTexture =null;

            //アルファ反転処理
            VRCGraphics.Blit(renderTexture, targetTexture, invertAlphaMaterial);

            //反転したを壁のマテリアルに直接適用
            wallRenderer.material.mainTexture = targetTexture;

            // カメラのターゲットテクスチャをリセット
            captureCamera.targetTexture = null;
      

           
        }
    }

   
}

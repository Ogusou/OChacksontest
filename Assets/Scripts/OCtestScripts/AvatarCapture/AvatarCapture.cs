using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class AvatarCapture : UdonSharpBehaviour
{
    // アバターのシルエットをキャプチャするカメラ
    public Camera captureCamera;
    // 壁のレンダラー
    public Renderer wallRenderer;
    // レンダラーテクスチャ
    public RenderTexture renderTexture;
    // リセット用の真っ白なマテリアル
    public Material newMaterial;

    // ボーンの位置に表示する球
    public GameObject originVisSphere;

    // ------ ------ ------ ------ ------ ------ ------ ------

    // ワールド内のプレイヤーのリスト
    private VRCPlayerApi[] players = new VRCPlayerApi[20];
    // 全ボーンに複製して表示する球の配列
    private GameObject[] visSphere;

    // ------ ------ ------ ------ ------ ------ ------ ------

    void Start()
    {
        SetVisSphereInitialize();
    }

    // 初期設定
    private void SetVisSphereInitialize()
    {
        int numBones = (int)HumanBodyBones.RightToes - (int)HumanBodyBones.Hips + 1;
        visSphere = new GameObject[numBones];

        for (int i = (int)HumanBodyBones.Hips; i <= (int)HumanBodyBones.RightToes; i++)
        {
            visSphere[i] = GameObject.Instantiate(originVisSphere);
           // visSphere[i].transform.parent = originVisSphere.transform;
        }
    }

    // 壁がplayerに接触したとき発火
    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (player != null && player.IsValid())
        {
            // 真っ白のテクスチャを壁に適用
            wallRenderer.material = newMaterial;

            // カメラにレンダーテクスチャを設定
            captureCamera.targetTexture = renderTexture;

            captureCamera.Render();

            // キャプチャカメラのレンダーテクスチャを壁のマテリアルに直接適用
            wallRenderer.material.mainTexture = renderTexture;

            // カメラのターゲットテクスチャをリセット
            captureCamera.targetTexture = null;
        }
    }
    
    void Update()
    {
        VRCPlayerApi.GetPlayers(players);

        for (int i = (int)HumanBodyBones.Hips; i <= (int)HumanBodyBones.RightToes; i++)
        {
            visSphere[i].transform.position = players[0].GetBonePosition((HumanBodyBones)i) + new Vector3(-1.5f, 0.0f, -1.5f);
        }
    }


    
}

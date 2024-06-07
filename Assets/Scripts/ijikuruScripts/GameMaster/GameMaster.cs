
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class GameMaster : UdonSharpBehaviour
{
    //ゲーム回数
    public int maxGameNumber = 5;
    //結果保存配列
    public Texture2D[] rezultImages;
    //現在のゲームナンバー
    public int currentGameNumber = 0;


    /*
     * 備忘録エリア
     * private GameObject hoge;　特定のゲームオブジェクト
     * hoge.GetComponent<MeshRenderer>();　<>の中にとってきたいコンポーネントの名前を入れるととってこれる
    */

    void Start()
    {
        rezultImages = new Texture2D[maxGameNumber];
        
    }

    //壁召喚関数(n回目)
    void summonWall()
    {

    }

    //画像格納関数(n回目)
    void registerImage()
    {
        currentGameNumber++;
        if(currentGameNumber < maxGameNumber)
        {
            //次の壁へ
            summonWall();
        }else
        {
            //ゲーム終了、結果表示
        }
    }
}

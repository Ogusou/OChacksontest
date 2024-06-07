
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.SDK3.Image;
using VRC.SDK3.Components;

public class WallImage : UdonSharpBehaviour
{
    public VRCUrl testURL;
    public Material target;
    public UdonBehaviour damy;
    //private string textureInfo = "_Maintex";
    private VRCImageDownloader _imageDownloader;

    private TextureInfo GetTextureInfo()
    {
        // Mipmapを指定
        TextureInfo info = new TextureInfo();
        //info.MaterialProperty = "_MainTex";
        info.GenerateMipMaps = true;

        return info;
    }
    void Start()
    {
        TextureInfo info = GetTextureInfo();
        _imageDownloader.DownloadImage(testURL, target, damy, info);
    }
}

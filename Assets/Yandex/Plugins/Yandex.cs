using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Yandex : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void GiveMePlayerData();

    [DllImport("__Internal")]
    private static extern void ShowAdvInternal();

    [SerializeField] TextMeshProUGUI _nameTxt;
    [SerializeField] RawImage _photoImg;

    public void HelloButton()
    {
        GiveMePlayerData();
    }

    public void SetName(string name)
    {
        _nameTxt.text = name;
    }

    public void SetPhoto(string url)
    {
        StartCoroutine(DownloadImage(url));
    }
    
    public void ShowAdv()
    {
        ShowAdvInternal();
    }

    IEnumerator DownloadImage(string mediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            Debug.Log(request.error);
        else
            _photoImg.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }
}

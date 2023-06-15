using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageDownloader : MonoBehaviour
{
    [SerializeField] private int _imageIndex;

    [SerializeField] private Image _img;

    [SerializeField] private bool _loadStarted;

    [SerializeField] private Vector2 _middleScreen;

    [SerializeField] private Button _button;

    private void Start()
    {
        _img = GetComponent<Image>();
        _button = GetComponent<Button>();

        _button.onClick.AddListener(SelectImage);

        _middleScreen = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, _middleScreen) <= Screen.height / 2 && !_loadStarted)
        {
            StartCoroutine(LoadImage());
            _loadStarted = true;
        }
            
    }

    public void SetIndex(int id)
    {
        _imageIndex = id;
    }


    public void SelectImage()
    {
        PlayerPrefs.SetInt("IndexImageToLoad", _imageIndex);
        SceneManager.LoadSceneAsync(2);
    }

    IEnumerator LoadImage()
    {
        UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture($"http://data.ikppbb.com/test-task-unity-data/pics/{_imageIndex}.jpg");
        webRequest.SendWebRequest();

        while(!webRequest.isDone) 
        {
            yield return webRequest;
        }

        Texture texture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;

        _img.sprite = Sprite.Create((Texture2D)texture, new Rect(0,0,texture.width, texture.height), Vector2.zero);
        _button.interactable = true;
    }
}

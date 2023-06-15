using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ViewImage : MonoBehaviour
{
    [SerializeField] private Image _img;

    void Start()
    {
        Application.targetFrameRate = 60;
        Screen.orientation = ScreenOrientation.AutoRotation;

        _img = GetComponent<Image>();

        StartCoroutine(LoadImage());
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    IEnumerator LoadImage()
    {
        UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture($"http://data.ikppbb.com/test-task-unity-data/pics/{PlayerPrefs.GetInt("IndexImageToLoad")}.jpg");
        webRequest.SendWebRequest();

        while (!webRequest.isDone)
        {
            yield return webRequest;
        }

        Texture texture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;

        _img.sprite = Sprite.Create((Texture2D)texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }
}

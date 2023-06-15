using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gallery : MonoBehaviour
{
    [SerializeField] private List<ImageDownloader> _images;
    
    void Awake()
    {
        Application.targetFrameRate = 60;
        Screen.orientation = ScreenOrientation.Portrait;
        SetImageIndexes();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    private void SetImageIndexes()
    {
        for (int i = 0; i < _images.Count; i++)
        {
            _images[i].SetIndex(i+1);
        }
    }
}

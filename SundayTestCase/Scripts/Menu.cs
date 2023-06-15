using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private float _loadingTime;
    [SerializeField] private float _currentTime;

    [SerializeField] private Slider _loadingProgressBar;

    [SerializeField] private GameObject _loadingScreen;

    private void Start()
    {
        Application.targetFrameRate = 60;
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void StartLoading()
    {
        _loadingScreen.SetActive(true);
        _loadingProgressBar.maxValue = _loadingTime;
        StartCoroutine(LoadingProcess());
    }

    IEnumerator LoadingProcess()
    {
        while (_currentTime <= _loadingTime)
        {
            _currentTime += Time.deltaTime;
            _loadingProgressBar.value = _currentTime;

            if( _currentTime >= _loadingTime)
            {
                SceneManager.LoadSceneAsync(1);
            }

            yield return null;
        }
    }
}

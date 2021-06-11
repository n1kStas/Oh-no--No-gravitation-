using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public Camera cameraShow;
    public GameObject logo;
    public GameObject canvas;
    public Slider loadingGameIndicator;



    private void Start()
    {
        StartCoroutine(ShowLogo());
    }



    IEnumerator ShowLogo()
    {
        logo.SetActive(true);
        while (true)
        {
            cameraShow.GetComponent<Camera>().orthographicSize -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
            if (cameraShow.GetComponent<Camera>().orthographicSize < 15)
            {
                break;
            }
        }
        logo.SetActive(false);
        ShowNameGame();
    }
    
    private void ShowNameGame()
    {
        canvas.SetActive(true);
        StartCoroutine(ShowLoadingGame());
    }

    IEnumerator ShowLoadingGame()
    {
        loadingGameIndicator.gameObject.SetActive(true);
        float progressLoad = 0;
        AsyncOperation loadGame = SceneManager.LoadSceneAsync(1);
        loadGame.allowSceneActivation = false;
        while (true)
        {
            yield return new WaitForEndOfFrame();
            progressLoad = loadGame.progress * 100;
            loadingGameIndicator.value = progressLoad;
            if(progressLoad >= 90)
            {
                loadGame.allowSceneActivation = true;
            }
        }
    }
}

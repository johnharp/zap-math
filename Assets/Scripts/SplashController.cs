using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour
{
    [SerializeField]
    private string NextScene = "LessonSelectScene";

    [SerializeField]
    private float SecondsToAutoLoadNextScene = 3.0f;

    private bool ReadyToLoadNextScene = false;

    private void Start()
    {
        Invoke("setReadyToLoadNextScene", SecondsToAutoLoadNextScene);
    }

    private void setReadyToLoadNextScene()
    {
        ReadyToLoadNextScene = true;
    }

    public void Update()
    {
        if (Input.anyKeyDown || Input.touchCount > 0)
        {
            ReadyToLoadNextScene = true;
        }

        if (ReadyToLoadNextScene)
        {
            SceneManager.LoadScene(NextScene);
        }
    }
}

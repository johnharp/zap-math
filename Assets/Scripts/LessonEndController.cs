using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LessonEndController : MonoBehaviour
{
    private MainController _MainController = null;

    [SerializeField]
    private AudioClip SoundClick;

    [SerializeField]
    private AudioSource LessonAudioSource;

    [SerializeField]
    private UnityEngine.UI.Text NumWrongText = null;

    public void Start()
    {
        GameObject controllers = GameObject.Find("Controllers");
        _MainController = controllers.GetComponent<MainController>();

        NumWrongText.text =
            _MainController.GetNumWrongAnswersStr();
    }
    public void HandleBackButton()
    {
        LessonAudioSource.PlayOneShot(SoundClick);
        SceneManager.LoadScene("LessonSelectScene");
    }
}

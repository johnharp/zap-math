using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LessonEndController : MonoBehaviour
{

    [SerializeField]
    private AudioClip SoundClick;

    [SerializeField]
    private AudioSource LessonAudioSource;

    public void HandleBackButton()
    {
        LessonAudioSource.PlayOneShot(SoundClick);
        SceneManager.LoadScene("LessonSelectScene");
    }
}

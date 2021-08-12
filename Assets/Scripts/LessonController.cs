using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LessonController : MonoBehaviour
{
    public void HandleBackButton()
    {
        SceneManager.LoadScene("LessonSelectScene");
    }
}

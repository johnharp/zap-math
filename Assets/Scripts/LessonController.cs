using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LessonController : MonoBehaviour
{
    private MainController _MainController = null;

    private bool LessonComplete = false;

    [SerializeField]
    private CardController _CardController;

    void Start()
    {
        GameObject controllers = GameObject.Find("Controllers");
        _MainController = controllers.GetComponent<MainController>();

        var qa = new QuestionAnswer(9, 8, MainController.ADD_SYMBOL, 17);
        _CardController.ShowProblem(qa);
    }

    public void HandleBackButton()
    {
        SceneManager.LoadScene("LessonSelectScene");
    }
}

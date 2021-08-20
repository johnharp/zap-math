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

    [SerializeField]
    private List<AnswerButtonController> _AnswerButtonControllers;

    private List<QuestionAnswer> _QuestionAnswers;

    void Start()
    {
        GameObject controllers = GameObject.Find("Controllers");
        _MainController = controllers.GetComponent<MainController>();

        int num = _MainController.SelectedNumber ?? 5;
        char op = _MainController.SelectedOperation;

        _QuestionAnswers = QuestionAnswer.GenerateQuestionAnswers(num, op);

        var qa = _QuestionAnswers[0];
        _QuestionAnswers.RemoveAt(0);
        _CardController.ShowProblem(qa);
    }

    private bool AskNextQuestion()
    {
        if (_QuestionAnswers.Count == 0) return false;

        var qa = _QuestionAnswers[0];
        _QuestionAnswers.RemoveAt(0);
        _CardController.ShowProblem(qa);

        for (int i = 0; i < _AnswerButtonControllers.Count; i++)
        {
            _AnswerButtonControllers[i].SetAnswer(i);
        }

        return true;
    }

    public void HandleBackButton()
    {
        SceneManager.LoadScene("LessonSelectScene");
    }
}

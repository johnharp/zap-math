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

        AskNextQuestion();
    }

    private bool AskNextQuestion()
    {
        if (_QuestionAnswers.Count == 0) return false;

        var qa = _QuestionAnswers[0];
        _QuestionAnswers.RemoveAt(0);
        _CardController.ShowProblem(qa);

        // compute the answers
        List<int> answers = new List<int>();

        int rightanswer = qa.Answer.Value;
        // first, the right answer
        answers.Add(rightanswer);

        // then compute n-1 wrong answers
        for (int i = 1; i < _AnswerButtonControllers.Count; i++)
        {
            int wronganswer = 0;
            // Allow up to 100 tries to pick a random number
            // that isn't the right answer and doesn't duplicate
            // an already added wrong answer.
            // It should never take 100, but just in case we don't
            // want to keep trying.  Better to just display a duplicate
            for (int trynum = 0; trynum < 100; trynum++)
            {
                wronganswer = qa.RandomAnswer();
                if (!answers.Contains(wronganswer)) break;
            }
            answers.Add(wronganswer);
        }

        // Randomize the answer buttons
        for (int i = 0; i < answers.Count; i++)
        {
            int r = Random.Range(i, answers.Count);
            int tmp = answers[i];
            answers[i] = answers[r];
            answers[r] = tmp;
        }

        for (int i = 0; i < _AnswerButtonControllers.Count; i++)
        {
            _AnswerButtonControllers[i].SetAnswer(answers[i]);
        }


        return true;
    }

    public void HandleBackButton()
    {
        SceneManager.LoadScene("LessonSelectScene");
    }
}

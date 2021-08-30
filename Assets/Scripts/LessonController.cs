using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LessonController : MonoBehaviour
{
    private MainController _MainController = null;

    [SerializeField]
    private Animator CanvasAnimator = null;

    [SerializeField]
    private Animator GradeAnimator = null;

    private bool LessonComplete = false;

    [SerializeField]
    private CardController _CardController;

    [SerializeField]
    private List<AnswerButtonController> _AnswerButtonControllers;

    [SerializeField]
    private AudioClip SoundCorrect;

    [SerializeField]
    private AudioClip SoundWrong;

    [SerializeField]
    private AudioClip SoundClick;

    [SerializeField]
    private AudioSource LessonAudioSource;

    [SerializeField]
    private Canvas LessonSceneCanvas;

    private List<QuestionAnswer> _QuestionAnswers;

    private int CurrentRightAnswer = 0;

    void Start()
    {
        GameObject controllers = GameObject.Find("Controllers");
        _MainController = controllers.GetComponent<MainController>();
        _MainController.StartNewLesson();

        int num = _MainController.SelectedNumber ?? 5;
        char op = _MainController.SelectedOperation;

        _QuestionAnswers = QuestionAnswer.GenerateQuestionAnswers(num, op);

        AskNextQuestion();
    }

    private bool QuestionsRemain()
    {
        return _QuestionAnswers.Count > 0;
    }

    private bool AskNextQuestion()
    {
        if (!QuestionsRemain()) return false;

        var qa = _QuestionAnswers[0];
        if (qa.Num1 == null || qa.Num2 == null || qa.Answer == null) return false;

        _QuestionAnswers.RemoveAt(0);
        _CardController.ShowProblem(qa);
        CurrentRightAnswer = qa.Answer.Value;

        // choose the answers
        List<int> answers = new List<int>();

        // first, the right answer
        int rightanswer = qa.Answer.Value;
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

        // And assign the random answers to each button
        for (int i = 0; i < _AnswerButtonControllers.Count; i++)
        {
            _AnswerButtonControllers[i].SetAnswer(answers[i]);
        }

        LessonSceneCanvas.gameObject.SetActive(true);
        return true;
    }

    public void HandleBackButton()
    {
        LessonAudioSource.PlayOneShot(SoundClick);
        SceneManager.LoadScene("LessonSelectScene");
    }

    public void HandleAnswerButton(int buttonNumber)
    {
        LessonSceneCanvas.gameObject.SetActive(false);

        LessonAudioSource.PlayOneShot(SoundClick);
        AnswerButtonController pressedButtonController =
            _AnswerButtonControllers[buttonNumber];

        int chosenAnswer = pressedButtonController.GetAnswer();
        if (CurrentRightAnswer == chosenAnswer)
        {
            _MainController.IncNumCorrectAnswers();
            GradeAnimator.Play("Check");
            LessonAudioSource.PlayOneShot(SoundCorrect);
            if (QuestionsRemain())
            {
                StartCoroutine(AskNextQuestionAfterSeconds(1));
            }
            else
            {
                StartCoroutine(EndLessonAfterSeconds(1));
            }
        }
        else
        {
            _MainController.IncNumWrongAnswers();
            GradeAnimator.Play("X");
            LessonAudioSource.PlayOneShot(SoundWrong);
            StartCoroutine(ShowCanvasAfterSeconds(1));
        }
    }

    IEnumerator AskNextQuestionAfterSeconds(int sec)
    {
        yield return new WaitForSeconds(sec);

        LessonSceneCanvas.gameObject.SetActive(true);
        AskNextQuestion();
    }

    IEnumerator ShowCanvasAfterSeconds(int sec)
    {
        yield return new WaitForSeconds(sec);
        LessonSceneCanvas.gameObject.SetActive(true);
    }

    IEnumerator EndLessonAfterSeconds(int sec)
    {
        yield return new WaitForSeconds(sec);

        SceneManager.LoadScene("LessonEndScene");
    } 
}

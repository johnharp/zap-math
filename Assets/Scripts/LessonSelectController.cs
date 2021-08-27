using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LessonSelectController : MonoBehaviour
{
    private MainController _MainController = null;

    [SerializeField]
    private UnityEngine.UI.Button PlayButton = null;

    [SerializeField]
    private Animator CanvasAnimator = null;

    [SerializeField]
    private CardController Card1Controller = null;

    [SerializeField]
    private Animator CardAnimator = null;

    [SerializeField]
    private AudioClip SoundClick;

    [SerializeField]
    private AudioSource LessonSelectAudioSource;

    void Start()
    {
        GameObject controllers = GameObject.Find("Controllers");
        _MainController = controllers.GetComponent<MainController>();
    }

    public void HandleBackButton()
    {
        LessonSelectAudioSource.PlayOneShot(SoundClick);
        PlayButton.gameObject.SetActive(false);

        CanvasAnimator.Play("NumbersOutOperationsIn");
        CardAnimator.Play("CardOut");
    }

    public void HandleAddButton()
    {
        LessonSelectAudioSource.PlayOneShot(SoundClick);
        _MainController.SelectedOperation = MainController.ADD_SYMBOL;
        CanvasAnimator.Play("NumbersIn");

        Card1Controller.ShowAdd();
        CardAnimator.Play("CardIn");
    }

    public void HandleSubtractButton()
    {
        LessonSelectAudioSource.PlayOneShot(SoundClick);
        _MainController.SelectedOperation = MainController.SUBTRACT_SYMBOL;
        CanvasAnimator.Play("NumbersIn");

        Card1Controller.ShowSubtract();
        CardAnimator.Play("CardIn");
    }

    public void HandleMultiplyButton()
    {
        LessonSelectAudioSource.PlayOneShot(SoundClick);
        _MainController.SelectedOperation = MainController.MULTIPLY_SYMBOL;
        CanvasAnimator.Play("NumbersIn");

        Card1Controller.ShowMultiply();
        CardAnimator.Play("CardIn");
    }

    public void HandleDivideButton()
    {
        LessonSelectAudioSource.PlayOneShot(SoundClick);
        _MainController.SelectedOperation = MainController.DIVIDE_SYMBOL;
        CanvasAnimator.Play("NumbersIn");

        Card1Controller.ShowDivide();
        CardAnimator.Play("CardIn");
    }

    public void HandlePlayButton()
    {
        LessonSelectAudioSource.PlayOneShot(SoundClick);
        SceneManager.LoadScene("LessonScene");
    }

    public void HandleNumberButton(int num)
    {
        LessonSelectAudioSource.PlayOneShot(SoundClick);
        _MainController.SelectedNumber = num;
        int? n1 = null;
        int? n2 = null;

        if (_MainController.SelectedOperation == MainController.DIVIDE_SYMBOL ||
            _MainController.SelectedOperation == MainController.SUBTRACT_SYMBOL)
        {
            n2 = num;
        }
        else
        {
            n1 = num;
        }

        Card1Controller.ShowProblem(n1, n2, _MainController.SelectedOperation);

        CardAnimator.Play("CardIn");
        PlayButton.gameObject.SetActive(true);
    }
}

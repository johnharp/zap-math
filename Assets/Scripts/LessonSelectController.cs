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
    private GameObject CardPrefab = null;

    [SerializeField]
    private Animator CanvasAnimator = null;

    [SerializeField]
    private GameObject Card1 = null;

    [SerializeField]
    private CardController Card1Controller = null;

    [SerializeField]
    private Animator CardAnimator = null;

    void Start()
    {
        GameObject controllers = GameObject.Find("Controllers");
        _MainController = controllers.GetComponent<MainController>();
    }

    public void HandleBackButton()
    {
        PlayButton.gameObject.SetActive(false);

        CanvasAnimator.Play("NumbersOutOperationsIn");
        CardAnimator.Play("CardOut");
    }

    public void HandleAddButton()
    {
        _MainController.SelectedOperation = MainController.ADD_SYMBOL;
        CanvasAnimator.Play("NumbersIn");

        Card1Controller.ShowAdd();
        CardAnimator.Play("CardIn");
    }

    public void HandleSubtractButton()
    {
        _MainController.SelectedOperation = MainController.SUBTRACT_SYMBOL;
        CanvasAnimator.Play("NumbersIn");

        Card1Controller.ShowSubtract();
        CardAnimator.Play("CardIn");
    }

    public void HandleMultiplyButton()
    {
        _MainController.SelectedOperation = MainController.MULTIPLY_SYMBOL;
        CanvasAnimator.Play("NumbersIn");

        Card1Controller.ShowMultiply();
        CardAnimator.Play("CardIn");
    }

    public void HandleDivideButton()
    {
        _MainController.SelectedOperation = MainController.DIVIDE_SYMBOL;
        CanvasAnimator.Play("NumbersIn");

        Card1Controller.ShowDivide();
        CardAnimator.Play("CardIn");
    }

    public void HandlePlayButton()
    {
        SceneManager.LoadScene("LessonScene");

        Debug.Log("Play!");
    }

    public void HandleNumberButton(int num)
    {
        _MainController.SelectedNumber = num;
        Card1Controller.ShowProblem(null, num, _MainController.SelectedOperation);

        CardAnimator.Play("CardIn");
        PlayButton.gameObject.SetActive(true);
        Debug.Log("pressed: " + num);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LessonSelectController : MonoBehaviour
{

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

    private int? SelectedNumber = null;
    private string SelectedOperation = "";

    public void HandleBackButton()
    {
        PlayButton.gameObject.SetActive(false);

        CanvasAnimator.Play("NumbersOutOperationsIn");
        CardAnimator.Play("CardOut");
    }

    public void HandleAddButton()
    {
        SelectedOperation = CardController.ADD_SYMBOL;
        CanvasAnimator.Play("NumbersIn");

        Card1Controller.ShowAdd();
        CardAnimator.Play("CardIn");

        //cardsController.AnimateAddCard();

        //PlayButton.gameObject.SetActive(true);

        //Vector3 location = new Vector3(-15, 0, 0);
        //GameObject card = Instantiate(
        //    CardPrefab,
        //    location,
        //    CardPrefab.transform.rotation);

        //CardController script = card.GetComponent<CardController>();
    }

    public void HandleSubtractButton()
    {
        SelectedOperation = CardController.SUBTRACT_SYMBOL;
        CanvasAnimator.Play("NumbersIn");

        Card1Controller.ShowSubtract();
        CardAnimator.Play("CardIn");
        //cardsController.AnimateSubtractCard();
    }

    public void HandleMultiplyButton()
    {
        SelectedOperation = CardController.MULTIPLY_SYMBOL;
        CanvasAnimator.Play("NumbersIn");

        Card1Controller.ShowMultiply();
        CardAnimator.Play("CardIn");
        //cardsController.AnimateMultiplyCard();
    }

    public void HandleDivideButton()
    {
        SelectedOperation = CardController.DIVIDE_SYMBOL;
        CanvasAnimator.Play("NumbersIn");

        Card1Controller.ShowDivide();
        CardAnimator.Play("CardIn");
        //cardsController.AnimateDivideCard();
    }

    public void HandlePlayButton()
    {
        SceneManager.LoadScene("LessonScene");

        Debug.Log("Play!");
    }

    public void HandleNumberButton(int num)
    {
        Card1Controller.ShowProblem(null, num, SelectedOperation);
        CardAnimator.Play("CardIn");
        PlayButton.gameObject.SetActive(true);
        Debug.Log("pressed: " + num);
    }
}

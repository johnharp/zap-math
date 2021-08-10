using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonSelectController : MonoBehaviour
{

    [SerializeField]
    private LessonSelectCardsController cardsController;

    [SerializeField]
    private UnityEngine.UI.Button PlayButton = null;

    [SerializeField]
    private GameObject CardPrefab = null;

    [SerializeField]
    private Animator CanvasAnimator = null;

    public void HandleBackButton()
    {
        CanvasAnimator.Play("NumbersOutOperationsIn");
    }

    public void HandleAddButton()
    {
        CanvasAnimator.Play("NumbersIn");
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
        CanvasAnimator.Play("NumbersIn");
        //cardsController.AnimateSubtractCard();
    }

    public void HandleMultiplyButton()
    {
        CanvasAnimator.Play("NumbersIn");
        //cardsController.AnimateMultiplyCard();
    }

    public void HandleDivideButton()
    {
        CanvasAnimator.Play("NumbersIn");
        //cardsController.AnimateDivideCard();
    }

    public void HandlePlayButton()
    {
        Debug.Log("Play!");
    }

    public void HandleNumberButton(int num)
    {
        Debug.Log("pressed: " + num);
    }
}

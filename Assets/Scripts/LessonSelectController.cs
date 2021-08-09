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

    public void HandleAddButton()
    {
        cardsController.AnimateAddCard();
        PlayButton.gameObject.SetActive(true);

        Vector3 location = new Vector3(-15, 0, 0);
        GameObject card = Instantiate(
            CardPrefab,
            location,
            CardPrefab.transform.rotation);

        CardController script = card.GetComponent<CardController>();
    }

    public void HandleSubtractButton()
    {
        cardsController.AnimateSubtractCard();
    }

    public void HandleMultiplyButton()
    {
        cardsController.AnimateMultiplyCard();
    }

    public void HandleDivideButton()
    {
        cardsController.AnimateDivideCard();
    }

    public void HandlePlayButton()
    {
        Debug.Log("Play!");
    }
}

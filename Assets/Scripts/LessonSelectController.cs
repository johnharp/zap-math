using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonSelectController : MonoBehaviour
{

    [SerializeField]
    private LessonSelectCardsController cardsController;

    public void HandleAddButton()
    {
        cardsController.AnimateAddCard(); 
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonSelectCardsController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void AnimateAddCard()
    {
        Debug.Log("Moving the Add card");
        animator.Play("AddCardInAnimation");
    }

    public void AnimateSubtractCard()
    {
        Debug.Log("Moving the Substract card");
    }
}

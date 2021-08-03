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
        animator.Play("AddCardInAnimation");
    }

    public void AnimateSubtractCard()
    {
        animator.Play("SubtractCardInAnimation");
    }

    public void AnimateMultiplyCard()
    {
        animator.Play("MultiplyCardInAnimation");
    }

    public void AnimateDivideCard()
    {
        animator.Play("DivideCardInAnimation");
    }
}

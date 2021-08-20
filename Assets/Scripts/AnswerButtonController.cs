using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButtonController : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Text Text = null;

    private int Answer;

    public void SetAnswer(int answer)
    {
        Answer = answer;
        Text.text = answer.ToString();
    }
}

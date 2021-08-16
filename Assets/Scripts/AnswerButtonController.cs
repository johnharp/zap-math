using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButtonController : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Text Text = null;

    public void ShowAnswer(int answer)
    {
        Text.text = answer.ToString();
    }
}

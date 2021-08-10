using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Text Text = null;
    [SerializeField]
    private string InitialDisplayText = "";

    void Start()
    {
        Text.text = InitialDisplayText;
    }
}

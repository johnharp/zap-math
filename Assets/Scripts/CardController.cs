using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public const string ADD_SYMBOL = "+";
    public const string SUBTRACT_SYMBOL = "−";
    public const string MULTIPLY_SYMBOL = "×";
    public const string DIVIDE_SYMBOL = "÷";

    [SerializeField]
    private UnityEngine.UI.Text Text0 = null;

    [SerializeField]
    private UnityEngine.UI.Text Text1 = null;

    [SerializeField]
    private UnityEngine.UI.Text Text2 = null;

    // Update is called once per frame
    void Update()
    {
        ShowProblem(6, 5, MULTIPLY_SYMBOL);
    }

    public void ShowAdd()
    {
        ShowCategory(ADD_SYMBOL);
    }

    public void ShowSubtract()
    {
        ShowCategory(SUBTRACT_SYMBOL);
    }

    public void ShowMultiply()
    {
        ShowCategory(MULTIPLY_SYMBOL);
    }
    
    public void ShowDivide()
    {
        ShowCategory(DIVIDE_SYMBOL);
    }

    public void ShowProblem(int n1, int n2, string op)
    {
        string line1 = n1.ToString();
        string line2 = n2.ToString();
        if (line2.Length == 1) line2 = " " + line2;
        line2 = op + line2;

        Text0.text = "";
        Text1.text = line1;
        Text2.text = line2;
    }

    private void ShowCategory(string c)
    {
        Text1.text = "";
        Text2.text = "";
        Text0.text = c;
    }
}

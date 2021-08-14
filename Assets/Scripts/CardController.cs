using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Text Text0 = null;

    [SerializeField]
    private UnityEngine.UI.Text Text1 = null;

    [SerializeField]
    private UnityEngine.UI.Text Text2 = null;

    private MainController _MainController = null;

    void Start()
    {
        GameObject controllers = GameObject.Find("Controllers");
        _MainController = controllers.GetComponent<MainController>();
    }

    public void ShowAdd()
    {
        ShowCategory(MainController.ADD_SYMBOL);
    }

    public void ShowSubtract()
    {
        ShowCategory(MainController.SUBTRACT_SYMBOL);
    }

    public void ShowMultiply()
    {
        ShowCategory(MainController.MULTIPLY_SYMBOL);
    }
    
    public void ShowDivide()
    {
        ShowCategory(MainController.DIVIDE_SYMBOL);
    }

    public void ShowProblem(int? n1, int? n2, char op)
    {
        string line1 = n1.HasValue ? n1.ToString() : "?";
        string line2 = n2.HasValue ? n2.ToString() : "?";
        if (line2.Length == 1) line2 = " " + line2;
        line2 = op + line2;

        Text0.text = "";
        Text1.text = line1;
        Text2.text = line2;
    }

    private void ShowCategory(char c)
    {
        Text1.text = "";
        Text2.text = "";
        Text0.text = c.ToString();
    }
}

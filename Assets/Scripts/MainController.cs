using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public int? SelectedNumber { get; set; }
    public char SelectedOperation { get; set; }

    public const char ADD_SYMBOL = '+';
    public const char SUBTRACT_SYMBOL = '−';
    public const char MULTIPLY_SYMBOL = '×';
    public const char DIVIDE_SYMBOL = '÷';
}

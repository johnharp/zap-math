using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public const int QUESTIONS_PER_LESSON = 8;

    public int? SelectedNumber { get; set; }
    public char SelectedOperation { get; set; }

    public const char ADD_SYMBOL = '+';
    public const char SUBTRACT_SYMBOL = '−';
    public const char MULTIPLY_SYMBOL = '×';
    public const char DIVIDE_SYMBOL = '÷';


    private int NumCorrectAnswers = 0;
    private int NumWrongAnswers = 0;

    // Current Question Number ranges from
    // [0 - QUESTIONS_PER_LESSON]
    public int CurrentQuestionNumber { get; set; }


    public string GetPercentGrade()
    {
        string s = "";

        int numerator = NumCorrectAnswers;
        int denominator = NumCorrectAnswers + NumWrongAnswers;

        if (denominator != 0)
        {
            int percent = (NumCorrectAnswers * 100) /
                (NumCorrectAnswers + NumWrongAnswers);
            s = string.Format("{0:N0} %", percent);
        }

        return s;
    }

    public void StartNewLesson()
    {
        NumCorrectAnswers = 0;
        NumWrongAnswers = 0;
        CurrentQuestionNumber = 0;
    }

    public void IncCurrentQuestionNumber()
    {
        CurrentQuestionNumber++;
    }

    public void IncNumCorrectAnswers()
    {
        NumCorrectAnswers++;
    }

    public void IncNumWrongAnswers()
    {
        NumWrongAnswers++;
    }

    public string GetNumCorrectAnswersStr()
    {
        return NumCorrectAnswers.ToString("N0");
    }

    public string GetNumWrongAnswersStr()
    {
        return NumWrongAnswers.ToString("N0");
    }
}

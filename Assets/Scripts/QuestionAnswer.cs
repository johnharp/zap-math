using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestionAnswer
{
    public int? Num1 { get; set; }
    public int? Num2 { get; set; }
    public int? Answer { get; set; }
    public char? Operation { get; set; }

    public QuestionAnswer(int n1, int n2, char op, int a)
    {
        Num1 = n1;
        Num2 = n2;
        Answer = a;
        Operation = op;
    }

    public int RandomAnswer()
    {
        int min = 0;
        int max = 0;
        int ans = 0;

        switch(Operation)
        {
            case MainController.ADD_SYMBOL:
                min = 2 + 2;
                max = 9 + 9 + 5;
                break;
            case MainController.SUBTRACT_SYMBOL:
                min = 2;
                max = 7;
                break;
            case MainController.MULTIPLY_SYMBOL:
                min = 2 * 2;
                max = (9 * 9) + 5;
                break;
            case MainController.DIVIDE_SYMBOL:
                min = 2;
                max = 9;
                break;
        }

        ans = UnityEngine.Random.Range(min, max+1);

        return ans;
    }

    public static List<QuestionAnswer> GenerateQuestionAnswers(int n, char op)
    {
        List<QuestionAnswer> qas = new List<QuestionAnswer>();

        for (int i = 1; i <= 3; i++)
        {
            if (op == MainController.ADD_SYMBOL)
            {
                qas.Add(new QuestionAnswer(n, i, op, n + i));
            }
            else if (op == MainController.SUBTRACT_SYMBOL)
            {
                qas.Add(new QuestionAnswer(n + i, n, op, i));
            }
            else if (op == MainController.MULTIPLY_SYMBOL)
            {
                qas.Add(new QuestionAnswer(n, i, op, n * i));
            }
            else if (op == MainController.DIVIDE_SYMBOL)
            {
                qas.Add(new QuestionAnswer(n * i, n, op, i));
            }
        }

        // randomize the questions
        for (int i = 0; i < qas.Count-1; i++)
        {
            int r = UnityEngine.Random.Range(i, qas.Count);
            QuestionAnswer tmp = qas[i];
            qas[i] = qas[r];
            qas[r] = tmp;
        }

        return qas;
    }
}

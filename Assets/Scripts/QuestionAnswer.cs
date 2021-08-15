using System;
using System.Collections.Generic;

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


    public static List<QuestionAnswer> GenerateQuestionAnswers(int n, char op)
    {
        List<QuestionAnswer> qas = new List<QuestionAnswer>();

        for (int i = 2; i <= 9; i++)
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

        // randomize here

        return qas;
    }
}

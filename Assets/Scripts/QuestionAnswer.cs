using System;
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
}

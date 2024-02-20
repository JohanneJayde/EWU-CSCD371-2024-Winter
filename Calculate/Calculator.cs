﻿
namespace Calculate;

public class Calculator
{

    public static IReadOnlyDictionary<char, Func<int,int,int>> MathematicalOperations { get; } = new Dictionary<char, Func<int, int, int>>()
        { 
        {'+',Add},
        {'-',Subtract},
        {'*',Multiply },
        {'/', Divide}
        };
    
    public static int Add(int num1, int num2)
    {
        return num1 + num2;
    }
    public static int Subtract(int num1, int num2)
    {
        return num1 - num2;

    }
    public static int Multiply(int num1, int num2)
    {
        return num1 * num2;
    }
    public static int Divide(int num1, int num2)
    {
        return num1 / num2;
    }

    public bool TryCalculate(string expresion, out int result)
    {
        string[] ops = expresion.Split(' ');
        int num1 = 0;
        int num2 = 0;
        result = 0;

        if(ops.Length != 3) { return false; }

        if (int.TryParse(ops[0], out num1) && int.TryParse(ops[2], out num2) )
        {
            if (!MathematicalOperations.ContainsKey(ops[1][0])) { return false; }

            var operand = MathematicalOperations[ops[1][0]];
            result = operand(num1, num2);
            return true;
        }
        return false;
    }
}


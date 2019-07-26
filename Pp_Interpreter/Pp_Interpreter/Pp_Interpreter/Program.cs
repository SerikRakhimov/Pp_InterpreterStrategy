using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Interpreter(Интерпретатор) 
// Приведен пример интерпретатора для операций сложения и вычитания.
// Добавить в интерпретатор операцию умножения.

namespace Pp_Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            // определяем набор переменных
            int a = 2;
            int x = 5;
            int y = 8;
            int z = 2;

            // добавляем переменные в контекст
            context.SetVariable("a", a);
            context.SetVariable("x", x);
            context.SetVariable("y", y);
            context.SetVariable("z", z);
            // создаем объект для вычисления выражения (x + y - z) * a
            IExpression expression =
            new IncreaseExpression(
                new SubtractExpression(
                    new AddExpression(new NumberExpression("x"), new NumberExpression("y")),
                    new NumberExpression("z")),
                new NumberExpression("a"));

            int result = expression.Interpret(context);
            Console.WriteLine("Результат: {0}", result);

            Console.ReadLine();
        }
    }

    class Context
    {
        Dictionary<string, int> variables;
        public Context()
        {
            variables = new Dictionary<string, int>();
        }
        // получаем значение переменной по ее имени
        public int GetVariable(string name)
        {
            return variables[name];
        }

        public void SetVariable(string name, int value)
        {
            if (variables.ContainsKey(name))
                variables[name] = value;
            else
                variables.Add(name, value);
        }
    }
    // интерфейс интерпретатора
    interface IExpression
    {
        int Interpret(Context context);
    }
    // терминальное выражение
    class NumberExpression : IExpression
    {
        string name; // имя переменной
        public NumberExpression(string variableName)
        {
            name = variableName;
        }
        public int Interpret(Context context)
        {
            return context.GetVariable(name);
        }
    }
    // нетерминальное выражение для сложения
    class AddExpression : IExpression
    {
        IExpression leftExpression;
        IExpression rightExpression;

        public AddExpression(IExpression left, IExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        public int Interpret(Context context)
        {
            return leftExpression.Interpret(context) + rightExpression.Interpret(context);
        }
    }

    // нетерминальное выражение для вычитания
    class SubtractExpression : IExpression
    {
        IExpression leftExpression;
        IExpression rightExpression;

        public SubtractExpression(IExpression left, IExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        public int Interpret(Context context)
        {
            return leftExpression.Interpret(context) - rightExpression.Interpret(context);
        }
    }

    // нетерминальное выражение для умножения
    class IncreaseExpression : IExpression
    {
        IExpression leftExpression;
        IExpression rightExpression;

        public IncreaseExpression(IExpression left, IExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        public int Interpret(Context context)
        {
            return leftExpression.Interpret(context) * rightExpression.Interpret(context);
        }
    }
    
}

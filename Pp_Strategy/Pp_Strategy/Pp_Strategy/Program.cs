using Pp_Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pp_Strategy
{
    // Контекст определяет интерфейс, представляющий интерес для клиентов.
    class Context
    {
        // Контекст хранит ссылку на один из объектов Стратегии. Контекст не
        // знает конкретного класса стратегии. Он должен работать со всеми
        // стратегиями через интерфейс Стратегии.
        private IStrategy _strategy;

        public Context()
        { }

        // Обычно Контекст принимает стратегию через конструктор, а также
        // предоставляет сеттер для её изменения во время выполнения.
        public Context(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        // Обычно Контекст позволяет заменить объект Стратегии во время
        // выполнения.
        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        // Вместо того, чтобы самостоятельно реализовывать множественные
        // версии алгоритма, Контекст делегирует некоторую работу объекту
        // Стратегии.
        public void DoSomeBusinessLogic()
        {
            var result = this._strategy.DoAlgorithm();

            Console.WriteLine($"{result}");

        }
    }


    // Интерфейс Стратегии объявляет операции, общие для всех поддерживаемых
    // версий некоторого алгоритма.
    //
    // Контекст использует этот интерфейс для вызова алгоритма, определённого
    // Конкретными Стратегиями.
    public interface IStrategy
    {
        object DoAlgorithm();
    }

    // Конкретные Стратегии реализуют алгоритм, следуя базовому интерфейсу
    // Стратегии. Этот интерфейс делает их взаимозаменяемыми в Контексте.
    class ConcreteStrategyDragon : IStrategy
    {
        public object DoAlgorithm()
        {
            var info = "бежать, прыгать";
            return info;
        }
    }

    class ConcreteStrategyVelican : IStrategy
    {
        public object DoAlgorithm()
        {
            var info = "cтрелять";
            return info;
        }
    }

    class ConcreteStrategyTurelyia : IStrategy
    {
        public object DoAlgorithm()
        {
            var info = "уворачиваться";
            return info;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Клиентский код выбирает конкретную стратегию и передаёт её в
            // контекст. Клиент должен знать о различиях между стратегиями,
            // чтобы сделать правильный выбор.
            var context = new Context();

            Console.WriteLine("Стратегия битвы с драконом:");
            context.SetStrategy(new ConcreteStrategyDragon());
            context.DoSomeBusinessLogic();
            Console.WriteLine();

            Console.WriteLine("Стратегия битвы с великаном:");
            context.SetStrategy(new ConcreteStrategyVelican());
            context.DoSomeBusinessLogic();
            Console.WriteLine();

            Console.WriteLine("Стратегия битвы с турелью:");
            context.SetStrategy(new ConcreteStrategyTurelyia());
            context.DoSomeBusinessLogic();
            Console.WriteLine();

            Console.ReadLine();

        }
    }

}
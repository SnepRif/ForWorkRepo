using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sums = "1000;2000;3000;5000;8000;5000";

            string Distribute(EventType eventType, decimal distributedSum, string sum)
            {

                ///конвертируем массив string в массив decimal
                decimal[] strToDecimal = sums.Split(';').Select(decimal.Parse).ToArray();

                ///получаем сумму всей последовательности decimal
                var arraySum = strToDecimal.Sum();

                if (eventType == EventType.Proportional)
                {
                    ///коллекция 
                    List<decimal> resultList = new List<decimal>();
                    for (int i = 0; i < strToDecimal.Length; i++)
                    {
                        ///распределяем сумму
                        var distribute = strToDecimal[i] / arraySum * distributedSum;
                        ///оставляем 2 знака после запятой
                        var roundResults = Math.Round(distribute, 2);
                        ///сохраняем суммы в коллекцию
                        resultList.Add(roundResults);
                    }
                    ///создаём строку для вывода сумм через ;
                    string outputResultForProportional = String.Join(";", resultList);

                    return outputResultForProportional;
                }
                else if (eventType == EventType.First)
                {
                    List<decimal> resultList = new List<decimal>();
                    for (int i = 0; i < strToDecimal.Length; i++)
                    {
                        ///если распределяемая сумма больше числа по индексу то вычитаем из суммы это число и сохраняем его в коллекцию
                        if (distributedSum > strToDecimal[i])
                        {
                            distributedSum -= strToDecimal[i];

                            resultList.Add(strToDecimal[i]);
                        }
                        else
                        {
                            ///добавляем остаток в коллекцию и устанавливаем его равным 0
                            resultList.Add(distributedSum);
                            distributedSum -= distributedSum;

                        }

                    }
                    string outputResultForFirst = String.Join(";", resultList);
                    return outputResultForFirst;
                }
                else if (eventType == EventType.Last)
                {
                    List<decimal> resultList = new List<decimal>();
                    for (int i = 0; strToDecimal.Length > i; i++)
                    {
                        ///коллекция в обратном порядке
                        var reverseArray = strToDecimal.Reverse().ToArray();

                        if (distributedSum > reverseArray[i])
                        {
                            distributedSum -= reverseArray[i];
                            resultList.Add(reverseArray[i]);
                        }
                        else
                        {
                            resultList.Add(distributedSum);
                            distributedSum -= distributedSum;
                        }

                    }

                    resultList.Reverse();
                    string outputResultForLast = String.Join(";", resultList);
                    return outputResultForLast;
                }

                return "Необходимо ввести все необходимые данные для выполнения функции";
            }

            Console.WriteLine(Distribute(EventType.Proportional, 10000, sums));
            Console.WriteLine(Distribute(EventType.First, 10000, sums));
            Console.WriteLine(Distribute(EventType.Last, 10000, sums));
        }
    }
}

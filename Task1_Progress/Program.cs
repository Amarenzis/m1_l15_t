using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Progress
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region ArithProgression
                //Фактически создание арифметической последовательности
                ArithProgression arith = new ArithProgression();
                Console.WriteLine("Введите первый член арифметической прогрессии: ");
                int startA = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите шаг арифметической прогрессии: ");
                int stepA = Convert.ToInt32(Console.ReadLine());                
                arith.SetStart(startA, stepA);

                //Цикл
                Console.WriteLine("Если захотите прервать вывод арифметической прогрессии, введите \"!\".");
                string stop = "";
                Console.WriteLine(arith.currentAProgression);
                while (!(stop == "!"))
                {
                    Console.Write(arith.GetNext());
                    stop = Console.ReadLine();
                }

                //Сброс значения
                Console.WriteLine("Хотите сбросить прогрессию к начальному значению? Введите \"да\"");
                stop = Console.ReadLine();
                switch (stop)
                {
                    case "да":
                        arith.Reset();
                        Console.WriteLine("Теперь арифметическая прогрессия снова начнётся с {0}", arith.currentAProgression);
                        break;
                    case "lf":
                        arith.Reset();
                        Console.WriteLine("Теперь арифметическая прогрессия снова начнётся с {0}", arith.currentAProgression);
                        break;
                    default:
                        break;
                }

                #endregion

                #region GeomProgression
                //Фактически создание геометрической последовательности
                GeomProgression geom = new GeomProgression();
                Console.WriteLine("");
                Console.WriteLine("Введите первый член геометрической прогрессии: ");
                int startG = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите шаг геометрической прогрессии: ");
                int stepG = Convert.ToInt32(Console.ReadLine());
                geom.SetStart(startG, stepG);

                //Цикл
                Console.WriteLine("Если захотите прервать вывод геометрической прогрессии, введите \"!\".");
                stop = "";
                Console.WriteLine(geom.currentGProgression);
                while (!(stop == "!"))
                {
                    Console.Write(geom.GetNext());
                    stop = Console.ReadLine();
                }

                Console.WriteLine("Хотите сбросить прогрессию к начальному значению? Введите \"да\"");
                stop = Console.ReadLine();
                switch (stop)
                {
                    case "да":
                        geom.Reset();
                        Console.WriteLine("Теперь геометрическая прогрессия снова начнётся с {0}", geom.currentGProgression);
                        break;
                    case "lf":
                        geom.Reset();
                        Console.WriteLine("Теперь геометрическая прогрессия снова начнётся с {0}", geom.currentGProgression);
                        break;
                    default:
                        break;
                }
                #endregion

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Нажмите любую кнопку для выхода из программы.");
            Console.ReadKey();
        }
    }
    interface ISeries
    {
        //У геометрич и арифм. прогрессий есть шаг и множитель, который является определяющими для определения следующего члена прогрессии
        //В связи с этим у SetStart ввела int d в параметрах метода. Второй вариант - ввести d у GetNext, но SetStart больше походит на исходные данные.
        void SetStart(int x, int d);
        int GetNext();
        void Reset();
    }

    /*Как вариант, метод Reset можно было бы реализовать в обоих классах через формулу вычисления члена последовательности.
     * Тогда необходим был currentProgression, и счётчик итераций. A startNumber был бы не нужен. 
     * Но насколько это выгоднее с точки зрения памяти и быстродействия?*/
    class ArithProgression : ISeries
    {
        public int startANumber;
        public int stepAProgression;
        public int currentAProgression;

        public void SetStart(int xA, int dA)
        {
            startANumber = xA;
            currentAProgression = startANumber;
            stepAProgression = dA;
        }
        public int GetNext()
        {
            currentAProgression+=stepAProgression;
            return currentAProgression;
        }

        public void Reset()
        {
            currentAProgression = startANumber;
        }
    }

    class GeomProgression : ISeries
    {
        public int startGNumber;
        public int stepGProgression;
        public int currentGProgression;

        public void SetStart(int xG, int dG)
        {
            startGNumber = xG;
            currentGProgression = startGNumber;
            stepGProgression = dG;
        }

        public int GetNext()
        {
            currentGProgression*= stepGProgression;
            return currentGProgression;
        }

        public void Reset()
        {
            currentGProgression = startGNumber;
        }        
    }
}

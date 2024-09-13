using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введите строку");
            string input = Console.ReadLine();
            List<string> output = UserSubstring(input);
            Console.WriteLine();
            foreach (var str in output)
            {
                Console.WriteLine(" "+str);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Функция по извлечению подстрок
        /// </summary>
        /// <param name="input">Входная строка</param>
        /// <returns>Список подстрок</returns>
        static List<string> UserSubstring(string input)
        {
            List<string> listSubstring = new List<string>();

            //Проверка на наличие подстрок 
            if (!(input.Contains("[") && input.Contains("]")))
            {
                Console.WriteLine("Подстроки не обнаружены");
                return listSubstring;
            }

            //Кол-во вхождений (подстрок)
            int countSubstring = new Regex(@"\[").Matches(input).Count;
            int[,] masIndex = new int[countSubstring, 2];
            List<int> lastStart = new List<int>();

            //Нахождение всех индексов символов [ ]
            for (int i1 = 0, i2 = 0; i1 < input.Length; i1++)
            {
                if (input[i1] == '[')
                {
                    lastStart.Add(i2);
                    masIndex[i2, 0] = i1;
                    i2++;
                }
                if (input[i1] == ']')
                {
                    masIndex[lastStart[lastStart.Count - 1], 1] = i1;
                    lastStart.Remove(lastStart[lastStart.Count - 1]);
                }
            }

            //Извлечение подстрок по найденным индексам
            for (int i = 0; i < countSubstring; i++)
            {
                int len = masIndex[i, 1] - masIndex[i, 0]-1;
                listSubstring.Add(input.Substring(masIndex[i, 0] + 1, len));
            }

            return listSubstring;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square
{
    class Malboro
    {
        private char[,] RusMatrix(char[,] matrix, string key)
        {
            char[] arrkey = key.ToCharArray();
            Program.ForRusMethod(arrkey);
            string newkey = new string(arrkey);
            newkey = newkey.Replace(" ", "");
            newkey = new String(newkey.Distinct().ToArray());

            for (int i = 0; i < newkey.Length; i++)
            {
                if (newkey[i] != 'ё')
                {
                    matrix[i / matrix.GetLength(1), i % matrix.GetLength(1)] = newkey[i];
                }
                else
                {
                    matrix[i / matrix.GetLength(1), i % matrix.GetLength(1)] = 'е';
                }

            }
            newkey = newkey.ToLower();
            char[] keyCA = newkey.ToCharArray();
            int position = newkey.Length;
            for (char c = 'а'; c <= 'я'; ++c)
            {
                if (c == 'ё')
                {
                    ++c;
                }

                if (Array.FindIndex(keyCA, (a) => a == c) == -1)
                {
                    matrix[position / matrix.GetLength(1), position % matrix.GetLength(1)] = c;
                    ++position;
                }
            }
            return matrix;
        }

        private char[,] EngMatrix(char[,] matrix, string key)
        {
            char[] arrkey = key.ToCharArray();
            Program.ForEngMethod(arrkey);
            string newkey = new string(arrkey);
            newkey = newkey.Replace(" ", "");
            newkey = new String(newkey.Distinct().ToArray());

            for (int i = 0; i < newkey.Length; i++)
            {
                if (newkey[i] != 'j')
                {
                    matrix[i / matrix.GetLength(1), i % matrix.GetLength(1)] = newkey[i];
                }
                else
                {
                    matrix[i / matrix.GetLength(1), i % matrix.GetLength(1)] = 'i';
                }

            }
            newkey = newkey.ToLower();
            char[] keyCA = newkey.ToCharArray();
            int position = newkey.Length;
            for (char c = 'a'; c <= 'z'; ++c)
            {
                if (c == 'j')
                {
                    ++c;
                }

                if (Array.FindIndex(keyCA, (a) => a == c) == -1)
                {
                    matrix[position / matrix.GetLength(1), position % matrix.GetLength(1)] = c;
                    ++position;
                }
            }
            return matrix;
        }

        public string RusEncrypt(string text)
        {
            text = text.ToLower();

            string result_text = "";

            if (text.Length % 2 != 0)
            {
                text += 'я';
            }
            int length = text.Length / 2;
            int k = 0;
            char[,] bigram = new char[length, 2];
            char[,] kripto_bigram = new char[length, 2];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    bigram[i, j] = text[k];
                    k++;
                }
            }

            print();

            int step = 0;
            while (step < length)
            {
                Cortege cortege1 = FindIndexes(bigram[step, 0], firstMatrix);
                Cortege cortege2 = FindIndexes(bigram[step, 1], secondMatrix);

                kripto_bigram[step, 0] = secondMatrix[cortege1.I, cortege2.J];
                kripto_bigram[step, 1] = firstMatrix[cortege2.I, cortege1.J];

                step++;
            }

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result_text += kripto_bigram[i, j].ToString();
                }
                result_text += " ";
            }
            return result_text;
        }

        public string RusDecrypt(string text)
        {
            string result_text = "";

            text = text.ToLower();
            int length = text.Length / 2;
            int k = 0;

            char[,] bigram = new char[length, 2];
            char[,] kripto_bigram = new char[length, 2];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    bigram[i, j] = text[k];
                    k++;
                }
            }

            print();

            int step = 0;
            while (step < length)
            {
                Cortege cortege1 = FindIndexes(bigram[step, 0], second_matrix);
                Cortege cortege2 = FindIndexes(bigram[step, 1], firstMatrix);

                kripto_bigram[step, 0] = firstMatrix[cortege1.I, cortege2.J];
                kripto_bigram[step, 1] = second_matrix[cortege2.I, cortege1.J];

                step++;
            }


            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result_text += kripto_bigram[i, j].ToString();
                }
            }
            return result_text;
        }

        public string EngEncrypt(string text)
        {
            text = text.ToLower();

            string result_text = "";

            if (text.Length % 2 != 0)
            {
                text += 'z';
            }
            int length = text.Length / 2;
            int k = 0;
            char[,] bigram = new char[length, 2];
            char[,] kripto_bigram = new char[length, 2];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    bigram[i, j] = text[k];
                    k++;
                }
            }

            print();

            int step = 0;
            while (step < length)
            {
                Cortege cortege1 = FindIndexes(bigram[step, 0], firstMatrix);
                Cortege cortege2 = FindIndexes(bigram[step, 1], secondMatrix);

                kripto_bigram[step, 0] = secondMatrix[cortege1.I, cortege2.J];
                kripto_bigram[step, 1] = firstMatrix[cortege2.I, cortege1.J];

                step++;
            }

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result_text += kripto_bigram[i, j].ToString();
                }
                result_text += " ";
            }
            return result_text;
        }

        public string EngDecrypt(string text)
        {
            string result_text = "";

            text = text.ToLower();
            int length = text.Length / 2;
            int k = 0;

            char[,] bigram = new char[length, 2];
            char[,] kripto_bigram = new char[length, 2];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    bigram[i, j] = text[k];
                    k++;
                }
            }

            print();

            int step = 0;
            while (step < length)
            {
                Cortege cortege1 = FindIndexes(bigram[step, 0], second_matrix);
                Cortege cortege2 = FindIndexes(bigram[step, 1], firstMatrix);

                kripto_bigram[step, 0] = firstMatrix[cortege1.I, cortege2.J];
                kripto_bigram[step, 1] = second_matrix[cortege2.I, cortege1.J];

                step++;
            }

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result_text += kripto_bigram[i, j].ToString();
                }
            }
            return result_text;
        }

        private Cortege FindIndexes(char symbol, char[,] matrix)
        {
            Cortege cortege = new Cortege();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (symbol == matrix[i, j])
                    {
                        cortege.I = i;
                        cortege.J = j;
                        return cortege;
                    }
                }
            }

            return null;
        }

        public void print()
        {
            Console.Write("left key: ");
            string leftKey = Convert.ToString(Console.ReadLine());
            Console.Write("right key: ");
            string rightKey = Convert.ToString(Console.ReadLine());
            char[,] firstMatrix = new char[8, 4];
            firstMatrix = RusMatrix(firstMatrix, leftKey);

            Console.WriteLine("first matrix:");
            for (int i = 0; i < firstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < firstMatrix.GetLength(1); j++)
                {
                    Console.Write("\t" + firstMatrix[i, j]);
                }
                Console.WriteLine();
            }

            char[,] secondMatrix = new char[8, 4];
            secondMatrix = RusMatrix(secondMatrix, rightKey);
            Console.WriteLine("second matrix");
            for (int i = 0; i < secondMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < secondMatrix.GetLength(1); j++)
                {
                    Console.Write("\t" + secondMatrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private class Cortege
        {
            public int I { get; set; }
            public int J { get; set; }
            public Cortege() { }
        }
    }
}

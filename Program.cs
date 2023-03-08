using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MyArray
{
    public int[,] array; //Поля об'єктів

    public MyArray(int size) //Конструктор
    {
        array = new int[size, size];
    }


    public void SetMass(int size) //Функція заповнення масиву
    {
        Console.WriteLine("Ввід масиву");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                try
                {
                    int input_value = Convert.ToInt32(Console.ReadLine());
                    array[i, j] = input_value;
                }
                catch (Exception)
                {
                    Console.WriteLine("Помилка");
                    Environment.Exit(1);    
                }
            }
            Console.WriteLine();
        }
    }

    //вивід масиву
    public void DisplayArr(int [,] arr)
    {
        Console.WriteLine("масив: ");
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write(arr[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    //сума елекментів у рядку, якщо у ньому є від'ємне значення
    public void SumInRow(int[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            bool hasNegative = false;
            int sum = 0;

            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] < 0)
                {
                    hasNegative = true;
                }

                sum += arr[i, j];
            }

            if (hasNegative)
            {
                Console.WriteLine("Сума елементів рядка {0}: {1}", i + 1, sum);
            }
        }
    }


    public void FindSaddlePoints(int[,] arr)
    {
        int rows = arr.GetLength(0);
        int cols = arr.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            // знаходимо мінімальний елемент у рядку
            int minInRow = arr[i, 0];
            int minIndex = 0;
            for (int j = 1; j < cols; j++)
            {
                if (arr[i, j] < minInRow)
                {
                    minInRow = arr[i, j];
                    minIndex = j;
                }
            }

            // перевіряємо, чи цей елемент є максимальним у стовпці
            bool isSaddle = true;
            for (int k = 0; k < rows; k++)
            {
                if (arr[k, minIndex] > minInRow)
                {
                    isSaddle = false;
                    break;
                }
            }

            // якщо елемент є сідловою точкою, виводимо його координати
            if (isSaddle)
            {
                Console.WriteLine("Сідлова точка: ({0},{1})", i, minIndex);
            }
        }
    }
}


internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("розмірність масиву: ");
            int size = Convert.ToInt32(Console.ReadLine());
            MyArray array = new MyArray(size);
            array.SetMass(size);
            array.DisplayArr(array.array);
            array.SumInRow(array.array);
            array.FindSaddlePoints(array.array);
        }
        catch(Exception)
        {
            Console.WriteLine("Помилка");
        }
    }
}

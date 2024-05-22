using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main()
    {
        Console.WriteLine("Wybierz rozmiar tablicy: ");
        string input = Console.ReadLine();
        int size = 5;
        try
        {
            size = int.Parse(input);
        }
        catch (FormatException)
        {
            Console.WriteLine("Zły wybór.");
        }


        double[] array = new double[size];
        WypelnijTablice(array);
        Console.WriteLine("\nTablica przed sortowaniem:");
        PrintArray(array);

        Sortowanie(array, 0, array.Length - 1);
        Console.WriteLine("\nTablica po sortowaniu:");
        PrintArray(array);
    }
    static void WypelnijTablice(double[] array)
    {
        Random randNum = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            double randomNumber = randNum.NextDouble() * 100;
            array[i] = Math.Truncate(randomNumber * Math.Pow(10, 2)) / Math.Pow(10, 2);

        }
    }
    static int Dzielenie(double[] array, int low, int high)
    {
        double pivot = array[high];
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (array[j] <= pivot)
            {
                i++;
                Zamien(ref array[i],ref array[j]); 
            }
        }
        Zamien(ref array[i + 1], ref array[high]);
        return i + 1;
    }

    static void Zamien(ref double x, ref double y) //"Ref" użyte aby zamienić zmienne miejscami (w innym przypadku wychodziło null w miejscach tablic)
    {
        double temp = x;
        x = y;
        y = temp;
    }

    static void PrintArray(double[] array)
    {
        foreach (var zmienna in array)
        {
            Console.Write(zmienna + " ");
        }
        Console.WriteLine();
    }

    static void Sortowanie(double[] array, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Dzielenie(array, low, high);
            Sortowanie(array, low, pivotIndex - 1);
            Sortowanie(array, pivotIndex + 1, high);
        }
    }
}

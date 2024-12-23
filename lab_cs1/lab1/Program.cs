using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        double a = 0, b = 0, c = 0;
        bool validA = false, validB = false, validC = false;

        // Чтение коэффициентов из командной строки
        if (args.Length >= 3)
        {
            validA = TryParseDouble(args[0], out a);
            validB = TryParseDouble(args[1], out b);
            validC = TryParseDouble(args[2], out c);
        }

        // Если данные некорректны, запрашиваем ввод с клавиатуры
        if (!validA)
        {
            a = GetCoefficient("Введите коэффициент A: ");
        }
        if (!validB)
        {
            b = GetCoefficient("Введите коэффициент B: ");
        }
        if (!validC)
        {
            c = GetCoefficient("Введите коэффициент C: ");
        }

        // Проверяем, что уравнение действительно биквадратное
        if (a == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Коэффициент A не может быть равен 0. Это не биквадратное уравнение.");
            Console.ResetColor();
            return;
        }

        // Вычисляем дискриминант
        double discriminant = b * b - 4 * a * c;
        Console.WriteLine($"Дискриминант: {discriminant}");

        // Находим возможные корни по значениям дискриминанта
        if (discriminant < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Действительных корней нет.");
            Console.ResetColor();
        }
        else
        {
            // Корни квадратного уравнения
            double sqrtDiscriminant = Math.Sqrt(discriminant);
            double x1 = (-b + sqrtDiscriminant) / (2 * a);
            double x2 = (-b - sqrtDiscriminant) / (2 * a);

            // Вывод корней биквадратного уравнения
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Действительные корни уравнения:");

            bool hasRealRoots = false;
            if (x1 >= 0)
            {
                Console.WriteLine($"{Math.Sqrt(x1):F3}, {-Math.Sqrt(x1):F3}");
                hasRealRoots = true;
            }

            if (x2 >= 0 && !AreEqual(x1, x2)) // Проверка на уникальность корней
            {
                Console.WriteLine($"{Math.Sqrt(x2):F3}, {-Math.Sqrt(x2):F3}");
                hasRealRoots = true;
            }

            if (!hasRealRoots)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нет положительных корней, следовательно, корней у биквадратного уравнения нет.");
            }
            
            Console.ResetColor();
        }
    }

    // Метод для обработки некорректного ввода коэффициентов с клавиатуры
    static double GetCoefficient(string prompt)
{
    double coefficient;
    Console.Write(prompt);
    string? input; // nullable string

    while (string.IsNullOrEmpty(input = Console.ReadLine()) || !TryParseDouble(input, out coefficient))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Некорректное значение. Пожалуйста, введите действительное число.");
        Console.ResetColor();
        Console.Write(prompt);
    }

    return coefficient;
}


    // Метод безопасного парсинга строки в число
    static bool TryParseDouble(string input, out double result)
    {
        return double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out result);
    }

    // Метод сравнения двух чисел с учетом погрешности
    static bool AreEqual(double value1, double value2, double tolerance = 1E-10)
    {
        return Math.Abs(value1 - value2) < tolerance;
    }
}

using System;

// Абстрактный класс "Геометрическая фигура"
abstract class GeometricFigure
{
    // Виртуальный метод для вычисления площади
    public abstract double CalculateArea();

    // Переопределение ToString() будет выполнено в дочерних классах
}

// Интерфейс IPrint
interface IPrint
{
    void Print();
}

// Класс "Прямоугольник", наследуемый от GeometricFigure
class Rectangle : GeometricFigure, IPrint
{
    // Свойства
    public double Width { get; set; }
    public double Height { get; set; }

    // Конструктор
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    // Переопределяем метод для вычисления площади
    public override double CalculateArea()
    {
        return Width * Height;
    }

    // Переопределяем ToString()
    public override string ToString()
    {
        return $"Прямоугольник: ширина = {Width}, высота = {Height}, площадь = {CalculateArea():F2}";
    }

    // Реализация метода Print() из IPrint
    public void Print()
    {
        Console.WriteLine(ToString());
    }
}

// Класс "Квадрат", наследуемый от Rectangle
class Square : Rectangle
{
    // Конструктор
    public Square(double side) : base(side, side) { }

    // Переопределяем ToString()
    public override string ToString()
    {
        return $"Квадрат: длина стороны = {Width}, площадь = {CalculateArea():F2}";
    }
}

// Класс "Круг", наследуемый от GeometricFigure
class Circle : GeometricFigure, IPrint
{
    // Свойство
    public double Radius { get; set; }

    // Конструктор
    public Circle(double radius)
    {
        Radius = radius;
    }

    // Переопределяем метод для вычисления площади
    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    // Переопределяем ToString()
    public override string ToString()
    {
        return $"Круг: радиус = {Radius}, площадь = {CalculateArea():F2}";
    }

    // Реализация метода Print() из IPrint
    public void Print()
    {
        Console.WriteLine(ToString());
    }
}

// Главный класс программы
class Program
{
    static void Main(string[] args)
    {
        // Ввод данных для прямоугольника
        Console.Write("Введите ширину прямоугольника: ");
        double rectWidth = double.Parse(Console.ReadLine());
        Console.Write("Введите высоту прямоугольника: ");
        double rectHeight = double.Parse(Console.ReadLine());

        Rectangle rectangle = new Rectangle(rectWidth, rectHeight);

        // Ввод данных для квадрата
        Console.Write("Введите длину стороны квадрата: ");
        double squareSide = double.Parse(Console.ReadLine());

        Square square = new Square(squareSide);

        // Ввод данных для круга
        Console.Write("Введите радиус круга: ");
        double circleRadius = double.Parse(Console.ReadLine());

        Circle circle = new Circle(circleRadius);

        // Вывод информации
        Console.WriteLine("\nРезультаты:");
        rectangle.Print();
        square.Print();
        circle.Print();

        // Ожидание ввода, чтобы программа не закрылась сразу
        Console.ReadLine();
    }
}

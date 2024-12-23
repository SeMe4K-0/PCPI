import sys
import math

def get_coefficient(prompt):
    while True:
        try:
            value = float(input(prompt))
            return value
        except ValueError:
            print("Ошибка: введите корректное число.")

def solve_biquadratic(a, b, c):
    # Проверка коэффициента a на равенство 0
    if a == 0:
        print("Это не биквадратное уравнение. Коэффициент 'а' не может быть равен 0.")
        return

    # Вычисление дискриминанта
    discriminant = b ** 2 - 4 * a * c

    print(f"Дискриминант: {discriminant}")

    # Если дискриминант меньше нуля - действительных корней нет
    if discriminant < 0:
        print("Действительных корней нет.")
        return

    # Вычисление корней квадратного уравнения
    sqrt_discriminant = math.sqrt(discriminant)
    x1 = (-b + sqrt_discriminant) / (2 * a)
    x2 = (-b - sqrt_discriminant) / (2 * a)

    # Проверка и вывод действительных корней биквадратного уравнения
    roots = []
    for x in (x1, x2):
        if x >= 0:  # Т.к. корень из отрицательного числа в вещественных числах невозможен
            roots.append(math.sqrt(x))
            roots.append(-math.sqrt(x))

    if roots:
        roots = list(set(roots))  # Удаление возможных дубликатов
        print("Действительные корни:", roots)
    else:
        print("Действительных корней нет.")

def main():
    # Чтение коэффициентов из командной строки
    argv = sys.argv[1:]
    if len(argv) >= 3:
        try:
            a = float(argv[0])
        except ValueError:
            a = get_coefficient("Введите коэффициент A: ")
        try:
            b = float(argv[1])
        except ValueError:
            b = get_coefficient("Введите коэффициент B: ")
        try:
            c = float(argv[2])
        except ValueError:
            c = get_coefficient("Введите коэффициент C: ")
    else:
        print("Коэффициенты не заданы или заданы некорректно.")
        a = get_coefficient("Введите коэффициент A: ")
        b = get_coefficient("Введите коэффициент B: ")
        c = get_coefficient("Введите коэффициент C: ")

    solve_biquadratic(a, b, c)

if __name__ == "__main__":
    main()
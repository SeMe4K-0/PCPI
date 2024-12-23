import sys
import math

class BiquadraticSolver:
    def __init__(self, a=None, b=None, c=None):
        self.a = a
        self.b = b
        self.c = c

    def get_coefficient(self, name):
        while True:
            try:
                value = float(input(f"Введите коэффициент {name}: "))
                return value
            except ValueError:
                print("Ошибка: введите корректное число.")

    def read_coefficients(self):
        # Коэффициент A
        if self.a is None:
            self.a = self.get_coefficient('A')
        # Коэффициент B
        if self.b is None:
            self.b = self.get_coefficient('B')
        # Коэффициент C
        if self.c is None:
            self.c = self.get_coefficient('C')

    def solve(self):
        if self.a == 0:
            print("Это не биквадратное уравнение. Коэффициент 'а' не может быть равен 0.")
            return

        discriminant = self.b ** 2 - 4 * self.a * self.c
        print(f"Дискриминант: {discriminant}")

        if discriminant < 0:
            print("Действительных корней нет.")
            return

        sqrt_discriminant = math.sqrt(discriminant)
        x1 = (-self.b + sqrt_discriminant) / (2 * self.a)
        x2 = (-self.b - sqrt_discriminant) / (2 * self.a)

        roots = []
        for x in (x1, x2):
            if x >= 0:
                roots.append(math.sqrt(x))
                roots.append(-math.sqrt(x))
        
        if roots:
            roots = list(set(roots))  # Удаляем дубликаты
            print("Действительные корни:", roots)
        else:
            print("Действительных корней нет.")

def main():
    argv = sys.argv[1:]
    a = b = c = None

    if len(argv) >= 3:
        try:
            a = float(argv[0])
        except ValueError:
            pass
        try:
            b = float(argv[1])

        except ValueError:
            pass
        try:
            c = float(argv[2])
        except ValueError:
            pass

    solver = BiquadraticSolver(a, b, c)
    solver.read_coefficients()
    solver.solve()

if __name__ == "__main__":
    main()
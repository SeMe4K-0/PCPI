// ▎1. Два варианта функции, возвращающей кортеж значений

// Вариант 1: принимаем параметры как кортеж
let tupleFunction (x, y, z) = (x, y, z)

// Вариант 2: принимаем параметры в каррированном виде
let curriedFunction x y z = (x, y, z)

// Пример вызова:
let result1 = tupleFunction (1, 2, 3)  // Результат: (1, 2, 3)
let result2 = curriedFunction 1 2 3    // Результат: (1, 2, 3)
printfn "Tuple Function Result: %A" result1
printfn "Curried Function Result: %A" result2


// ▎2. Рекурсивная функция для выполнения алгоритма (сумма диапазона)

// Реализация суммы всех чисел в заданном диапазоне
let rec sumRange a b =
    if a > b then 0
    else a + sumRange (a + 1) b

// Пример вызова:
let rangeSum = sumRange 1 10  // Результат: 55
printfn "Sum of range: %d" rangeSum


// ▎3. Преобразование в хвостовую рекурсию

// Суммирование диапазона с использование хвостовой рекурсии
let sumRangeTailRecursive a b =
    let rec helper acc current max =
        if current > max then acc
        else helper (acc + current) (current + 1) max
    helper 0 a b

// Пример вызова:
let tailSum = sumRangeTailRecursive 1 10  // Результат: 55
printfn "Tail Recursive Sum of range: %d" tailSum


// ▎4. Конечный автомат из трёх состояний

// Реализация конечного автомата с 3 состояниями
type State = StateA | StateB | StateC

let rec transition state input =
    match state, input with
    | StateA, "toB" -> StateB
    | StateA, "toC" -> StateC
    | StateB, "toA" -> StateA
    | StateB, "toC" -> StateC
    | StateC, "toA" -> StateA
    | StateC, "toB" -> StateB
    | _, _ -> state  // Оставаться в текущем состоянии, если ввод некорректен

// Пример использования:
let currentState = StateA
let nextState = transition currentState "toB"
let finalState = transition nextState "toC"
printfn "Final State: %A" finalState


// ▎5. Функция с тремя целыми числами и лямбда-выражениями

// Функция, принимающая целые числа и лямбда-выражение
let sumWithLambda lambda x y z = lambda (x, y, z)

// Пример лямбда-выражения (для кортежной формы)
let tupleLambda (x, y, z) = x + y + z

// Пример вызова:
let resultTuple = sumWithLambda tupleLambda 1 2 3   // Результат: 6

// Реализация для каррированной формы
let sumWithCurriedLambda curriedLambda x y z = curriedLambda x y z

// Пример лямбда-выражения (для каррированной формы)
let curriedLambda x y z = x + y + z

// Пример вызова:
let resultCurried = sumWithCurriedLambda curriedLambda 1 2 3  // Результат: 6

// Вывод результатов:
printfn "Sum with Tuple Lambda: %d" resultTuple
printfn "Sum with Curried Lambda: %d" resultCurried

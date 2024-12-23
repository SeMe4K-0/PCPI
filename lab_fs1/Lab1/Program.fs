// Алгебраический тип для корней
type Roots =
    | None                       // Нет корней
    | Complex                    // Комплексные корни
    | RealRoots of float list    // Действительные корни

// Решение квадратного уравнения: a*y^2 + b*y + c = 0
let solveQuadratic (a: float) (b: float) (c: float) : Roots =
    let delta = b ** 2.0 - 4.0 * a * c // Дискриминант
    if delta < 0.0 then
        Complex // Если дискриминант меньше нуля, корни комплексные
    elif delta = 0.0 then
        RealRoots [ -b / (2.0 * a) ] // Единственный корень
    else
        RealRoots [ 
            (-b + sqrt delta) / (2.0 * a); 
            (-b - sqrt delta) / (2.0 * a) 
        ]

// Решение биквадратного уравнения: a*x^4 + b*x^2 + c = 0
let solveBiquadratic (a: float) (b: float) (c: float) : Roots =
    if a = 0.0 then
        failwith "Коэффициент 'a' не может быть равен нулю." // Проверка a ≠ 0
    else
        match solveQuadratic a b c with
        | None -> None // Если квадратное уравнение не имеет решений
        | Complex -> Complex // Комплексные корни
        | RealRoots rootsY -> 
            let computeX ys =
                ys
                |> List.collect (fun y ->
                    if y < 0.0 then [] // Если y < 0, то x^2 = y не имеет действительных решений
                    elif y = 0.0 then [ 0.0 ] // Единственный корень x = 0
                    else [ sqrt y; -sqrt y ] // Два корня: x = ±√y
                )
            RealRoots (computeX rootsY)

// Пример запуска программы
[<EntryPoint>]
let main argv =
    printfn "Введите коэффициенты a, b, c для уравнения a*x^4 + b*x^2 + c = 0:"

    // Считываем коэффициенты a, b, c
    printf "Введите a: "
    let a = System.Console.ReadLine() |> float
    printf "Введите b: "
    let b = System.Console.ReadLine() |> float
    printf "Введите c: "
    let c = System.Console.ReadLine() |> float

    // Решаем уравнение
    let result = solveBiquadratic a b c

    // Выводим результат
    match result with
    | None -> printfn "Нет действительных решений."
    | Complex -> printfn "Корни комплексные."
    | RealRoots roots -> printfn "Действительные корни: %A" roots

    0 // Код завершения программы

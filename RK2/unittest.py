import unittest
import main


class TestDataRowTable(unittest.TestCase):
    # Таблицы данных
    tables = [
        main.DataTable(1, 'Товары'),
        main.DataTable(2, 'Поставщики'),
        main.DataTable(3, 'Клиенты'),
    ]
    
    # Строки данных
    rows = [
        main.DataRow(1, 'Яблоки', 1),
        main.DataRow(2, 'Груши', 1),
        main.DataRow(3, 'ООО "Фруктовый Сад"', 2),
        main.DataRow(4, 'ООО "Свежие Поставки"', 2),
        main.DataRow(5, 'Иван Иванов', 3),
    ]
    
    # Связи строки с таблицами
    rows_tables = [
        main.DataRowTable(1, 1),
        main.DataRowTable(1, 2),
        main.DataRowTable(2, 3),
        main.DataRowTable(2, 4),
        main.DataRowTable(3, 5)
    ]
    
    # Построить `one_to_many` и `many_to_many` для тестов
    one_to_many = main.make_one_to_many(rows, tables)
    many_to_many = main.make_many_to_many(rows, tables, rows_tables)

    def test_do_task_one(self):
        result_1 = main.do_task_one(self.one_to_many)
        result_2 = [('ООО "Фруктовый Сад"', 'Поставщики'), ('ООО "Свежие Поставки"', 'Поставщики')]
        self.assertEqual(result_1, result_2)

    def test_do_task_two(self):
        result_1 = main.do_task_two(self.one_to_many, self.tables)
        result_2 = [('Товары', 1), ('Поставщики', 3), ('Клиенты', 5)]
        self.assertEqual(result_1, result_2)

    def test_do_task_three(self):
        result_1 = main.do_task_three(self.many_to_many)
        result_2 = [
            ('Груши', 'Товары'),
            ('Иван Иванов', 'Клиенты'),
            ('ООО "Фруктовый Сад"', 'Поставщики'),
            ('ООО "Свежие Поставки"', 'Поставщики'),
            ('Яблоки', 'Товары'),
        ]
        self.assertEqual(result_1, result_2)


if __name__ == '__main__':
    unittest.main()

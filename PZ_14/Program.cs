namespace PZ_14
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Введите целое число x (не более 100): ");
                int x = Convert.ToInt32(Console.ReadLine());
                if (x > 0 && x <= 100)
                {
                    string filePath = "output.txt"; // Имя файла, куда будем записывать результат
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        // Формирование звездочек
                        for (int i = 1; i <= x; i++)
                        {
                            string line;
                            if (i <= x / 2)
                            {
                                line = new string('*', i);
                            }
                            else
                            {
                                line = new string('*', x - i + 1);
                            }

                            // Запись строки в файл
                            writer.WriteLine(line);

                            Console.WriteLine(line);
                        }

                        Console.WriteLine($"Результат записан в файл: {filePath}");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: Введите корректное целое число от 1 до 100.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
namespace PZ_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите полный путь:");
            string directory = Console.ReadLine();

            try
            {
                // Проверяем, существует ли указанный каталог
                if (!Directory.Exists(directory))
                {
                    throw new DirectoryNotFoundException("каталога " + directory + " нет");
                }

                // Получаем список файлов в указанном каталоге
                string[] arr = Directory.GetFiles(directory);

                Console.WriteLine("Нынешний список файлов в директокрии: ");
                foreach (string filePath in arr)
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    double size = fileInfo.Length / 1024.0; // Размер файла в Кб
                    Console.WriteLine($"{fileInfo.Name}: {size} Кб");
                }

                foreach (string filePath in arr)
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    double size = fileInfo.Length / 1024.0; // Размер файла в Кб

                    if (size < 10)
                    {
                        Console.WriteLine("Введите новые данные для файла");
                        string file = Console.ReadLine();   
                        File.AppendAllText(filePath, file);
                    }
                }

                Console.WriteLine("Новый список файлов:");
                foreach (string filePath in arr)
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    double fileSizeKb = fileInfo.Length / 1024.0; 
                    Console.WriteLine($"{fileInfo.Name}: {fileSizeKb} Кб");
                }
            }
            catch (DirectoryNotFoundException excep)
            {
                Console.WriteLine("Произошла ошибка " + excep.Message);
            } 
            catch (Exception excep)
            {
                Console.WriteLine("Произошла ошибка " + excep.Message);
            }
        }
    }
}
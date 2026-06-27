namespace FileDirectoryPath
{
    internal class Program
    {
        static void PathDirectory()
        {
            string folder = @"C:\Users\traig\Downloads";
            string imageName = "image.webp";

            // Об'єднати декілька string у один шлях
            string imagePath = Path.Combine(folder, imageName);
            Console.WriteLine(imagePath);

            // Перевірка чи існує такий файл або папка
            Console.WriteLine(Path.Exists(imagePath));

            // Розширення файлу
            Console.WriteLine(Path.GetExtension(imagePath));


            // Directory
            Console.WriteLine(Directory.GetCurrentDirectory());

            Console.WriteLine(Directory.GetDirectoryRoot(imagePath));

            string currentDir = Directory.GetCurrentDirectory();
            string folderName = "files";
            string dirPath = Path.Combine(currentDir, folderName);
            Directory.CreateDirectory(dirPath);

            // Directory.Delete(dirPath);

            string[] dirs = Directory.GetDirectories("C:\\itstep\\3 Семестр\\SPR521\\repo\\C#\\FileDirectoryPath\\FileDirectoryPath");
            Console.WriteLine("Directories");
            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
            }

            string[] files = Directory.GetFiles("C:\\itstep\\3 Семестр\\SPR521\\repo\\C#\\FileDirectoryPath\\FileDirectoryPath");
            Console.WriteLine("Files");
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }

            Console.WriteLine(Directory.Exists("C:/itstep"));
        }

        static void FileClass()
        {
            // File

            string currentDir = Directory.GetCurrentDirectory();
            string filesDir = "files";
            string fileName = "data.txt";

            string filePath = Path.Combine(currentDir, filesDir, fileName);

            if (File.Exists(filePath))
            {
                string text = File.ReadAllText(filePath);
                Console.WriteLine(text);
            }
            else
            {
                File.WriteAllText(filePath, "Hello static class 'File'");
            }


            // Copy image
            File.Copy(@"C:\Users\traig\Downloads\image.webp", @"C:\Users\traig\Desktop\text.webp");
        }

        static void FileDirectoryInfo()
        {
            // DirectoryInfo
            // FileInfo

            string current = Directory.GetCurrentDirectory();
            var filesDir = new DirectoryInfo(Path.Combine(current, "files"));

            if (!filesDir.Exists)
            {
                filesDir.Create();
            }

            filesDir.CreateSubdirectory("data");
            Console.WriteLine(filesDir.Name);


            FileInfo file = new FileInfo(Path.Combine(filesDir.FullName, "image.webp"));


            Console.WriteLine(file.FullName);
            Console.WriteLine(file.Name);
            Console.WriteLine(file.Extension);
            Console.WriteLine(file.Length);
            Console.WriteLine(file.CreationTime);
            Console.WriteLine(file.IsReadOnly);
            Console.WriteLine(file.LastAccessTime);
        }

        static void Main(string[] args)
        {
            // PathDirectory();

            // FileClass();


            // Класи для яких можна створювати об'єкти
            // FileDirectoryInfo();




            // Файловий менеджер

            FileManager fm = new FileManager();
            fm.Start();
        }
    }
}

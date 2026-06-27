using System.Text;

namespace Stream_File
{
    public class NetworkTool : IDisposable
    {
        private bool connection;

        public NetworkTool()
        {
            connection = true;
        }

        public void Disconnect()
        {
            connection = false;
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose");
            Disconnect();
        }
    }

    public class User
    {

    }

    internal class Program
    {
        static void DisposeTemplate()
        {
            // using - конструкція яка приймає об'єкт з інтерфейсом IDisposable та в кінці автоматично викликає метод Dispose
            // using те само try finally

            using (NetworkTool network = new NetworkTool())
            {
                // code
                Console.WriteLine("Code");
            }

            //using NetworkTool network = new NetworkTool();


            // Буде помилка тому, що клас не реалізує IDisposable
            //using (User user = new User())
            //{

            //}
        }

        static void FileStreamWrite()
        {
            using (FileStream fs = new FileStream("text.txt", FileMode.Create, FileAccess.Write))
            {
                string message = "Streams, files and Dipose";

                byte[] bytes = Encoding.UTF8.GetBytes(message);
                fs.Write(bytes);
            }
        }

        static void FileStreamRead()
        {
            using (FileStream fs = new FileStream("text.txt", FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[fs.Length];
                int len = fs.Read(buffer);

                string fileText = Encoding.UTF8.GetString(buffer);
                Console.WriteLine(fileText);
            }
        }

        static void FileStreamSeek()
        {
            try
            {
                using (FileStream fs = new FileStream("text.txt", FileMode.Open, FileAccess.Read))
                {
                    // Робота з позицією (seek)


                    //byte[] buffer = new byte[20];
                    //fs.Seek(33, SeekOrigin.Begin);
                    //fs.Read(buffer, 0, 20);
                    //string text = Encoding.UTF8.GetString(buffer);
                    //Console.WriteLine(text);

                    fs.Seek(0, SeekOrigin.Begin);
                    int seek = 0;
                    TimeSpan start = DateTime.Now.TimeOfDay;
                    while (seek < fs.Length)
                    {
                        int b = fs.ReadByte();
                        char c = (char)b;
                        if (char.IsLetterOrDigit(c))
                        {
                            Console.Write(c);
                        }
                        seek++;
                    }
                    Console.WriteLine();
                    TimeSpan end = DateTime.Now.TimeOfDay;
                    Console.WriteLine("Time:" + (end - start).TotalMilliseconds + "ms");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File 'text.txt' not found");
            }
        }

        static void StreamReadWriter()
        {
            using (StreamWriter sw = new StreamWriter("lorem.txt"))
            {
                string text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since 1966, when designers at Letraset and James Mosley, the librarian at St Bride Printing Library in London, took a 1914 Cicero translation and scrambled it to make dummy text for Letraset's Body Type sheets. It has survived not only many decades, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised thanks to these sheets and more recently with desktop publishing software like Aldus PageMaker and Microsoft Word including versions of Lorem";

                sw.WriteLine(text);
                sw.WriteLine(text);
            }

            using (StreamReader sr = new StreamReader("streams.txt"))
            {
                // Читає весь текст у файлі
                // string text = sr.ReadToEnd();

                // Читає тільки один рядок
                //while(!sr.EndOfStream)
                //{
                //    string text = sr.ReadLine();
                //    Console.WriteLine(text);
                //}

                // Читає певну к-сть символів
                char[] buffer = new char[10];
                sr.ReadBlock(buffer, 0, 10);
                Console.WriteLine(buffer);
            }
        }

        static void BinaryStreams()
        {
            // Write
            using (FileStream fs = new FileStream("file.bin", FileMode.Create, FileAccess.Write))
            {

                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    bw.Write(25);
                    bw.Write(true);
                    bw.Write('a');
                }
            }

            // Read
            using (FileStream fs = new FileStream("file.bin", FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    int a = br.ReadInt32();
                    bool b = br.ReadBoolean();
                    char c = br.ReadChar();

                    Console.WriteLine(a);
                    Console.WriteLine(b);
                    Console.WriteLine(c);
                }
            }
        }
		
		static void CopyImage()
		{
			string imagePath = @"C:\Users\traig\Downloads\image.webp";
            using (FileStream fsr = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream fsw = new FileStream("copiedImage.webp", FileMode.Create, FileAccess.Write))
                {
                    fsr.CopyTo(fsw);
                }
            }
		}


        static void Main(string[] args)
        {
            // DisposeTemplate();


            // Stream - базовий, абстрактний клас для всіх інших потоків(streams)


            // FileStream - базовий потік для роботи з файлами

            // == Write ==
            // FileStreamWrite();

            // == Read ==
            // FileStreamRead();

            // == Робота з позицією ==
            // FileStreamSeek();

            // == StreamRead and StreamWriter ==
            //StreamReadWriter();

            // BinaryReader and BinaryWriter
            // BinaryStreams();


            // Копіювання зображення
            // CopyImage();
        }
    }
}

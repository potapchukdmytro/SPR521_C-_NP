namespace FileDirectoryPath
{
    enum Direction
    {
        Up,
        Down
    }

    public class FileManager
    {
        private string currentDir;
        private string rootDir;
        private int pos = 0;
        private bool running = false;

        private Dictionary<ConsoleKey, Action> events;

        public FileManager()
        {
            rootDir = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory());
            currentDir = rootDir;

            events = new Dictionary<ConsoleKey, Action>
            {
                { ConsoleKey.UpArrow, () => { Move(Direction.Up); } },
                { ConsoleKey.DownArrow, () => { Move(Direction.Down); } },
                { ConsoleKey.Escape, Stop },
                { ConsoleKey.Enter, Open }
            };
        }

        public List<FileInfo> GetFiles()
        {
            var filesPath = Directory.GetFiles(currentDir);

            var files = filesPath.Select(fp => new FileInfo(fp));
            return files.ToList();
        }

        public List<DirectoryInfo> GetDirectories()
        {
            var dirsPath = Directory.GetDirectories(currentDir);

            var dirs = dirsPath.Select(fp => new DirectoryInfo(fp));
            return dirs.ToList();
        }

        public void Start()
        {
            running = true;
            while(running)
            {
                Console.Clear();
                PrintItems();
                ConsoleKey key = Console.ReadKey(true).Key;
                KeyHandler(key);
            }
        }

        public void Open()
        {
            var dirs = GetDirectories();

            if(pos < dirs.Count)
            {
                var dir = dirs[pos];
                pos = 0;
                currentDir = dir.FullName;
            }
        }

        public void Stop()
        {
            running = false;
        }

        private void Move(Direction direction)
        {
            if(direction == Direction.Up)
            {
                if (pos > 0)
                {
                    pos--;
                }
            }
            else if(direction == Direction.Down)
            {
                if (pos < ItemsCount() - 1)
                {
                    pos++;
                }
            }
        }

        private void KeyHandler(ConsoleKey key)
        {
            bool res = events.TryGetValue(key, out Action? action);
            if(res)
            {
                action?.Invoke();
            }
        }

        public int ItemsCount()
        {
            return GetFiles().Count + GetDirectories().Count;
        }

        public void PrintItems()
        {
            var dirs = GetDirectories();
            var files = GetFiles();
            int index = 0;

            foreach (var dir in dirs)
            {
                if(index == pos)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("->" + dir.Name);
                    Console.ResetColor();

                }
                else
                {
                    Console.WriteLine("  " + dir.Name);
                }
                index++;
            }

            foreach (var file in files)
            {
                
                if (index == pos)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("->" + file.Name);
                    Console.ResetColor();

                }
                else
                {
                    Console.WriteLine("  " + file.Name);
                }
                index++;
            }
        }
    }
}

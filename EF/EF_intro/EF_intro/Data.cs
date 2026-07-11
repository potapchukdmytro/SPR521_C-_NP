using EF_intro.Models;

namespace EF_intro
{
    public static class Data
    {
        public static List<Product> products = new List<Product>
        {
            new()
            {
                Name = "Ноутбук Lenovo IdeaPad 5",
                Price = 28999.99,
                Amount = 12,
                Description = "Потужний ноутбук для навчання та роботи."
            },
            new()
            {
                Name = "Бездротова миша Logitech M185",
                Price = 649.50,
                Amount = 35,
                Description = "Компактна бездротова миша з USB-приймачем."
            },
            new()
            {
                Name = "Механічна клавіатура Hator Rockfall",
                Price = 2499.00,
                Amount = 18,
                Description = "Ігрова механічна клавіатура з RGB-підсвіткою."
            },
            new()
            {
                Name = "Монітор Samsung 27\"",
                Price = 7699.90,
                Amount = 10,
                Description = "IPS-монітор з роздільною здатністю Full HD."
            },
            new()
            {
                Name = "Навушники JBL Tune 510BT",
                Price = 1899.99,
                Amount = 22,
                Description = "Бездротові навушники з якісним звучанням."
            },
            new()
            {
                Name = "Смартфон Xiaomi Redmi Note 14",
                Price = 11499.00,
                Amount = 15,
                Description = "Сучасний смартфон з великим AMOLED-дисплеєм."
            },
            new()
            {
                Name = "Флеш-накопичувач Kingston 64GB",
                Price = 399.00,
                Amount = 60,
                Description = "USB 3.2 флешка для швидкого перенесення файлів."
            },
            new()
            {
                Name = "Зовнішній SSD Samsung T7 1TB",
                Price = 4699.99,
                Amount = 9,
                Description = "Швидкий портативний SSD для резервного копіювання."
            },
            new()
            {
                Name = "Вебкамера Logitech C920",
                Price = 3299.50,
                Amount = 14,
                Description = "Вебкамера Full HD для відеоконференцій."
            },
            new()
            {
                Name = "Маршрутизатор TP-Link Archer C6",
                Price = 1699.99,
                Amount = 20,
                Description = "Дводіапазонний Wi-Fi роутер."
            },
            new()
            {
                Name = "Повербанк Xiaomi 20000 mAh",
                Price = 1499.00,
                Amount = 30,
                Description = "Ємний зовнішній акумулятор із швидкою зарядкою."
            },
            new()
            {
                Name = "Колонки Edifier R1280DB",
                Price = 4999.99,
                Amount = 8,
                Description = "Активна акустична система з Bluetooth."
            },
            new()
            {
                Name = "Ігровий килимок Hator Tonn EVO",
                Price = 599.00,
                Amount = 45,
                Description = "Великий килимок для миші з прошитими краями."
            },
            new()
            {
                Name = "Мікрофон Fifine K669B",
                Price = 1699.90,
                Amount = 11,
                Description = "USB-мікрофон для стрімінгу та запису голосу."
            },
            new()
            {
                Name = "Принтер HP LaserJet M111w",
                Price = 5399.00,
                Amount = 7,
                Description = "Компактний лазерний принтер із Wi-Fi."
            },
            new()
            {
                Name = "Жорсткий диск Seagate 2TB",
                Price = 2899.99,
                Amount = 16,
                Description = "Надійний HDD для зберігання даних."
            },
            new()
            {
                Name = "Відеокарта MSI GeForce RTX 4060",
                Price = 17999.00,
                Amount = 6,
                Description = "Продуктивна відеокарта для сучасних ігор."
            },
            new()
            {
                Name = "Процесор AMD Ryzen 5 7600",
                Price = 9499.00,
                Amount = 13,
                Description = "Шестиядерний процесор для ігор та роботи."
            },
            new()
            {
                Name = "Оперативна пам'ять Kingston Fury 32GB",
                Price = 3599.99,
                Amount = 19,
                Description = "Комплект оперативної пам'яті DDR5."
            },
            new()
            {
                Name = "Корпус DeepCool CC560",
                Price = 2599.00,
                Amount = 10,
                Description = "Комп'ютерний корпус із гарною вентиляцією."
            }
        };
    }
}

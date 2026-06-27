using System.Net.Http.Json;

namespace http
{
    internal class Program
    {
        static async Task GetHtml()
        {
            HttpClient httpClient = new HttpClient();

            string url = "https://sinoptik.ua/";
            try
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("StatusCode: " + (int)response.StatusCode);

                    string content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Курс валю
        static async Task Currency()
        {
            string url = "https://api.privatbank.ua/p24api/pubinfo?exchange&json&coursid=11";
            HttpClient httpClient = new HttpClient();

            // Спосіб 1
            //var reponse = await httpClient.GetAsync(url);
            //if(reponse.IsSuccessStatusCode)
            //{
            //    string json = await reponse.Content.ReadAsStringAsync();

            //    CurrencyModel[] model = JsonSerializer.Deserialize<CurrencyModel[]>(json);

            //    foreach (var m in model)
            //    {
            //        double buy = double.Parse(m.buy);
            //        Console.WriteLine($"1 {m.ccy} = {buy:F2} грн.");
            //    }
            //}

            // Спосіб 2 тільки для даних типу json
            CurrencyModel[]? model = await httpClient.GetFromJsonAsync<CurrencyModel[]>(url);
            if (model != null)
            {
                foreach (var m in model)
                {
                    double buy = double.Parse(m.buy);
                    Console.WriteLine($"1 {m.ccy} = {buy:F2} грн.");
                }
            }
        }

        static async Task Main(string[] args)
        {

            // Get запит на сайт для отримання html
            // await GetHtml();


            // Отримання курсу валют з приват банк
            // await Currency();


            //string apiKey = "";
            //string url = $"https://api.openweathermap.org/data/2.5/weather?appid={apiKey}&q=rivne&units=metric";
            //HttpClient httpClient = new HttpClient();
            //var model = await httpClient.GetFromJsonAsync<WeatherModel>(url);

            //if(model != null)
            //{
            //    Console.WriteLine(model.main.temp);
            //    var sunrise = new DateTime(1970, 1, 1) + TimeSpan.FromSeconds(model.sys.sunrise + 3600 * 3);
            //    var sunset = new DateTime(1970, 1, 1) + TimeSpan.FromSeconds(model.sys.sunset + 3600 * 3);

            //    Console.WriteLine(sunrise.ToString());
            //    Console.WriteLine(sunset.ToString());
            //}



            // Випадкове фото котика
            string url = "https://cataas.com/cat";
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var type = response.Content.Headers.ContentType;
            string imageType = type.ToString().Split("/")[1];
            string imageName = Guid.NewGuid().ToString() + "." + imageType;

            var bytes = await response.Content.ReadAsByteArrayAsync();
            await File.WriteAllBytesAsync(imageName, bytes);
        }
    }
}

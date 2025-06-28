using HtmlAgilityPack;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace HTTP
{
    internal class Program
    {

        class Car
        {
            public string? FileName { get; set; }
            public string? Model { get; set; }
            public decimal? Price { get; set; }
            public string? VIN { get; set; }

            public override string ToString()
            {
                return $"{FileName} {Model} {Price} {VIN}";
            }

        }

        public static async Task DownloadFile(string url, string path)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    Console.WriteLine("Start download...");
                    byte[] bytes = await client.GetByteArrayAsync(url);
                    await File.WriteAllBytesAsync(path, bytes);
                    Console.WriteLine("Download completed successfully.");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        static async Task Main(string[] args)
        {
            //HttpListener listener = new HttpListener();

            //listener.Prefixes.Add("http://localhost:8080/connect/");
            //listener.Start();

            //var context = listener.GetContext();
            //var request = context.Request;
            //var response = context.Response;
            //var user = context.User;

            //Console.WriteLine($"адреса додатку: ");
            //Console.WriteLine($"адреса кліента : ");
            //Console.WriteLine($"адреса сервера : {request.Url}");
            //Console.WriteLine($"метод запиту : {request.HttpMethod}");
            ////Console.WriteLine($"користувач : {user.Identity.Name}");
            //Console.WriteLine($"заголовки:");
            //foreach (string key in request.Headers.Keys)
            //{
            //    Console.WriteLine($"заголовок : {key} = {request.Headers[key]}");
            //}

            //string responseString = @"
            //<!DOCTYPE html>
            //<html lang='en'>
            //    <head>
            //        <meta charset='UTF-8'>
            //        <title>First Document</title>
            //    </head>
            //    <body>
            //        <h1>Заголовок 1</h1>
            //        <h3>Lorem ipsum dolor sit.</h3>
            //        <p>Lorem ipsum dolor sit amet, <b>consectetur</b> <i>adipisicing</i> elit. <b>Expedita</b> optio, alias et reiciendis! Blanditiis, expedita optio possimus vero numquam temporibus eaque quos eum dolorem, necessitatibus illo vel repudiandae deserunt facere voluptatibus ab iste odit voluptatum consequuntur et veniam voluptas nam. Architecto deserunt fugiat, necessitatibus ipsam voluptates. Pariatur sunt tenetur, praesentium eius tempore necessitatibus delectus quos mollitia maiores numquam enim quisquam tempora eaque illo quam facere perspiciatis debitis deleniti unde explicabo alias ut! <br> Error nostrum, eos odit, quibusdam, harum fugiat autem nesciunt asperiores, optio maxime deleniti officia et delectus! Aspernatur quos unde optio, autem reprehenderit quibusdam vel ex dolorum, ullam dolor.</p>
            //        <hr>
            //        <p>x<sub>1</sub> = y<sup>2</sup></p>
            //        <blockquote>""Lorem ipsum dolor sit amet, consectetur adipisicing elit. Odit error amet deleniti asperiores ipsam laborum velit temporibus numquam quos dolor!""</blockquote>

            //        <h3>Lorem ipsum dolor sit amet.</h3>
            //        <p>Lorem ipsum dolor sit amet, <i>consectetur adipisicing</i> elit. Fugit, quas sint. Iste praesentium rerum voluptas, neque adipisci, ad maxime cum repudiandae ipsa necessitatibus vitae voluptatibus nesciunt ut, harum fuga suscipit!</p>
            //    </body>
            //</html>";

            //byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            //response.ContentLength64 = buffer.Length;
            //using (var output = response.OutputStream)
            //{
            //    output.Write(buffer, 0, buffer.Length);
            //}
            //response.Close();

            //listener.Stop();
            //listener.Close();




            /////// download file example
            ///
            //string url = "https://nsf-m4c-one-fr-01.sf-converter.com/prod-new/download/eyJtZWRpYUlkIjoiT0xQd1QwNWtZanciLCJ0aXRsZSI6IlNxdWlkIEdhbWU6IFNlYXNvbiAzIHwgRmluYWwgR2FtZXMgVHJhaWxlciB8IE5ldGZsaXgiLCJmb3JtYXQiOiJtcDQiLCJxdWFsaXR5IjoiNzIwIiwidGltZXN0YW1wIjoxNzUwOTU2MzUzfQ.63ccb8a3c02a61465dbab3e91bdbb2a5";
            //string path = "paashee.mp4";

            //await DownloadFile(url, path);




            //// pasing HTML example

            string url = "https://auto.ria.com/uk/legkovie/bmw/x6/?page=";
            HttpClient client = new HttpClient();
            List<Car> cars = new List<Car>();
            int page = 1;
            while (true)
            {
                try
                {
                    string urlPage = $"{url}{page++}";
                    Console.WriteLine($"Fetching page: {urlPage}");
                    string htmlContent;
                    try
                    {
                        htmlContent = await client.GetStringAsync(urlPage);
                    }
                    catch (Exception)
                    {
                        break;
                    }
                    

                    if (string.IsNullOrEmpty(htmlContent) || !htmlContent.Contains("ticket-item"))
                    {
                        break;
                    }
                    HtmlDocument document = new HtmlDocument();
                    document.LoadHtml(htmlContent);

                    var section = document.DocumentNode.SelectNodes("//section[@class='ticket-item ']");
                    foreach (var node in section)
                    {
                        Car car = new Car();
                        car.FileName = node.SelectSingleNode(".//div[@class='content-bar']//div[@class='ticket-photo']//a//picture//source[@srcset]")?.GetAttributeValue("srcset", string.Empty);
                        car.Model = node.SelectSingleNode(".//div[@class='content-bar']//div[@class='content']//div[@class='head-ticket']//div[@class='item ticket-title']//a//span")?.InnerText.Trim();
                        car.Price = decimal.TryParse(node.SelectSingleNode(".//div[@class='content-bar']//div[@class='content']//div[@class='price-ticket']//span//span[@data-currency='USD']")?.InnerText.Trim(), out decimal price) ? price : (decimal?)null;
                        car.VIN = node.SelectSingleNode(".//div[@class='content-bar']//div[@class='content']//div[@class='definition-data']//div[@class='base_information']//span[@class='label-vin']//span[1]")?.InnerText.Trim();

                        cars.Add(car);

                        string fileName = car.FileName?.Split('/').Last();
                        string path = Path.Combine("images", $"{fileName}");

                        if (!Directory.Exists("images"))
                        {
                            Directory.CreateDirectory("images");
                        }
                        if (!string.IsNullOrEmpty(car.FileName))
                        {
                            await DownloadFile(car.FileName, path);
                            car.FileName = fileName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Хтось не схотів до нас у колекцію");
                }
            }



            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }

        }
    }
}

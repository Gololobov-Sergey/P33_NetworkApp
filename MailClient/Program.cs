using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Net.Imap;

namespace MailClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var message = new MimeMessage();
            //message.From.Add(new MailboxAddress("Від кого", "gololobov.serhiy@gmail.com"));
            //message.To.Add(new MailboxAddress("Кому", "gololobov.serhiy@gmail.com"));
            //message.Subject = "Тестовий лист";

            //message.Body = new TextPart("plain")
            //{
            //    Text = "Привіт! Це тестове повідомлення"
            //};

            //using(var client = new SmtpClient())
            //{
            //    try
            //    {
            //        client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);

            //        client.Authenticate("gololobov.serhiy@gmail.com", "lovk iojp teup gdsz");

            //        client.Send(message);

            //        Console.WriteLine("Повідомлення відправлене");

            //        client.Disconnect(true);
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }

            //}


            //inbox

            string email = "gololobov.serhiy@gmail.com";
            string password = "lovk iojp teup gdsz";
            string imapServer = "imap.gmail.com";
            int port = 993;

            using(var client = new ImapClient())
            {
                try
                {
                    client.Connect(imapServer, port, MailKit.Security.SecureSocketOptions.SslOnConnect);
                    client.Authenticate(email, password);
                    var inbox = client.Inbox;
                    inbox.Open(MailKit.FolderAccess.ReadOnly);
                    Console.WriteLine($"Листів у вхідних : {inbox.Count}");

                    for(int i = inbox.Count - 1; i >= Math.Max(0, inbox.Count - 5); i--)
                    {
                        var message = inbox.GetMessage(i);

                        Console.WriteLine($"--- Лист №{i + 1}");
                        Console.WriteLine($"Від   : {message.From}");
                        Console.WriteLine($"Тема  : {message.Subject}");
                        Console.WriteLine($"Дата  : {message.Date}");
                        Console.WriteLine($"Текст : {message.TextBody?.Substring(0, Math.Min(100, message.TextBody.Length))}");
                        Console.WriteLine();
                    }

                    client.Disconnect(true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}

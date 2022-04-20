using System;
using Telegram.Bot;

namespace TelegramBotTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var botClient = new TelegramBotClient("5213173201:AAEciKmJAcDRgxX6rrTuBGHcoFDhnMpYCrI");

            var me =  botClient.GetMeAsync().Result;
            Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");

            Console.Read();
        }
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

class Program
{
    static void Main(string[] args)
    {
        var client = new TelegramBotClient("6515197201:AAF7mZ7lZvASeDARcJNcreQBfzLJZjf4IVM");
        client.StartReceiving(Update, Error); //создали 2 метода - навести - создать метод
        Console.ReadLine();
    }

    async private static Task Update(ITelegramBotClient botСlient, Update update, CancellationToken token)
    {
        //Update - получает все события
        var message = update.Message;
        if (message?.Text != null) //человек не отправляет нам картинки, музыку и т.д. 
        {
            Console.WriteLine($"{message.Chat.FirstName} | {message.Text}");
            if (message.Text.ToLower() == "привет") 
            {
                await botСlient.SendTextMessageAsync(message.Chat.Id, "Здравствуйте!");
                return;
            }
            else if (message.Text.ToLower().Contains("как дела?"))
            {
                await botСlient.SendTextMessageAsync(message.Chat.Id, "Отлично!");
                return;
            }
            else if (message.Text.ToLower().Contains("сколько времени?"))
            {
                await botСlient.SendTextMessageAsync(message.Chat.Id, "Не могу ответить точно...");
                return;
            }
        }
        if (message?.Photo != null) //человек решил кинуть фото, но а мы хотим фото в виде документа
        {
            await botСlient.SendTextMessageAsync(message.Chat.Id, "Хорошее фото, но лучше отправь документом. хы-хы");
            return;
        }
    }

    private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
    {
        throw new NotImplementedException();
    }
}
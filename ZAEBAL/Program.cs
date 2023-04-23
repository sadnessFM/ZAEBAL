using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using ZAEBAL;

var db = new Database();

var bot = new TelegramBotClient("5942398239:AAG_nun6eCqGIRW5xRrZPulCAekob58rG20");

using CancellationTokenSource cts = new();

// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
};

bot.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);

User me = await bot.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

// Send cancellation request to stop bot
cts.Cancel();

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    // Only process Message updates: https://core.telegram.org/bots/api#message
    if (update.Message is not { Text: { } messageText } message)
        return;
    // Only process text messages

    var chatId = message.Chat.Id;

    Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

    if (message.Text.Contains("/start"))
    {
        await bot.SendTextMessageAsync(message.Chat, text: "воркает");
    }

    if (message.Text.Contains("/quiz"))
    {
        var bebra = message.Text.Replace("/quiz", "");
        await QuizCreate(Convert.ToInt32(bebra), message);
    }

    if (message.Text.Contains("/answer"))
    {
        var bebra = message.Text.Replace("/answer", "");
        await WriteAnswer(bebra, message);
    }
}

Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    var errorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };

    Console.WriteLine(errorMessage);
    return Task.CompletedTask;
}

async Task QuizCreate(int id, Message message)
{
    await bot.SendTextMessageAsync(chatId: message.Chat, text: "Вопросы:");
    foreach (var msg in from x in db.Questions where x.Id == id select $"{x.Id}. {x.Text}")
    {
        await bot.SendTextMessageAsync(chatId: message.Chat, text: msg);
    }

    await bot.SendTextMessageAsync(chatId: message.Chat, text: "Ответы:");
    foreach (var msg in from x in db.Answers where x.QuestionId == id select $"{x.Id}. {x.Text}")
    {
        await bot.SendTextMessageAsync(chatId: message.Chat, text: msg);
    }

    if (id + 1 <= db.Questions.Count)
    {
        Thread.Sleep(2000);
        await QuizCreate(id + 1, message);
    }
    
}

async Task WriteAnswer(string bebra, Message message)
{
    await bot.SendTextMessageAsync(chatId: message.Chat, text: bebra);
}
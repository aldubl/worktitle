using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;
using WorkTitle.Telegramm.API.Interfaces;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using WorkTitle.Telegramm.DomainModels;

namespace WorkTitle.Telegramm.Services
{
    internal class UpdateHandler : IUpdateHandler
    {
        private readonly ITelegramBotClient _botClient;
        private readonly ILogger<UpdateHandler> _logger;
        private readonly IWorkTitleApi _api;

        public UpdateHandler(ITelegramBotClient botClient, IWorkTitleApi api, ILogger<UpdateHandler> logger)
        {
            _botClient = botClient;
            _logger = logger;
            _api = api;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient _, Update update, CancellationToken cancellationToken)
        {
            var handler = update switch
            {
                // UpdateType.Unknown:
                // UpdateType.ChannelPost:
                // UpdateType.EditedChannelPost:
                // UpdateType.ShippingQuery:
                // UpdateType.PreCheckoutQuery:
                // UpdateType.Poll:
                { Message: { } message } => BotOnMessageReceived(message, cancellationToken),
                { EditedMessage: { } message } => BotOnMessageReceived(message, cancellationToken),
                //{ CallbackQuery: { } callbackQuery } => BotOnCallbackQueryReceived(callbackQuery, cancellationToken),
                //{ InlineQuery: { } inlineQuery } => BotOnInlineQueryReceived(inlineQuery, cancellationToken),
                //{ ChosenInlineResult: { } chosenInlineResult } => BotOnChosenInlineResultReceived(chosenInlineResult, cancellationToken),
                _ => UnknownUpdateHandlerAsync(update, cancellationToken)
            };

            await handler;
        }

        private async Task BotOnMessageReceived(Message message, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Receive message type: {MessageType}", message.Type);
            if (message.Text is not { } messageText)
                return;

            Regex validateEmailRegex = new("^\\S+@\\S+\\.\\S+$");

            var action = messageText.Split(' ')[0] switch
            {
                "/start" => Usage(_botClient, message, cancellationToken, true),
                var val when validateEmailRegex.IsMatch(val) => EmailHandle(_botClient, message, cancellationToken),
                _ => Usage(_botClient, message, cancellationToken)
            };
            Message sentMessage = await action;
            _logger.LogInformation("The message was sent with id: {SentMessageId}", sentMessage.MessageId);

            async Task<Message> EmailHandle(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
            {
                await _api.RegisterUserAsync(new UserModel() { ChatId = message.From.Id, Email = message.Text, Name = $"{message.From.FirstName} {message.From.LastName}" });

                string usage = "Вы успешно зарегистрировались!";

                return await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: usage,
                    replyMarkup: new ReplyKeyboardRemove(),
                    cancellationToken: cancellationToken);
            }

            async Task<Message> Usage(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken, bool start = false)
            {
                var user = await _api.GetUserByChatIdAsync(message.From!.Id);

                string usage = "";
                if (start)
                {
                    usage = "Бот принимает текстовые сообщения для добавления в лист желания по умолчанию либо ссылку на товар.";
                }

                if (user.Id == Guid.Empty)
                {
                    usage += "\nУкажите свой Email";

                    return await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: usage,
                    replyMarkup: new ReplyKeyboardRemove(),
                    cancellationToken: cancellationToken);
                }
                else if (!start)
                {
                    usage = "Добавлен в лист!";
                    await _api.AddSimpleProductAsync(new ProductSimpleModel() { Name = message.Text, ListId = user.DefaultListId });
                }

                return await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: usage,
                    replyMarkup: new ReplyKeyboardRemove(),
                    cancellationToken: cancellationToken);
            }
        }
        public async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            _logger.LogInformation("HandleError: {ErrorMessage}", ErrorMessage);

            // Cooldown in case of network connection error
            if (exception is RequestException)
                await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
        }
        private Task UnknownUpdateHandlerAsync(Update update, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Unknown update type: {UpdateType}", update.Type);
            return Task.CompletedTask;
        }

    }
}

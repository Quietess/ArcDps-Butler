using System.Net;
using System.Security.Cryptography;
using System.Text;
using Butler.Helper;
using Butler.Logic.Interfaces;
using Butler.Messages;
using Butler.Models;
using Butler.Properties;
using ReactiveUI;
using RestSharp;
using System;
using DSharpPlus;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace Butler.Logic
{
    public static class DiscClient 
    {
        public static DiscordClient client;
        public static DiscordChannel channel;

        public static async Task Connect()
        {
            client = new DiscordClient(new DiscordConfiguration()
            {
                AutoReconnect = true,
                LogLevel = LogLevel.Error,
                Token = Settings.Default.DiscordToken,
                TokenType = TokenType.Bot,
            });

            await client.ConnectAsync();

            channel = client.GetChannelAsync(Settings.Default.DiscordChannelID).GetAwaiter().GetResult();

            await Task.Delay(-1);
        }
    }
}

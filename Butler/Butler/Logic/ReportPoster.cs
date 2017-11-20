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
using System.Collections.ObjectModel;

namespace Butler.Logic
{
    public class ReportPoster : IEncounterUploader
    {
	    private readonly IMessageBus _messageBus;

        static DiscordEmbedBuilder embed;

        public ReportPoster(IMessageBus messageBus)
        {
            _messageBus = messageBus;

            if (embed == null)
            {
                embed = new DiscordEmbedBuilder
                {
                    Color = new DiscordColor("#FF0000"),
                    Title = Settings.Default.DiscordTitle,
                    Timestamp = DateTime.UtcNow
                };

                embed.WithFooter(DiscClient.client.CurrentUser.Username, DiscClient.client.CurrentUser.AvatarUrl);
            }
        }

        public void RefreshEmbed()
        {
            embed.Timestamp = DateTime.UtcNow;
            embed.ClearFields();
        }

        public void AddReport(IEncounterLog log)
        {
            embed.AddField(log.Name, log.ReportUrl, false);
        }

	    public void Upload(IEncounterLog log)
	    {
            DiscClient.client.SendMessageAsync(DiscClient.channel, null, false, embed);
        }
    }
}

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

                    Timestamp = DateTime.UtcNow
                };

                embed.WithFooter("ArcDPS Butler", DiscClient.client.CurrentUser.AvatarUrl);
            }
        }

        

        public void RefreshEmbed()
        {
            embed.Timestamp = DateTime.UtcNow;
            embed.ClearFields();
        }



        public void AddReport(IEncounterLog log)
        {
            if (log.EncounterResult != "Fail")
            {
                string EncounterResult = " - Successfully Killed";
                string LogName = log.Name + EncounterResult;
                embed.Title = LogName;
                embed.Url = log.ReportUrl;
                embed.Color = new DiscordColor("#00ff00");
            }
            else
            {
                string EncounterResult = " - Unsuccessful";
                string LogName = log.Name + EncounterResult;
                embed.Title = LogName;
                embed.Url = log.ReportUrl;
                embed.Color = new DiscordColor("#ff0000");
            }
            string AllDps = log.AllDps.ToString();
            string BossDps = log.BossDps.ToString();
            string EncounterTime = log.EncounterTime.ToString();
            embed.AddField("All DPS:", AllDps, true);
            embed.AddField("Boss DPS:", BossDps, true);
            embed.AddField("Duration:", EncounterTime, true);

        }

        public void Upload(IEncounterLog log)
	    {
            DiscClient.client.SendMessageAsync(DiscClient.channel, null, false, embed);
        }
    }
}

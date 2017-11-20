using System.Net;
using System.Security.Cryptography;
using System.Text;
using RaidTool.Helper;
using RaidTool.Logic.Interfaces;
using RaidTool.Messages;
using RaidTool.Models;
using RaidTool.Properties;
using ReactiveUI;
using RestSharp;
using System;
using System.Collections.ObjectModel;

namespace RaidTool.Logic
{
    public class ReportUploader : IEncounterUploader
    {
	    private readonly IMessageBus _messageBus;

	    public ReportUploader(IMessageBus messageBus)
	    {
		    _messageBus = messageBus;
	    }

	    public void Upload(IEncounterLog log)
	    {
		    var restClient = new RestClient("https://www.dps.report");
		    var restRequest = new RestRequest("/uploadContent?json=1");
			restRequest.Method = Method.POST;
		    restRequest.AddFile("file", log.EvtcPath);
		    
		    var restResponse = restClient.Execute(restRequest);

		    if (restResponse.ResponseStatus == ResponseStatus.Completed && restResponse.StatusCode == HttpStatusCode.OK)
		    {
			    log.ReportUploadComplete = true;
                dynamic json = SimpleJson.DeserializeObject(restResponse.Content);
                log.ReportUrl = json["permalink"].ToString();
			    _messageBus.SendMessage(new UploadedEncounterMessage(log));
			}
		    else
		    {
			    log.ReportUploadComplete = false;
				_messageBus.SendMessage(new LogMessage($"{restResponse.StatusCode} - {restResponse.Content}"));
			}

			
	    }

        public void Upload(ObservableCollection<IEncounterLog> logs)
        {
        }
    }
}

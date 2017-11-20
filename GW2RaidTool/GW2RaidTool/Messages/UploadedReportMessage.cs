using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaidTool.Models;

namespace RaidTool.Messages
{
    public class UploadedReportMessage
    {
	    public UploadedReportMessage(IEncounterLog encounterLog)
	    {
		    EncounterLog = encounterLog;
	    }

	    public IEncounterLog EncounterLog { get; set; }
	}
}

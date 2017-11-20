using Butler.Models;

namespace Butler.Messages
{
	public class UpdatedEncounterMessage
	{
		public UpdatedEncounterMessage(IEncounterLog encounterLog)
		{
			EncounterLog = encounterLog;
		}

		public IEncounterLog EncounterLog { get; set; }
	}
}
using Butler.Models;

namespace Butler.Messages
{
	public class NewEncounterMessage
	{
		public IEncounterLog EncounterLog { get; set; }

		public NewEncounterMessage(IEncounterLog encounterLog)
		{
			EncounterLog = encounterLog;
		}
	}
}
using Butler.Models;

namespace Butler.Logic.Interfaces
{
	public interface IHtmlFileWatcher
	{
		void CreateRaidHerosFile(IEncounterLog encounterLog);
	}
}
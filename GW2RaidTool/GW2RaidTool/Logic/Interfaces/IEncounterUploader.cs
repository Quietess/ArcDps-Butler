using RaidTool.Models;
using System.Collections.ObjectModel;

namespace RaidTool.Logic.Interfaces
{
	public interface IEncounterUploader
	{
		void Upload(IEncounterLog log);
	}
}
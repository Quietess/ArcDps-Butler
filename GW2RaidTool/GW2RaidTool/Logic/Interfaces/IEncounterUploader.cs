using Butler.Models;
using System.Collections.ObjectModel;

namespace Butler.Logic.Interfaces
{
	public interface IEncounterUploader
	{
		void Upload(IEncounterLog log);
	}
}
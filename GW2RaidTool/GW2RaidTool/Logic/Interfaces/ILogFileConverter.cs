using EVTC_Log_Parser.Model;
using Butler.Models;

namespace Butler.Logic.Interfaces
{
	public interface ILogFileConverter
	{
		void ConvertLog(IEncounterLog herosLog, SharedValues sharedValues);
	}
}
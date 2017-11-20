using System.Threading;
using Butler.Helper;
using Butler.Logic.Interfaces;

namespace Butler.Logic.LogDetectionStrategies
{
	public class CompressedStrategy : ILogDetectionStrategy
	{
		public string Name => "compressed";
		public string Filter => "*.evtc*.zip";
		public int WaitTime => 500;
		public bool CheckFile(string path)
		{
			return FileInUseChecker.CheckFile(path, WaitTime);
		}
	}
}
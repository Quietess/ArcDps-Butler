using System.Collections.Generic;
using System.IO;

namespace Butler.Logic.Interfaces
{
	public interface IFileWatcher
	{
		FileSystemWatcher LogfileWatcher { get; }
		void SetLogDetectionStrategy(ILogDetectionStrategy logDetectionStrategy);
		void Run();
		void ParseLogFile(FileInfo fileInfo);
		void ParseLogFiles(IEnumerable<FileInfo> fileInfos);
	}
}
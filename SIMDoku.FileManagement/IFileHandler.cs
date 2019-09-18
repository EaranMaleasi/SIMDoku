using SIMDoku.FileManagement.Bootstrap;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIMDoku.FileManagement
{
	public interface IFileHandler
	{
		FileType Type { get; }
		string Path { get; set; }
		bool IsEncrypted { get; set; }
		byte[] Key { get; set; }
		byte[] IV { get; set; }

		Task<List<T>> ReadFileData<T>();
		Task SaveFileData<T>(List<T> data);

		void SetKey(string key, bool isIV);
		void SetIV(string iv);
	}
}

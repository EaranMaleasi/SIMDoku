using SIMDoku.FileManagement.Bootstrap;

using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SIMDoku.FileManagement
{
	internal abstract class FileHandlerBase : IFileHandler
	{
		public bool IsEncrypted { get; set; }
		public byte[] Key { get; set; }
		public byte[] IV { get; set; }
		public string Path { get; set; }

		public abstract FileType Type { get; }

		public abstract Task<List<T>> ReadFileData<T>();

		public abstract Task SaveFileData<T>(List<T> data);

		public void SetIV(string iv)
		{
			IV = Encoding.UTF8.GetBytes(iv);
		}

		public void SetKey(string key, bool isIV)
		{
			Key = Encoding.UTF8.GetBytes(key);
			if (isIV)
			{
				IV = Encoding.UTF8.GetBytes(key);
			}

		}
	}
}

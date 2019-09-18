using Newtonsoft.Json;

using SIMDoku.FileManagement.Bootstrap;

using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SIMDoku.FileManagement
{
	internal class JsonHandler : FileHandlerBase
	{
		public override FileType Type => FileType.JSON;

		public override async Task<List<T>> ReadFileData<T>()
		{
			List<T> lstRet = null;
			if (IsEncrypted)
			{
				using (FileStream fs = new FileStream(Path, FileMode.Open))
				using (AesManaged aes = new AesManaged())
				using (CryptoStream cs = new CryptoStream(fs, aes.CreateDecryptor(Key, IV), CryptoStreamMode.Read))
				using (StreamReader sr = new StreamReader(cs))
				{
					string json = await sr.ReadToEndAsync();
					lstRet = JsonConvert.DeserializeObject<List<T>>(json);
				}

			}
			else
			{
				using (StreamReader sr = new StreamReader(Path))
				{
					string json = await sr.ReadToEndAsync();
					lstRet = await Task.Run(() => JsonConvert.DeserializeObject<List<T>>(json));
				}
			}
			return lstRet;
		}

		public override async Task SaveFileData<T>(List<T> data)
		{
			if (IsEncrypted)
			{
				using (FileStream fs = new FileStream(Path, FileMode.Create))
				using (AesManaged aes = new AesManaged())
				using (CryptoStream cs = new CryptoStream(fs, aes.CreateEncryptor(Key, IV), CryptoStreamMode.Write))
				using (StreamWriter sw = new StreamWriter(cs))
				{
					string json = await Task.Run(() => JsonConvert.SerializeObject(data));
					await sw.WriteAsync(json);
				}
			}
			else
			{
				using (StreamWriter sw = new StreamWriter(Path))
				{
					string json = await Task.Run(() => JsonConvert.SerializeObject(data));
					await sw.WriteAsync(json);
				}
			}
		}
	}
}

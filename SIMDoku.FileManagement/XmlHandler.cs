using SIMDoku.FileManagement.Bootstrap;

using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SIMDoku.FileManagement
{
	internal class XmlHandler : FileHandlerBase
	{
		public override FileType Type => FileType.XML;

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
					XmlSerializer xs = new XmlSerializer(typeof(List<T>));
					lstRet = (List<T>)await Task.Run(() => xs.Deserialize(sr));
				}
			}
			else
			{
				using (StreamReader sr = new StreamReader(Path))
				{
					XmlSerializer xs = new XmlSerializer(typeof(List<T>));
					lstRet = (List<T>)await Task.Run(() => xs.Deserialize(sr));
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
					XmlSerializer xs = new XmlSerializer(typeof(List<T>));
					await Task.Run(() => xs.Serialize(sw, data));
				}
			}
			else
			{
				using (StreamWriter sw = new StreamWriter(Path))
				{
					XmlSerializer xs = new XmlSerializer(typeof(List<T>));
					await Task.Run(() => xs.Serialize(sw, data));
				}
			}
		}
	}
}

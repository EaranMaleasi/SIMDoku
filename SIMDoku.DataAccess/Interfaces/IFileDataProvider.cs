using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIMDoku.DataAccess
{
	public interface IFileDataProvider
	{
		Task<List<T>> LoadData<T>();
		Task SaveData<T>(List<T> data);
	}
}

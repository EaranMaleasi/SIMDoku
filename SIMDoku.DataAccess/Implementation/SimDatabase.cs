using SIMDoku.DataObjects;
using SIMDoku.DataObjects.Interfaces;

using System;
using System.Collections.Generic;

namespace SIMDoku.DataAccess.Implementation
{
	public class SimDatabase : ISimDatabase
	{
		private Dictionary<Guid, Document> _Documents;
		private Dictionary<Guid, Tag> _Tags;

		public T CreateRow<T>() where T : ISimObject, new()
		{
			throw new NotImplementedException();
		}

		public void DeleteRow<T>(T row) where T : ISimObject, new()
		{
			throw new NotImplementedException();
		}

		public T GetRow<T>(Guid id) where T : ISimObject
		{
			throw new NotImplementedException();
		}

		public List<T> GetTable<T>() where T : ISimObject
		{
			throw new NotImplementedException();
		}
	}
}

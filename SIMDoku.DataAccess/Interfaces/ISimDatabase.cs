using SIMDoku.DataObjects.Interfaces;

using System;
using System.Collections.Generic;

namespace SIMDoku.DataAccess
{
	public interface ISimDatabase
	{
		/// <summary>
		/// Returns a new Row of type <typeparamref name="T"/> initializes its <see cref="ISimObject.ID"/> and returns it for further modification.
		/// </summary>
		/// <typeparam name="T">A Type that implements <see cref="ISimObject"/></typeparam>
		/// <returns>Returns a new object of type <typeparamref name="T"/> with its <see cref="ISimObject.ID"/> already set.</returns>
		T CreateRow<T>() where T : ISimObject, new();
		/// <summary>
		/// Removes <paramref name="row"/> from the table
		/// </summary>
		/// <typeparam name="T">A Type that implements <see cref="ISimObject"/></typeparam>
		/// <param name="row">The row to be deleted from the Table</param>
		void DeleteRow<T>(T row) where T : ISimObject, new();

		/// <summary>
		/// Returns the object which <see cref="ISimObject.ID"/> matches <paramref name="id"/>. If no match is found, returns null.
		/// </summary>
		/// <typeparam name="T">A Type that implements <see cref="ISimObject"/></typeparam>
		/// <param name="id">The <see cref="ISimObject.ID"/> of the object to return</param>
		/// <returns>Returns the object matching <paramref name="id"/> or null if no match is found</returns>
		T GetRow<T>(Guid id) where T : ISimObject;
		/// <summary>
		/// Returns a copy of the internal table. The List is in no particular order.
		/// </summary>
		/// <typeparam name="T">The type of the table to return</typeparam>
		/// <returns></returns>
		List<T> GetTable<T>() where T : ISimObject;
	}
}

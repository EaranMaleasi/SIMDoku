using System;

namespace SIMDoku.DataObjects.Interfaces
{
	/// <summary>
	/// The basic definition of the objects being handled by this database
	/// </summary>
	public interface ISimObject : IComparable, IComparable<ISimObject>, IEquatable<ISimObject>
	{
		Guid ID { get; set; }
	}
}

using SIMDoku.DataObjects.Interfaces;

using System;
using System.Collections.Generic;

namespace SIMDoku.DataObjects
{
	public interface IDocument : ISimObject, IComparable, IComparable<IDocument>, IEquatable<IDocument>
	{
		DateTime CreationDate { get; set; }
		string Description { get; set; }
		DateTime DocumentDate { get; set; }
		string Name { get; set; }
		DateTime ReceivedDate { get; set; }
		HashSet<Guid> Tags { get; set; }
	}
}
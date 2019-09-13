using SIMDoku.DataObjects.Interfaces;

using System;
using System.Collections.Generic;

namespace SIMDoku.DataObjects
{
	public class Document : BaseDataObject, IDocument
	{
		/// <summary>
		/// The name of the Document. Should be the subject of the letter.
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// A short summary of the contents of the document. Try to use as many keywords as possible to increase full-text search accuracy.
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		/// The Date that is printed onto the document.
		/// </summary>
		public DateTime DocumentDate { get; set; }
		/// <summary>
		/// The date on which the document was saved to the system.
		/// </summary>
		public DateTime CreationDate { get; set; }
		/// <summary>
		/// The date on which the document arrived.
		/// </summary>
		public DateTime ReceivedDate { get; set; }
		/// <summary>
		/// The IDs of the tags that are associated with this document. 
		/// </summary>
		public HashSet<Guid> Tags { get; set; } = new HashSet<Guid>();

		/// <summary>
		/// Compare another object with this instance. Only <see cref="ISimObject.ID"/> is used in this comparison.<para/>
		/// </summary>
		/// <param name="other">The other object to compare this instance to</param>
		/// <returns>Returns a negative integer if this instance is less than <paramref name="other"/>.<para/>
		/// Returns zero if this instance is equal to <paramref name="other"/>.<para/>
		/// Returns a positive integer if this instance is greater than <paramref name="obj"/> or <paramref name="obj"/> is null or <paramref name="obj"/> does not implement <see cref="ISimObject"/></returns>
		public override int CompareTo(object obj)
		{
			return base.CompareTo(obj);
		}

		public int CompareTo(IDocument other)
		{
			return base.CompareTo(other);
		}

		public bool Equals(IDocument other)
		{
			return base.Equals(other);
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override string ToString()
		{
			return Name;
		}
	}
}

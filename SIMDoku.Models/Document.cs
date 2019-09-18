using System;
using System.Collections.Generic;

namespace SIMDoku.Models
{
	public class Document : IEquatable<Document>, IComparable<Document>, IComparable
	{
		/// <summary>
		/// The unique identifier of this instance
		/// </summary>
		public Guid ID { get; set; }

		/// <summary>
		/// The name of this <see cref="Document"/> instance. Should be the subject of the letter.
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// A short summary of the contents of this <see cref="Document"/> instance. Try to use as many keywords as possible to increase full-text search accuracy.
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		/// The Date that is printed onto the physical document.
		/// </summary>
		public DateTime DocumentDate { get; set; }
		/// <summary>
		/// The date on which the physical document was saved to the system.
		/// </summary>
		public DateTime CreationDate { get; set; }
		/// <summary>
		/// The date on which the physical document arrived.
		/// </summary>
		public DateTime ReceivedDate { get; set; }
		/// <summary>
		/// The <see cref="Tag.ID"/>s of the <see cref="Tag"/>s that are associated with this <see cref="Document"/>. 
		/// </summary>
		public HashSet<Guid> Tags { get; set; } = new HashSet<Guid>();
		/// <summary>
		/// The <see cref="Folder"/> of the <see cref="Folder"/> that this <see cref="Document"/> resides in.
		/// </summary>
		public Guid FolderID { get; set; }

		#region Overrides and Interface implementations
		/// <summary>
		/// Compare another <see cref="Document"/> object with this instance. Only <see cref="ID"/> is used in this comparison.<para/>
		/// </summary>
		/// <param name="other">The other <see cref="Document"/> to compare this instance to</param>
		/// <returns>Returns a negative integer if this instance is less than <paramref name="other"/>.<para/>
		/// Returns zero if this instance is equal to <paramref name="other"/>.<para/>
		/// Returns a positive integer if this instance is greater than <paramref name="other"/> or <paramref name="other"/> is null.</returns>
		public int CompareTo(Document other)
		{
			if (other != null)
			{
				return ID.CompareTo(other.ID);
			}
			return 1;
		}
		/// <summary>
		/// Compare another object with this instance. Only <see cref="ID"/> is used in this comparison.<para/>
		/// </summary>
		/// <param name="obj">The other object to compare this instance to</param>
		/// <returns>Returns a negative integer if this instance is less than <paramref name="obj"/>.<para/>
		/// Returns zero if this instance is equal to <paramref name="obj"/>.<para/>
		/// Returns a positive integer if this instance is greater than <paramref name="obj"/> or <paramref name="obj"/> is null or <paramref name="obj"/> is not a <see cref="Document"/> object</returns>
		public int CompareTo(object obj)
		{
			if (obj is Document other)
			{
				return CompareTo(other);
			}
			return 1;
		}
		/// <summary>
		/// Checks if this instance is equal to <paramref name="other"/>. Only <see cref="ID"/> is used for equality check.<para/>
		/// </summary>
		/// <param name="other">The other <see cref="Document"/> object to check for equality to this instance</param>
		/// <returns>Returns false if <paramref name="other"/> is null.<para/>
		/// Returns true if <see cref="ID"/> of this instance is the same as <paramref name="other"/></returns>
		public bool Equals(Document other)
		{
			if (other != null)
			{
				return ID == other.ID;
			}
			return false;
		}
		/// <summary>
		/// Checks if this instance is equal to <paramref name="obj"/>. Only <see cref="ID"/> is used for quality check.<para/>
		/// </summary>
		/// <param name="obj">The other object to check for equality to this instance</param>
		/// <returns>Returns false if <paramref name="obj"/> is null or is not a <see cref="Document"/>.<para/>
		/// Returns true if <see cref="ID"/> of this instance is the same as <paramref name="obj"/></returns>
		public override bool Equals(object obj)
		{
			if (obj is Document other)
			{
				return Equals(other);
			}
			return false;
		}
		/// <summary>
		/// Provides the hash code for this instance. Only <see cref="ID"/> is used.
		/// </summary>
		/// <returns>The hash code for this instance</returns>
		public override int GetHashCode()
		{
			return ID.GetHashCode();
		}
		/// <summary>
		/// Returns a string representation for this instance
		/// </summary>
		/// <returns>Returns a string representation for this instance</returns>
		public override string ToString()
		{
			return $"Docuiment{{{Name}|{ID}}}";
		}
		#endregion
	}
}

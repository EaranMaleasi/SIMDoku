using System;

namespace SIMDoku.Models
{
	public class Tag : IEquatable<Tag>, IComparable<Tag>, IComparable
	{
		/// <summary>
		/// The unique ID of this <see cref="Tag"/> object.
		/// </summary>
		public Guid ID { get; set; }
		/// <summary>
		/// The Name of this <see cref="Tag"/> object.
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// A short summary about what kinds of <see cref="Document"/>s are to be tagged with this.
		/// </summary>
		public string Description { get; set; }

		#region Overrides and Interface implementations
		/// <summary>
		/// Compare another <see cref="Tag"/> object with this instance. Only <see cref="ID"/> is used in this comparison.<para/>
		/// </summary>
		/// <param name="other">The other <see cref="Tag"/> to compare this instance to</param>
		/// <returns>Returns a negative integer if this instance is less than <paramref name="other"/>.<para/>
		/// Returns zero if this instance is equal to <paramref name="other"/>.<para/>
		/// Returns a positive integer if this instance is greater than <paramref name="other"/> or <paramref name="other"/> is null.</returns>
		public int CompareTo(Tag other)
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
		/// Returns a positive integer if this instance is greater than <paramref name="obj"/> or <paramref name="obj"/> is null or <paramref name="obj"/> is not a <see cref="Tag"/> object</returns>
		public int CompareTo(object obj)
		{
			if (obj is Tag other)
			{
				return CompareTo(other);
			}
			return 1;
		}
		/// <summary>
		/// Checks if this instance is equal to <paramref name="other"/>. Only <see cref="ID"/> is used for equality check.<para/>
		/// </summary>
		/// <param name="other">The other <see cref="Tag"/> object to check for equality to this instance</param>
		/// <returns>Returns false if <paramref name="other"/> is null.<para/>
		/// Returns true if <see cref="ID"/> of this instance is the same as <paramref name="other"/></returns>
		public bool Equals(Tag other)
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
		/// <param name="obj">The other <see cref="Tag"/> object to check for equality to this instance</param>
		/// <returns>Returns false if <paramref name="obj"/> is null or is not a <see cref="Tag"/>.<para/>
		/// Returns true if <see cref="ID"/> of this instance is the same as <paramref name="obj"/></returns>
		public override bool Equals(object obj)
		{
			if (obj is Tag other)
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
			return $"Tag{{{Name}|{ID}}}";
		}
		#endregion
	}
}

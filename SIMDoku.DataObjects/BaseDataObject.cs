using SIMDoku.DataObjects.Interfaces;

using System;

namespace SIMDoku.DataObjects
{
	/// <summary>
	/// The base Implementation that all dataObjects should inherit from.
	/// </summary>
	public abstract class BaseDataObject : ISimObject
	{
		/// <summary>
		/// The unique ID of this object.
		/// </summary>
		public Guid ID { get; set; }

		/// <summary>
		/// Compare another object with this instance. Only <see cref="ISimObject.ID"/> is used in this comparison.<para/>
		/// </summary>
		/// <param name="other">The other object to compare this instance to</param>
		/// <returns>Returns a negative integer if this instance is less than <paramref name="other"/>.<para/>
		/// Returns zero if this instance is equal to <paramref name="other"/>.<para/>
		/// Returns a positive integer if this instance is greater than <paramref name="obj"/> or <paramref name="obj"/> is null or <paramref name="obj"/> does not inherit from <see cref="BaseDataObject"/></returns>
		public virtual int CompareTo(object obj)
		{
			if (obj is ISimObject other)
			{
				return CompareTo(other);
			}
			return 1;
		}

		/// <summary>
		/// Compare another <see cref="ISimObject"/> object with this instance. Only <see cref="ID"/> is used in this comparison.<para/>
		/// </summary>
		/// <param name="other">The other <see cref="BaseDataObject"/> to compare this instance to</param>
		/// <returns>Returns a negative integer if this instance is less than <paramref name="other"/>.<para/>
		/// Returns zero if this instance is equal to <paramref name="other"/>.<para/>
		/// Returns a positive integer if this instance is greater than <paramref name="other"/> or <paramref name="other"/> is null.</returns>
		public virtual int CompareTo(ISimObject other)
		{
			if (other != null)
			{
				return ((IComparable)ID).CompareTo(other.ID);
			}
			return 1;
		}

		/// <summary>
		/// Checks if this instance is equal to <paramref name="obj"/>. Only <see cref="ID"/> is used for quality check.<para/>
		/// </summary>
		/// <param name="obj">The other object to check for equality to this instance</param>
		/// <returns>Returns false if <paramref name="obj"/> is null or does not inherit <see cref="BaseDataObject"/>.<para/>
		/// Returns true if <see cref="ID"/> of this instance is the same as <paramref name="obj"/></returns>
		public override bool Equals(object obj)
		{
			if (obj is ISimObject other)
			{
				return Equals(other);
			}
			return false;
		}

		/// <summary>
		/// Checks if this instance is equal to <paramref name="other"/>. Only <see cref="ID"/> is used for quality check.<para/>
		/// </summary>
		/// <param name="obj">The other object to check for equality to this instance</param>
		/// <returns>Returns false if <paramref name="other"/> is null.<para/>
		/// Returns true if <see cref="ID"/> of this instance is the same as <paramref name="other"/></returns>
		public bool Equals(ISimObject other)
		{
			if (other != null)
			{
				return ID == other.ID;
			}
			return false;
		}

		/// <summary>
		/// Provides the hash bcode for this instance. Only <see cref="ID"/> is used.
		/// </summary>
		/// <returns>The hash code for this instance</returns>
		public override int GetHashCode()
		{
			return ID.GetHashCode();
		}
	}
}

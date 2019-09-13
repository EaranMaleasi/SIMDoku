namespace SIMDoku.DataObjects
{
	public class Tag : BaseDataObject
	{
		/// <summary>
		/// The Name of the <see cref="Tag"/>.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// A short summary about what kinds of <see cref="Document"/>s are to be tagged with this.
		/// </summary>
		public string Description { get; set; }
	}
}

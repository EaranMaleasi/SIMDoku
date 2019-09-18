using SIMDoku.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIMDoku.DataManagement
{
	/// <summary>
	/// The data provider used for getting and saving data.
	/// </summary>
	public interface IDataProvider
	{

		/// <summary>
		/// Creates a new <see cref="Document"/> object and adds it to the table.<para/>
		/// Ensures that <see cref="Document.ID"/> is unique.
		/// </summary>
		/// <returns>New <see cref="Document"/> object with ensured unique <see cref="Document.ID"/></returns>
		Task<Document> CreateDocument();
		/// <summary>
		/// Creates a new <see cref="Folder"/> objectand and adds it to the table.<para/>
		/// Ensures that <see cref="Folder.ID"/> is unique.
		/// </summary>
		/// <returns>New <see cref="Folder"/> object with ensured unique <see cref="Folder.ID"/></returns>
		Task<Folder> CreateFolder();
		/// <summary>
		/// Creates a new <see cref="Tag"/> object and adds it to the table.<para/>
		/// Ensures that <see cref="Tag.ID"/> is unique.
		/// </summary>
		/// <returns>New <see cref="Tag"/> object with ensured unique <see cref="Tag.ID"/></returns>
		Task<Tag> CreateTag();


		/// <summary>
		/// Deletes all references to <paramref name="document"/> and removes it from the table.
		/// </summary>
		/// <param name="document">The <see cref="Document"/> object to remove from the table"/></param>
		Task DeleteDocument(Document document);
		/// <summary>
		/// Deletes all references to <paramref name="folder"/> and removes it from the table.<para/>
		/// WARNING: Before deleting a folder make sure that all documents in this folder were transferred to another folder!
		/// </summary>
		/// <param name="folder">The <see cref="Folder"/> object to remove from the table</param>
		Task DeleteFolder(Folder folder);
		/// <summary>
		/// Deletesd all references to <paramref name="tag"/> and removes it from the table
		/// </summary>
		/// <param name="tag">The <see cref="Tag"/> object to remove from the table</param>
		Task DeleteTag(Tag tag);


		/// <summary>
		/// Retrieve a <see cref="Document"/> by its <see cref="Document.ID"/>. If <paramref name="id"/> couldn't be found returns null.
		/// </summary>
		/// <param name="id">The <see cref="Document.ID"/> to look for</param>
		/// <returns>The <see cref="Document"/> object from the table that matches <paramref name="id"/></returns>
		Task<Document> GetDocument(Guid id);
		/// <summary>
		/// Retrieve a <see cref="Folder"/> by its <see cref="Folder.ID"/>. If <paramref name="id"/> couldn't be found, returns null.
		/// </summary>
		/// <param name="id">The <see cref="Folder.ID"/> to look for</param>
		/// <returns>The <see cref="Folder"/> object from the table that matches <paramref name="id"/></returns>
		Task<Folder> GetFolder(Guid id);
		/// <summary>
		/// Retrieve a <see cref="Tag"/> by its <see cref="Tag.ID"/>. If <paramref name="id"/> couldn't be found, returns null.
		/// </summary>
		/// <param name="id">The <see cref="Tag.ID"/> to look for</param>
		/// <returns>The <see cref="Tag"/> object from the table that matches <paramref name="id"/></returns>
		Task<Tag> GetTag(Guid id);

		/// <summary>
		/// Returns all <see cref="Document"/> objects. The List is in no particular order.
		/// </summary>
		/// <returns>List of all <see cref="Document"/> objects in the table</returns>
		Task<List<Document>> GetAllDocuments();
		/// <summary>
		/// Returns all <see cref="Folder"/> objects. The List is in no particular order.
		/// </summary>
		/// <returns>List of all <see cref="Folder"/> objects in the table</returns>
		Task<List<Folder>> GetAllFolders();
		/// <summary>
		/// Returns all <see cref="Tag"/> objects. The List is in no particular order.
		/// </summary>
		/// <returns>List of all <see cref="Tag"/> objects in the table</returns>
		Task<List<Tag>> GetAllTags();

		/// <summary>
		/// Loads the data into memory
		/// </summary>
		/// <returns></returns>
		Task LoadData();
		/// <summary>
		/// Saves the data into a data storage
		/// </summary>
		/// <returns></returns>
		Task SaveData();
	}
}

using SIMDoku.FileManagement;
using SIMDoku.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMDoku.DataManagement
{
	internal class FileDataAccess : IDataProvider
	{
		private readonly object _DocumentLock = new object();
		private readonly object _FolderLock = new object();
		private readonly object _TagLock = new object();

		private Dictionary<Guid, Document> _Documents;
		private Dictionary<Guid, Folder> _Folders;
		private Dictionary<Guid, Tag> _Tags;

		private readonly IFileHandler _FileHandler;

		public FileDataAccess(IFileHandler fileHandler)
		{
			_FileHandler = fileHandler;
			_Documents = new Dictionary<Guid, Document>();
			_Folders = new Dictionary<Guid, Folder>();
			_Tags = new Dictionary<Guid, Tag>();
		}

		public Task<Document> CreateDocument()
		{
			return Task.Run(() =>
			{
				Document temp = new Document();
				do
				{
					temp.ID = Guid.NewGuid();
				} while (_Documents.ContainsKey(temp.ID));
				lock (_DocumentLock)
				{
					_Documents[temp.ID] = temp;
				}
				return temp;
			});
		}
		public Task<Folder> CreateFolder()
		{
			return Task.Run(() =>
			{
				Folder temp = new Folder();
				do
				{
					temp.ID = Guid.NewGuid();
				} while (_Folders.ContainsKey(temp.ID));
				lock (_FolderLock)
				{
					_Folders[temp.ID] = temp;
				}
				return temp;
			});
		}
		public Task<Tag> CreateTag()
		{
			return Task.Run(() =>
			{
				Tag temp = new Tag();
				do
				{
					temp.ID = Guid.NewGuid();
				} while (_Tags.ContainsKey(temp.ID));
				lock (_TagLock)
				{
					_Tags[temp.ID] = temp;
				}
				return temp;
			});
		}

		public Task DeleteDocument(Document document)
		{
			return Task.Run(() =>
			{
				if (document.FolderID != Guid.Empty)
				{
					_Folders[document.FolderID].Documents.Remove(document.ID);
				}
				lock (_DocumentLock)
				{
					_Documents.Remove(document.ID);
				}
			});
		}
		public Task DeleteFolder(Folder folder)
		{
			return Task.Run(() =>
			{
				lock (_DocumentLock)
				{
					foreach (var document in _Documents.Values)
					{
						document.FolderID = document.FolderID == folder.ID ? Guid.Empty : document.FolderID;
					}
				}
				lock (_FolderLock)
				{
					_Folders.Remove(folder.ID);
				}
			});
		}
		public Task DeleteTag(Tag tag)
		{
			return Task.Run(() =>
			{
				lock (_DocumentLock)
				{
					foreach (var document in _Documents.Values)
					{
						document.Tags.Remove(tag.ID);
						_Folders[document.FolderID].Tags.Remove(tag.ID);
					}
				}
				lock (_TagLock)
				{
					_Tags.Remove(tag.ID);
				}
			});
		}


		public Task<List<Document>> GetAllDocuments()
		{
			return Task.Run(() => _Documents.Values.ToList());
		}
		public Task<List<Folder>> GetAllFolders()
		{
			return Task.Run(() => _Folders.Values.ToList());
		}
		public Task<List<Tag>> GetAllTags()
		{
			return Task.Run(() => _Tags.Values.ToList());
		}

		public Task<Document> GetDocument(Guid id)
		{
			return Task.Run(() =>
			{
				if (_Documents.TryGetValue(id, out Document doc))
				{
					return doc;
				}
				else
				{
					return null;
				}
			});
		}
		public Task<Folder> GetFolder(Guid id)
		{
			return Task.Run(() =>
			{
				if (_Folders.TryGetValue(id, out Folder fol))
				{
					return fol;
				}
				else
				{
					return null;
				}
			});
		}
		public Task<Tag> GetTag(Guid id)
		{
			return Task.Run(() =>
			{
				if (_Tags.TryGetValue(id, out Tag tag))
				{
					return tag;
				}
				else
				{
					return null;
				}
			});
		}

		public async Task LoadData()
		{
			List<Document> lstDocs = await _FileHandler.ReadFileData<Document>();
			_Documents = await Task.Run(() => lstDocs.OrderBy(X => X.ID).ToDictionary(x => x.ID));

			List<Folder> lstFolders = await _FileHandler.ReadFileData<Folder>();
			_Folders = await Task.Run(() => lstFolders.OrderBy(X => X.ID).ToDictionary(x => x.ID));

			List<Tag> lstTags = await _FileHandler.ReadFileData<Tag>();
			_Tags = lstTags.ToDictionary(x => x.ID);
		}
		public Task SaveData()
		{
			throw new NotImplementedException();
		}
	}
}
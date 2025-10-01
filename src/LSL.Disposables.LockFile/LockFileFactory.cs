using System.IO;
using LSL.Disposables.LockFile.Infrastructure;

namespace LSL.Disposables.LockFile
{
	/// <summary>
	/// LockFileFactory.
	/// </summary>
	public class LockFileFactory : ILockFileFactory
	{
		/// <inheritdoc/>
		public ILockFile Create(string lockFilePath) =>
			new LockFile(lockFilePath.AssertNotNull(nameof(lockFilePath)))
				.Create();

		internal class LockFile : ILockFile
		{
			private bool _disposedValue;

            internal LockFile(string lockFilePath) => LockFilePath = lockFilePath;

            public string LockFilePath { get; private set; }

			public bool WasCreated { get; private set; }

			internal ILockFile Create()
			{
				try
				{
					File.Open(LockFilePath, FileMode.CreateNew).Dispose();
					WasCreated = true;
				}
				catch { }

				return this;
			}

			protected virtual void Dispose(bool disposing)
			{
				if (!_disposedValue)
				{
					if (disposing && WasCreated)
					{
						File.Delete(LockFilePath);
					}

					_disposedValue = true;
				}
			}

			public void Dispose()
			{
				Dispose(disposing: true);
				System.GC.SuppressFinalize(this);
			}
		}
	}
}

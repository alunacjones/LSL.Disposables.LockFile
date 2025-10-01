using System;

namespace LSL.Disposables.LockFile
{
	/// <summary>
	/// Description of ILockFile.
	/// </summary>
	public interface ILockFile : IDisposable
	{
		/// <summary>
		/// Indicates as to whether to we could create the lock file or not
		/// </summary>
		bool WasCreated { get; }

		/// <summary>
		/// The path to the lock file
		/// </summary>
		string LockFilePath { get; }
	}
}

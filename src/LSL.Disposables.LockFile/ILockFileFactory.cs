namespace LSL.Disposables.LockFile
{
	/// <summary>
	/// Description of ILockFileFactory.
	/// </summary>
	public interface ILockFileFactory
	{		
		/// <summary>
		/// Creates a lock file
		/// </summary>
		/// <param name="lockFilePath">The full path of the lock file</param>
		/// <returns></returns>
		ILockFile Create(string lockFilePath);
	}
}

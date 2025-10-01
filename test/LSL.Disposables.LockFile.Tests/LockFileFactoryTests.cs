using System;
using System.IO;
using FluentAssertions;

namespace LSL.Disposables.LockFile.Tests
{
	[TestFixture]
	public class LockFileFactoryTests
	{
		string LockFilePath { get; set; }

		public LockFileFactoryTests()
		{
			LockFilePath = string.Format("test-{0}.lock", Guid.NewGuid().ToString("N"));
		}

		private ILockFile BuildSut()
		{
			return new LockFileFactory().Create(LockFilePath);
		}

		[Test]
		public void LockFileTests_WhenALockFileDoesNotExistItShouldCreateOne()
		{
			using (var sut = BuildSut())
			{
				File.Exists(sut.LockFilePath).Should().BeTrue();
				sut.WasCreated.Should().BeTrue();
			}

			Assert.IsFalse(File.Exists(LockFilePath));
		}

		[Test]
		public void LockFileTests_WhenALockFileAlreadyExistsItShouldNotCreateANewOne()
		{
			File.WriteAllBytes(LockFilePath, []);

			try
			{
				using (var sut = BuildSut())
				{
					sut.WasCreated.Should().BeFalse();
				}

				File.Exists(LockFilePath).Should().BeTrue();
			}
			finally
			{
				File.Delete(LockFilePath);
			}
		}

		[Test]
		public void LockFileTests_WhenALockFileDoesNotExistButSomeoneElseDeletesOursThenItShouldNotThrowAnException()
		{
			new Action(() =>
			{
				using var sut = BuildSut();
				File.Delete(LockFilePath);
			}).Should().NotThrow();
		}

		[Test]
		public void LockFileTests_GivenANullPath_ItShouldThrowTheExpectedException()
		{
			new Action(() => new LockFileFactory().Create(null)).Should().Throw<ArgumentNullException>();
		}
	}
}

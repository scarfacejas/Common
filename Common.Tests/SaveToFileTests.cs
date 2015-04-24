using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Tests
{
    [TestClass]
    public class SaveToFileTests
    {
        private SaveToFile<ToSave> _toSave = null;
        private string Path { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            Path = string.Format(@"{0}\{1}.testf", Environment.CurrentDirectory, Guid.NewGuid());

            _toSave = new SaveToFile<ToSave>(Path);
        }

        [TestCleanup]
        public void CleanUp()
        {
            if (File.Exists(Path))
                File.Delete(Path);
        }

        [TestMethod]
        public void should_save_object()
        {
            var toSave = new ToSave { Id = 1, Name = "Save" };

            _toSave.Save(toSave);

            Assert.IsTrue(File.Exists(Path));
        }

        [TestMethod]
        public void should_read_object()
        {
            var toSave = new ToSave { Id = 2, Name = "Read" };

            _toSave.Save(toSave);

            var saved = _toSave.Read();

            Assert.AreEqual(toSave.Id, saved.Id);
        }

        [TestMethod]
        public void should_remove_object()
        {
            var toSave = new ToSave { Id = 3, Name = "Delete" };

            _toSave.Save(toSave);
            _toSave.Delete();

            var read = _toSave.Read();

            Assert.IsNull(read);
        }

        [Serializable]
        public class ToSave
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}

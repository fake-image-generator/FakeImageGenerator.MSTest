using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace FakeImageGenerator.MSTest.Test
{
    [TestClass]
    public class FakeImageGeneratorAttributeTest
    {
        [DataTestMethod]
        [FakeImageGeneratorAttribute(10000000, "Png", "C:/")]
        public void GenerateFakeImageWithOutputPathShouldBeOk(string path)
        {
            var file = new FileInfo(path);

            Assert.AreEqual(10000000, file.Length);
            Assert.AreEqual(".png", file.Extension);
        }

        [DataTestMethod]
        [FakeImageGeneratorAttribute(10000000, "Png")]
        public void GenerateFakeImageWithoutOutputPathShouldBeOk(byte[] array)
        {
            Assert.AreEqual(10000000, array.Length);
        }
    }
}

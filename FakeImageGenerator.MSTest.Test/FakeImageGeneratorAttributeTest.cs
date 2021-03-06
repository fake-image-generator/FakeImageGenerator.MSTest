using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Runtime.InteropServices;

namespace FakeImageGenerator.MSTest.Test
{
    [TestClass]
    public class FakeImageGeneratorAttributeTest
    {
        [TestMethod]
#if _WINDOWS
        [FakeImageGenerator(10000000, "Png", "C:/")]
#else
        [FakeImageGenerator(10000000, "Png", "/home/runner/work/FakeImageGenerator.MSTest/")]
#endif
        public void GenerateFakeImageWithOutputPathShouldBeOk(string path)
        {
            var file = new FileInfo(path);

            Assert.AreEqual(10000000, file.Length);
            Assert.AreEqual(".png", file.Extension);
        }

        [TestMethod]
        [FakeImageGenerator(10000000, "Png")]
        public void GenerateFakeImageWithoutOutputPathShouldBeOk(byte[] array)
        {
            Assert.AreEqual(10000000, array.Length);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace FakeImageGenerator.MSTest
{
    public class FakeImageGeneratorAttribute : Attribute, ITestDataSource
    {
        private readonly int sizeInBytes;
        private readonly string extension;
        private readonly string outputPath;

        /// <summary>
        ///     Generate fake image for a test.
        /// </summary>
        /// <param name="sizeInBytes">The size of the image in bytes.</param>
        /// <param name="extension">The image extension. Extensions available are png and jpg.</param>
        /// <param name="oututPath">The image output path.</param>
        public FakeImageGeneratorAttribute(int sizeInBytes, string extension, string outputPath)
        {
            this.sizeInBytes = sizeInBytes;
            this.extension = extension;
            this.outputPath = outputPath;
        }

        /// <summary>
        ///     Generate fake image for test.
        /// </summary>
        /// <param name="sizeInBytes">The size of the image in bytes.</param>
        /// <param name="extension">The image extension. Extensions available are png and jpg.</param>
        public FakeImageGeneratorAttribute(int sizeInBytes, string extension)
        {
            this.sizeInBytes = sizeInBytes;
            this.extension = extension;
        }

        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            if (methodInfo == null)
            {
                throw new ArgumentNullException(nameof(methodInfo));
            }

            var generator = new Generator();

            if (string.IsNullOrEmpty(outputPath))
            {
                yield return new object[] { generator.Run(sizeInBytes, extension) };
            }
            else
            {
                generator.Run(sizeInBytes, extension, outputPath);

                yield return new object[] { Path.Combine(outputPath, $"image.{extension.ToLower()}") };
            }
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            return methodInfo.Name;
        }
    }
}

namespace DeanFernandes.Dota2UltOverlay.Tests
{
    [TestClass]
    public sealed class ImageProcessorTests
    {
        [TestMethod]
        public void PerformTemplateMatch_SameImage_ReturnTrue()
        {
            //Arrange
            string imagePath = @"Resources\Images\Heroes\abaddon.png";

            //Act
            bool match = ImageProcessor.PerformTemplateMatch(imagePath, imagePath);

            //Assert
            Assert.IsTrue(match);
        }

        [TestMethod]
        public void PerformTemplateMatch_DifferentImage_ReturnFalse()
        {
            //Arrange
            string imagePath = @"Resources\Images\Heroes\abaddon.png";
            string templatePath = @"Resources\Images\Heroes\bane.png";

            //Act
            bool match = ImageProcessor.PerformTemplateMatch(imagePath, templatePath);

            //Assert
            Assert.IsFalse(match);
        }

        [TestMethod]
        public void PerformTemplateMatch_EmptyImagePath_ThrowsArgumentException()
        {
            // Arrange
            string imagePath = "";
            string templatePath = @"Resources\Images\Heroes\abaddon.png";

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => ImageProcessor.PerformTemplateMatch(imagePath, templatePath));
        }

        [TestMethod]
        public void PerformTemplateMatch_EmptyTemplatePath_ThrowsArgumentException()
        {
            // Arrange
            string imagePath = @"Resources\Images\Heroes\abaddon.png";
            string templatePath = "";

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => ImageProcessor.PerformTemplateMatch(imagePath, templatePath));
        }

        [TestMethod]
        public void PerformTemplateMatch_EmptyPaths_ThrowsArgumentException()
        {
            // Arrange
            string imagePath = "";
            string templatePath = "";

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => ImageProcessor.PerformTemplateMatch(imagePath, templatePath));
        }
    }
}

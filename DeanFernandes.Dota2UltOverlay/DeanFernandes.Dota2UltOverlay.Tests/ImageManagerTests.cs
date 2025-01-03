namespace DeanFernandes.Dota2UltOverlay.Tests
{
    [TestClass]
    public sealed class ImageManagerTests
    {
        [TestMethod]
        public void GetHeroImagePath_ValidHero_ReturnPath()
        {
            //Arrange
            string heroName = "earthshaker";

            //Act
            string heroImagePath = ImageManager.GetHeroImagePath(heroName);

            //Assert
            Assert.IsFalse(string.IsNullOrEmpty(heroImagePath));
            Assert.IsTrue(heroImagePath.Contains(".png"));
        }

        [TestMethod]
        public void GetHeroImagePath_ValidHeroUppercase_ReturnPath()
        {
            //Arrange
            string heroName = "EARTHSHAKER";

            //Act
            string heroImagePath = ImageManager.GetHeroImagePath(heroName);

            //Assert
            Assert.IsFalse(string.IsNullOrEmpty(heroImagePath));
            Assert.IsTrue(heroImagePath.Contains(".png"));
        }

        [TestMethod]
        public void GetHeroImagePath_ValidTwoWordHero_ReturnPath()
        {
            //Arrange
            string heroName = "lone_druid";

            //Act
            string heroImagePath = ImageManager.GetHeroImagePath(heroName);

            //Assert
            Assert.IsFalse(string.IsNullOrEmpty(heroImagePath));
            Assert.IsTrue(heroImagePath.Contains(".png"));
        }

        [TestMethod]
        public void GetHeroImagePath_InvalidHero_ReturnPath()
        {
            //Arrange
            string heroName = "ahri";

            //Act
            string heroImagePath = ImageManager.GetHeroImagePath(heroName);

            //Assert
            Assert.IsTrue(string.IsNullOrEmpty(heroImagePath));
        }
    }
}

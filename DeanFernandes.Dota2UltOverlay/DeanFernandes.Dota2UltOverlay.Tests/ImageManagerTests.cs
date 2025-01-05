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
        public void GetHeroImagePath_EmptyHeroName_ThrowsArgumentException()
        {
            //Arrange
            string emptyHeroName = "";

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => ImageManager.GetHeroImagePath(emptyHeroName));
        }

        [TestMethod]
        public void GetHeroUltimateImagePath_ValidHeroUltimate_ReturnPath()
        {
            //Arrange
            string heroName = "bane";
            string ultName = "nightmare";

            //Act
            string heroUltimateImagePath = ImageManager.GetHeroUltimateImagePath(heroName, ultName);

            //Assert
            Assert.IsFalse(string.IsNullOrEmpty(heroUltimateImagePath));
            Assert.IsTrue(heroUltimateImagePath.Equals("/Resources/Images/Ultimates/bane_nightmare.png"));
        }

        [TestMethod]
        public void GetHeroUltimateImagePath_ValidHeroUltimateUppercase_ReturnPath()
        {
            //Arrange
            string heroName = "BANE";
            string ultName = "NIGHTMARE";

            //Act
            string heroUltimateImagePath = ImageManager.GetHeroUltimateImagePath(heroName, ultName);

            //Assert
            Assert.IsFalse(string.IsNullOrEmpty(heroUltimateImagePath));
            Assert.IsTrue(heroUltimateImagePath.Contains(".png"));
        }

        [TestMethod]
        public void GetHeroUltimateImagePath_ValidHeroUltimateTwoWordHero_ReturnPath()
        {
            //Arrange
            string heroName = "night_stalker";
            string ultName = "darkness";

            //Act
            string heroUltimateImagePath = ImageManager.GetHeroUltimateImagePath(heroName, ultName);

            //Assert
            Assert.IsFalse(string.IsNullOrEmpty(heroUltimateImagePath));
            Assert.IsTrue(heroUltimateImagePath.Contains(".png"));
        }
        public void GetHeroUltimateImagePath_ValidHeroUltimateTwoWordUlt_ReturnPath()
        {
            //Arrange
            string heroName = "puck";
            string ultName = "dream_coil";

            //Act
            string heroUltimateImagePath = ImageManager.GetHeroUltimateImagePath(heroName, ultName);

            //Assert
            Assert.IsFalse(string.IsNullOrEmpty(heroUltimateImagePath));
            Assert.IsTrue(heroUltimateImagePath.Contains(".png"));
        }

        [TestMethod]
        public void GetHeroUltimateImagePath_EmptyNames_ThrowsArgumentException()
        {
            //Arrange
            string emptyHeroName = "";
            string emptyUltName = "";

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => ImageManager.GetHeroUltimateImagePath(emptyHeroName, emptyUltName));
        }
    }
}

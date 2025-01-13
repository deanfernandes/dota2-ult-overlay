namespace DeanFernandes.Dota2UltOverlay.Tests
{
    [TestClass]
    public sealed class HeroProcessorTests
    {
        [TestMethod]
        [DataRow(@"C:\Users\work\Desktop\repos\dota2-ult-overlay\DeanFernandes.Dota2UltOverlay\DeanFernandes.Dota2UltOverlay.Tests\Resources\Images\screenshot_eg_VVAWD.png", "viper,vengefulspirit,axe,warlock,death_prophet")]
        [DataRow(@"C:\Users\work\Desktop\repos\dota2-ult-overlay\DeanFernandes.Dota2UltOverlay\DeanFernandes.Dota2UltOverlay.Tests\Resources\Images\screenshot_eg_TWSLS.png", "tidehunter,witch_doctor,sniper,lion,sven")]
        public void ProcessHeroes_ValidHeroesScreenshot_Return5CorrectHeroes(string heroesImagePath, string expectedHeroes)
        {
            //Arrange
            var expectedHeroesList = expectedHeroes.Split(',');

            //Act
            var heroes = HeroProcessor.ProcessHeroes(heroesImagePath);

            //Assert
            Assert.AreEqual(5, heroes.Count, "The list should contain exactly 5 elements.");
            foreach (var expectedHero in expectedHeroesList)
            {
                Assert.IsTrue(heroes.Contains(expectedHero), $"list should contain {expectedHero}");
            }
        }
    }
}

namespace GameEngine.Tests;

[TestClass]
public class BossEnemyShould
{
    [TestMethod]
    public void HaveCorrectSpecialAttackPower()
    {
        var sut = new BossEnemy();

        Assert.AreEqual(166.6, sut.SpecialAttackPower, 0.07);
    }
}

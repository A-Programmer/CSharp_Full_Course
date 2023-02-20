namespace GameEngine.Tests;

[TestClass]
public class EnemyFactoryShould
{
    [TestMethod]
    public void NotAllowNullName()
    {
        EnemyFactory sut = new EnemyFactory();

        Assert.ThrowsException<ArgumentNullException>(
            () => sut.Create(null)
        );
    }

    [TestMethod]
    public void OnlyAllowKingOrQueenBossEnemies()
    {
        EnemyFactory sut = new EnemyFactory();

        Assert.ThrowsException<EnemyCreationException>(
            () => sut.Create("Zombie", true));
    }

    [TestMethod]
    public void OnlyAllowKingOrQueenBossEnemies_V2()
    {
        EnemyFactory sut = new EnemyFactory();

        EnemyCreationException ex = Assert.ThrowsException<EnemyCreationException>(
            () => sut.Create("Zombie", true));

        Assert.AreEqual("Zombie", ex.RequestedEnemyName);
    }

    [TestMethod]
    public void CreateNormalEnemyByDefault()
    {
        EnemyFactory sut = new EnemyFactory();

        Enemy enemy = sut.Create("Zombie");

        Assert.IsInstanceOfType(enemy, typeof(NormalEnemy));
    }

    // [TestMethod]
    // public void CreateNormalEnemyByDefault_NotTypeExample()
    // {
    //     EnemyFactory sut = new EnemyFactory();

    //     Enemy enemy = sut.Create("Zombie");

    //     Assert.IsNotInstanceOfType(enemy, typeof(NormalEnemy));
    // }

    [TestMethod]
    public void CreateBossEnemy()
    {
        EnemyFactory sut = new EnemyFactory();

        Enemy enemy = sut.Create("Zombie King", true);

        Assert.IsInstanceOfType(enemy, typeof(BossEnemy));
    }

    [TestMethod]
    public void CreateSeparateInstances()
    {
        EnemyFactory sut = new EnemyFactory();

        Enemy enemy1 = sut.Create("Zombie");
        Enemy enemy2 = sut.Create("Zombie");

        Assert.AreNotSame(enemy1, enemy2);
    }
}

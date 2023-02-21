using System.Text.RegularExpressions;
using GameEngine;
namespace GameEngine.Tests;

[TestClass]
public class PlayerCharacterShould
{
    PlayerCharacter sut;
    [TestInitialize]
    public void TestInitialize()
    {
        sut = new()
        {
            FirstName = "Kamran",
            LastName = "Sadin"
        };
    }
    [TestMethod]
    [PlayerDefaults]
    public void BeInexperiencedWhenNew()
    {
        Assert.IsTrue(sut.IsNoob);
    }

    [TestMethod]
    [PlayerDefaults]
    // [Ignore]
    public void NotHaveNickNameByDefault()
    {
        Assert.IsNull(sut.NickName);
    }

    [TestMethod]
    [PlayerDefaults]
    // [Ignore("Ignored for refactoring")]
    public void StartWithDefaultHealth()
    {
        Assert.AreEqual(100, sut.Health);
    }

    public static IEnumerable<object[]> Damages
    {
        get
        {
            return new List<object[]>
            {
                new object[] { 1, 99 },
                new object[] { 0, 100 },
                new object[] { 100, 1 },
                new object[] { 101, 1 },
                new object[] { 50, 50 },
                new object[] { 40, 60 }
            };
        }
    }
    public static IEnumerable<object[]> GetDamages()
    {
        return new List<object[]>
        {
            new object[] { 1, 99 },
            new object[] { 0, 100 },
            new object[] { 100, 1 },
            new object[] { 101, 1 },
            new object[] { 50, 50 },
            new object[] { 10, 90 }
        };
    }

    [DataTestMethod]
    // [DataRow(1, 99)]
    // [DataRow(0, 100)]
    // [DataRow(100, 1)]
    // [DataRow(101, 1)]
    // [DataRow(50, 50)]
    // [DynamicData(nameof(Damages))]
    // [DynamicData(nameof(GetDamages), DynamicDataSourceType.Method)]
    // [DynamicData(nameof(DamageData.GetDamages),
    //             typeof(DamageData),
    //             DynamicDataSourceType.Method)]
    // [DynamicData(nameof(ExtenralHealthDamageTestData.TestData),
    //             typeof(ExtenralHealthDamageTestData))]
    [CsvDataSource("Damage.csv")]
    [TestCategory("Player Health")]
    public void TakeDamage(int damage, int expectedHealth)
    {
        sut.TakeDamage(damage);

        Assert.AreEqual(expectedHealth, sut.Health);
    }

    [TestMethod]
    [TestCategory("Player Health")]
    public void TakeDamage_NotEqual()
    {
        sut.TakeDamage(1);

        Assert.AreNotEqual(100, sut.Health);
    }

    [TestMethod]
    [TestCategory("Player Health")]
    public void TakeDamage_50()
    {
        sut.TakeDamage(50);

        Assert.AreEqual(50, sut.Health);
    }

    [TestMethod]
    [TestCategory("Player Health")]
    [TestCategory("Another Category")]
    public void IncreaseHealthAfterSkleeping()
    {
        sut.Sleep();

        // Assert.IsTrue(sut.Health >= 101 && sut.Health < 200);
        Assert.That.IsInRange(sut.Health, 101, 200);
    }

    [TestMethod]
    public void CalculateFullName()
    {
        // Assert.AreEqual("Kamran Sadin", sut.FullName);
        Assert.AreEqual("KAMRAN Sadin", sut.FullName, true);
    }

    [TestMethod]
    public void HaveFullNameStartingWithFirstName()
    {
        // Assert.IsTrue(sut.FullName.StartsWith("Kamran"));
        StringAssert.StartsWith(sut.FullName, "Kamran");
    }

    [TestMethod]
    public void HaveFullNameEndsWithLastName()
    {
        // Assert.IsTrue(sut.FullName.StartsWith("Kamran"));
        StringAssert.EndsWith(sut.FullName, "Sadin");
    }

    [TestMethod]
    public void CalculateFullName_SubstringAssertExample()
    {
        // Assert.IsTrue(sut.FullName.StartsWith("Kamran"));
        StringAssert.Contains(sut.FullName, "an Sa");
    }

    [TestMethod]
    public void CalculateFullNameWithTitleCase()
    {
        StringAssert.Matches(sut.FullName, new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
    }

    [TestMethod]
    public void HaveALongBow()
    {
        CollectionAssert.Contains(sut.Weapons, "Long Bow");
    }

    [TestMethod]
    public void NotHaveStaffOfWonder()
    {
        CollectionAssert.DoesNotContain(sut.Weapons, "Staff Of Wonder");
    }

    [TestMethod]
    public void HaveAllExpectedWeapons()
    {
        var expectedWeapons = new[]
        {
            "Long Bow",
            "Short Bow",
            "Short Sword"
        };
        
        CollectionAssert.AreEqual(expectedWeapons, sut.Weapons);
    }

    [TestMethod]
    public void HaveAllExpectedWeapons_AnyOrder()
    {
        var expectedWeapons = new[]
        {
            "Short Sword",
            "Short Bow",
            "Long Bow"
        };
        
        CollectionAssert.AreEquivalent(expectedWeapons, sut.Weapons);
    }

    [TestMethod]
    public void HaveDuplicateWeapons()
    {
        // sut.Weapons.Add("Short Bow");

        CollectionAssert.AllItemsAreUnique(sut.Weapons);
    }

    [TestMethod]
    public void HaveAtLeastOneKindOfSword()
    {
        // Assert.IsTrue(sut.Weapons.Any(weapon => weapon.Contains("Sword")));
        CollectionAssert.That.AtLeastOneItemSatisfies(sut.Weapons,
                                                    weapon => weapon.Contains("Sword"));
    }

    [TestMethod]
    public void HaveNotEmptyDefaultWeapons()
    {
        // Assert.IsFalse(sut.Weapons.Any(weapon => string.IsNullOrWhiteSpace(weapon)));
        // CollectionAssert.That.AllItemsNotNullOrWhitespace(sut.Weapons);

        // CollectionAssert.That.AllItemsSatisfy(sut.Weapons,
        //                                 weapon => !string.IsNullOrWhiteSpace(weapon));

        CollectionAssert.That.All(sut.Weapons, weapon =>
        {
            StringAssert.That.NotNullOrWhitespace(weapon);
            Assert.IsTrue(weapon.Length > 5);
            // etc.
        });
    }
}
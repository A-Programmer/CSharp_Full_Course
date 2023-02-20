using System.Text.RegularExpressions;
using GameEngine;
namespace GameEngine.Tests;

[TestClass]
public class PlayerCharacterShould
{
    [TestMethod]
    public void BeInexperiencedWhenNew()
    {
        PlayerCharacter sut = new();

        Assert.IsTrue(sut.IsNoob);
    }

    [TestMethod]
    public void NotHaveNickNameByDefault()
    {
        var sut = new PlayerCharacter();

        Assert.IsNull(sut.NickName);
    }

    [TestMethod]
    public void StartWithDefaultHealth()
    {
        var sut = new PlayerCharacter();

        Assert.AreEqual(100, sut.Health);
    }

    [TestMethod]
    public void TakeDamage()
    {
        var sut = new PlayerCharacter();
        sut.TakeDamage(1);

        Assert.AreEqual(99, sut.Health);
    }

    [TestMethod]
    public void TakeDamage_NotEqual()
    {
        var sut = new PlayerCharacter();
        sut.TakeDamage(1);

        Assert.AreNotEqual(100, sut.Health);
    }

    [TestMethod]
    public void IncreaseHealthAfterSkleeping()
    {
        var sut = new PlayerCharacter();
        sut.Sleep();

        Assert.IsTrue(sut.Health >= 101 && sut.Health < 200);
    }

    [TestMethod]
    public void CalculateFullName()
    {
        var sut = new PlayerCharacter();
        sut.FirstName = "Kamran";
        sut.LastName = "Sadin";

        // Assert.AreEqual("Kamran Sadin", sut.FullName);
        Assert.AreEqual("KAMRAN Sadin", sut.FullName, true);
    }

    [TestMethod]
    public void HaveFullNameStartingWithFirstName()
    {
        var sut = new PlayerCharacter();
        sut.FirstName = "Kamran";
        sut.LastName = "Sadin";

        // Assert.IsTrue(sut.FullName.StartsWith("Kamran"));
        StringAssert.StartsWith(sut.FullName, "Kamran");
    }

    [TestMethod]
    public void HaveFullNameEndsWithLastName()
    {
        var sut = new PlayerCharacter();
        sut.FirstName = "Kamran";
        sut.LastName = "Sadin";

        // Assert.IsTrue(sut.FullName.StartsWith("Kamran"));
        StringAssert.EndsWith(sut.FullName, "Sadin");
    }

    [TestMethod]
    public void CalculateFullName_SubstringAssertExample()
    {
        var sut = new PlayerCharacter();
        sut.FirstName = "Kamran";
        sut.LastName = "Sadin";

        // Assert.IsTrue(sut.FullName.StartsWith("Kamran"));
        StringAssert.Contains(sut.FullName, "an Sa");
    }

    [TestMethod]
    public void CalculateFullNameWithTitleCase()
    {
        var sut = new PlayerCharacter();
        sut.FirstName = "Kamran";
        sut.LastName = "Sadin";

        StringAssert.Matches(sut.FullName, new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
    }

    [TestMethod]
    public void HaveALongBow()
    {
        var sut = new PlayerCharacter();
        
        CollectionAssert.Contains(sut.Weapons, "Long Bow");
    }

    [TestMethod]
    public void NotHaveStaffOfWonder()
    {
        var sut = new PlayerCharacter();
        
        CollectionAssert.DoesNotContain(sut.Weapons, "Staff Of Wonder");
    }

    [TestMethod]
    public void HaveAllExpectedWeapons()
    {
        var sut = new PlayerCharacter();

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
        var sut = new PlayerCharacter();

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
        var sut = new PlayerCharacter();

        // sut.Weapons.Add("Short Bow");

        CollectionAssert.AllItemsAreUnique(sut.Weapons);
    }

    [TestMethod]
    public void HaveAtLeastOneKindOfSword()
    {
        var sut = new PlayerCharacter();

        Assert.IsTrue(sut.Weapons.Any(weapon => weapon.Contains("Sword")));
    }

    [TestMethod]
    public void HaveNotEmptyDefaultWeapons()
    {
        var sut = new PlayerCharacter();

        Assert.IsFalse(sut.Weapons.Any(weapon => string.IsNullOrWhiteSpace(weapon)));
    }
}
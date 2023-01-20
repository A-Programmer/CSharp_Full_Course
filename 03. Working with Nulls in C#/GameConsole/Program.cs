using GameConsole;

namespace GameConsole;
public class Program
{
    public static void Main(string[] args)
    {
        PlayerCharacter sarah = new PlayerCharacter(new DiamondSkinDefence())
        {
            Name = "Sarah"
        };
        PlayerCharacter amrit = new PlayerCharacter(new IronBonesDefence())
        {
            Name = "Amrit"
        };
        PlayerCharacter gentry = new PlayerCharacter(SpecialDefence.Null)
        {
            Name = "Gentry"
        };
    }
}
public class PlayerCharacter
{
    private readonly SpecialDefence _specialDefence;
    public PlayerCharacter(SpecialDefence specialDefence)
    {
        _specialDefence = specialDefence;
    }
    public string Name { get; set; }
    public int Health { get; set; } = 100;
    public void Hit(int damage)
    {
        int damageReduction = 0;
        damageReduction = _specialDefence.CalculateDamageReduction(damage);

        int totalDamageTaken = damage = damageReduction;

        Health -= totalDamageTaken;

        Console.WriteLine($"{Name}'s health has been reduced by {totalDamageTaken} to {Health}.");
    }
}

public abstract class SpecialDefence
{
    public abstract int CalculateDamageReduction(int totalDamage);
    public static SpecialDefence Null { get; } = new NullDefence();
    private class NullDefence : SpecialDefence
    {
        public override int CalculateDamageReduction(int totalDamage)
        {
            return 0;
        }
    }
}
public class IronBonesDefence : SpecialDefence
{
    public override int CalculateDamageReduction(int totalDamage)
    {
        return 5;
    }
}
public class DiamondSkinDefence : SpecialDefence
{
    public override int CalculateDamageReduction(int totalDamage)
    {
        return 1;
    }
}
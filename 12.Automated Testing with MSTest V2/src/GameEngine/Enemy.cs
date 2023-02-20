namespace GameEngine;

public abstract class Enemy
{
    public string Name { get; set; }
    public abstract double TotalSpecialPower { get; }
    public abstract double SpecialPowerUses { get; }
    public double SpecialAttackPower => TotalSpecialPower / SpecialPowerUses;

}
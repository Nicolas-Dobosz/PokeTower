using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public string description;

    public Sprite mainSrpite;
    public BulletData bullet;

    public Vector2 firePointOffset;

    public int speed;
    public int damage;
    public float delay;

    public Rarity rarity;
    public Type type;
    public StatusEffect statusEffect;

    public enum StatusEffect { None, Poison, Freeze, Burn, Stun, Slow, Silence }
    public enum Speed { VerySlow, Slow, Normal, Fast, VeryFast }
    public enum Rarity { Common, Rare, Epic, Legendary }
    public enum Type { Melee, Ranged, Laser }
}

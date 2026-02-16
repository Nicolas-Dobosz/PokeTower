using UnityEngine;

[CreateAssetMenu(fileName = "PokemonData", menuName = "Scriptable Objects/Pokemon")]
public class PokemonData : ScriptableObject
{
    public string pokemonName;
    public string description;

    public Sprite mainSprite;

    public int baseHealth;
    public int baseDamage;
    public float attackCooldown; 
    public float criticalChance;
    public float range;

    public PokemonSpeedType speedType;
    public PokemonType pokemonType;
    public PokemonBiome pokemonBiome;
    public int pokemonFloorApparition;
    public PokemonAttackType attackType;
    public PokemonStatusEffect statusEffect;
    public float effectDuration;
}

public enum PokemonAttackType { Melee, Ranged, Laser}
public enum PokemonStatusEffect { None, Poison, Freeze, Burn, Stun, Slow, Silence }
public enum PokemonSpeedType { VerySlow, Slow, Normal, Fast, VeryFast }
public enum PokemonType { Week, Normal, Strong }
public enum PokemonBiome { Forest, Desert }
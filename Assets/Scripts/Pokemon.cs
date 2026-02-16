using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Pokemon : MonoBehaviour
{
    public PokemonData data;
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider2D;
    private int currentHealth;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (data != null)
        {
            spriteRenderer.sprite = data.mainSprite;
            currentHealth = data.baseHealth;
        }
        
        // Pas utilisé pour l'instant mais je le garde parce que je pense qu'on s'en servira (genre animation de mort)
        polygonCollider2D = gameObject.AddComponent<PolygonCollider2D>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(data.pokemonName + " a maintenant " + currentHealth + " PV");
        if (currentHealth <= 0) Destroy(gameObject);
    }
}
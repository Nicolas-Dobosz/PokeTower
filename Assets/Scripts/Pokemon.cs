using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Pokemon : MonoBehaviour
{
    public PokemonData data;
    private SpriteRenderer spriteRenderer;
    private int currentHealth;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (data != null)
        {
            spriteRenderer.sprite = data.mainSprite;
            currentHealth = data.baseHealth;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(data.PokemonName + " a maintenant " + currentHealth + " PV");
        if (currentHealth <= 0) Destroy(gameObject);
    }
}
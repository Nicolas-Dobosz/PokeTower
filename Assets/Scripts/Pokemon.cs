using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class Pokemon : MonoBehaviour
{
    public PokemonData data;
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider2D;
    public int currentHealth;

    [SerializeField] Material flashMaterial;
    private Material originalMaterial;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;

        if (data != null)
        {
            spriteRenderer.sprite = data.mainSprite;
            currentHealth = data.baseHealth;
        }
        
        // Pas utilisé pour l'instant mais je le garde parce que je pense qu'on s'en servira (genre animation de mort)
        polygonCollider2D = gameObject.AddComponent<PolygonCollider2D>();
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator Flash()
    {
        spriteRenderer.material = flashMaterial;
        
        yield return new WaitForSeconds(0.1f);
        
        if (spriteRenderer != null) 
            spriteRenderer.material = originalMaterial;
    }
}
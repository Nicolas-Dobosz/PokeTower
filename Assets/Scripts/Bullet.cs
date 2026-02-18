using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRenderer))]
public class Bullet : MonoBehaviour
{
    [SerializeField] InputActionAsset inputActions;
    public SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider2D;
    public BulletData bulletData;
    InputAction lookAction;
    void Start()
    {
        Debug.Log(bulletData);
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = bulletData.sprite;
        polygonCollider2D = gameObject.AddComponent<PolygonCollider2D>();
        polygonCollider2D.isTrigger = true;

        lookAction = InputSystem.actions.FindAction("Look");
    }

    void Update()
    {
        
    }
}

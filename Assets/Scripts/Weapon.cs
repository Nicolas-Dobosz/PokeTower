using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRenderer))]
public class Weapon : MonoBehaviour
{
    [SerializeField] InputActionAsset inputActions;
    public WeaponData data;
    private SpriteRenderer spriteRenderer;
    public GameObject bulletPrefab;
    public bool isEquiped = false;

    BulletData bulletData;

    InputAction lookAction;

    void Start()
    {
        bulletData = data.bullet;
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (data != null)
        {
            spriteRenderer.sprite = data.mainSrpite;
        }

        lookAction = InputSystem.actions.FindAction("Look");
    }

    void Update()
    {
        if (isEquiped)
        {
            Vector2 mouseScreenPos = lookAction.ReadValue<Vector2>();

            float distanceZ = Mathf.Abs(Camera.main.transform.position.z);
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, distanceZ));

            Vector2 direction = mouseWorldPos - transform.position;

            float angleZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angleZ);
        }
    }

    public void Shoot()
    {
        Debug.Log("Piou");

        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Bullet bulletScript = newBullet.AddComponent<Bullet>();

        if (bulletScript != null)
        {
            bulletScript.bulletData = bulletData;
        }
    }
}
using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Weapon : MonoBehaviour
{
    public WeaponData data;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (data != null)
        {
            spriteRenderer.sprite = data.mainSrpite;
        }
    }

    public void Shoot()
    {
        Debug.Log("Piou");
    }
}
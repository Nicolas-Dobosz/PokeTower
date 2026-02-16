using UnityEngine;
using System.Collections;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject weaponPrefab;
    
    private WeaponData[] allWeaponData;

    void Start()
    {
        allWeaponData = Resources.LoadAll<WeaponData>("Weapons");

        if (allWeaponData.Length > 0)
        {
            SpawnRandomWeapon();
        }
        else
        {
            Debug.LogError("Aucun WeaponData trouvé dans Resources/Weapons !");
        }
    }

    void SpawnRandomWeapon()
    {
        WeaponData randomData = allWeaponData[Random.Range(0, allWeaponData.Length)];

        Vector3 spawnPosition = transform.position + new Vector3(5, 0, 0);

        GameObject newWeapon = Instantiate(weaponPrefab, spawnPosition, Quaternion.identity);

        Weapon weaponScript = newWeapon.AddComponent<Weapon>();
        if (weaponScript != null)
        {
            weaponScript.data = randomData;
        }
    }
}
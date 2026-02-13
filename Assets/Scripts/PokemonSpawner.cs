using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PokemonSpawner : MonoBehaviour
{
    public GameObject pokemonPrefab;
    public float spawnInterval = 3f;
    
    private PokemonData[] allPokemonData;

    void Start()
    {
        allPokemonData = Resources.LoadAll<PokemonData>("Pokemons");

        if (allPokemonData.Length > 0)
        {
            StartCoroutine(SpawnRoutine());
        }
        else
        {
            Debug.LogError("Aucun PokemonData trouvé dans Resources/Pokemons !");
        }
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnRandomPokemon();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnRandomPokemon()
    {
        PokemonData randomData = allPokemonData[Random.Range(0, allPokemonData.Length)];

        Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);

        GameObject newPokemon = Instantiate(pokemonPrefab, spawnPosition, Quaternion.identity);

        Pokemon pokemonScript = newPokemon.AddComponent<Pokemon>();
        if (pokemonScript != null)
        {
            pokemonScript.data = randomData;
        }
    }
}
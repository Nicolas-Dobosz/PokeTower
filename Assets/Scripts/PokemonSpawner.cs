using UnityEngine;
using System.Collections;

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
            yield return new WaitForSeconds(spawnInterval);
            
            SpawnRandomPokemon();
        }
    }

    void SpawnRandomPokemon()
    {
        PokemonData randomData = allPokemonData[Random.Range(0, allPokemonData.Length)];

        Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-16f, 16f), Random.Range(-7f, 7f), 0);

        GameObject newPokemon = Instantiate(pokemonPrefab, spawnPosition, Quaternion.identity);

        if (newPokemon.TryGetComponent<Pokemon>(out var pokemonScript))
        {
            pokemonScript.data = randomData;
        }
    }
}
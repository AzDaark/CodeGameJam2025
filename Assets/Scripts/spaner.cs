using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] Prefab; // Tableau des objets à instancier
    [SerializeField] float minSpawnInterval = 0.2f; // Intervalle minimum entre les spawns
    [SerializeField] float maxSpawnInterval = 1f; // Intervalle maximum entre les spawns

    [SerializeField] Transform[] spawnPoints; // Trois positions définissant les voies

    void Start()
    {
        StartCoroutine(FruitSpawn());
    }

    IEnumerator FruitSpawn()
    {
        while (true)
        {
            // Choisir un spawner (voie) aléatoire parmi les spawnPoints
            int spawnerIndex = Random.Range(0, spawnPoints.Length);

            // Choisir un prefab aléatoire parmi les objets dans Prefab
            GameObject prefabToSpawn = Prefab[Random.Range(0, Prefab.Length)];

            // Instancier l'objet à la position du spawner choisi
            GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPoints[spawnerIndex].position, Quaternion.identity);

            // Détruire l'objet après 5 secondes
            Destroy(spawnedObject, 5f);

            // Attendre un intervalle aléatoire avant de recommencer
            float interval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(interval);
        }
    }
}
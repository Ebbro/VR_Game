using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SpawnBase : MonoBehaviour
{
    public GameObject prefabToSpawn;  // Il prefab da spawnare
    public Transform spawnLocation;   // La posizione di spawn
    private GameObject spawnedPrefab; // Riferimento al prefab spawnato
    private float distanceThreshold = 3f;  // La distanza minima prima che venga creato un nuovo prefab
    private Vector3 initialPosition;  // Posizione iniziale del prefab

    void Start()
    {
        // Spawn automatico del prefab all'avvio della scena
        SpawnPrefab();
    }

    void Update()
    {
        // Verifica se il prefab è stato spostato dalla posizione iniziale
        if (spawnedPrefab != null && Vector3.Distance(spawnedPrefab.transform.position, initialPosition) > distanceThreshold)
        {
            // Se il prefab è troppo lontano dalla posizione iniziale, spawnane uno nuovo
            SpawnPrefab();
        }
    }

    void SpawnPrefab()
    {
        if (prefabToSpawn != null && spawnLocation != null)
        {

            // Instanzia un nuovo prefab nella posizione di spawn
            spawnedPrefab = Instantiate(prefabToSpawn, spawnLocation.position, spawnLocation.rotation);

            // Salva la posizione iniziale del prefab
            initialPosition = spawnedPrefab.transform.position;
        }
    }
}
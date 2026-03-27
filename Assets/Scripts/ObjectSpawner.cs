using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [System.Serializable]
    public class SpawnConfig
    {
        public string poolTag;
        public float minSpawnRate = 2f; // Rango mínimo
        public float maxSpawnRate = 5f; // Rango máximo
        public Vector2 yRange; 
    }

    [SerializeField] private List<SpawnConfig> configs;
    [SerializeField] private float xOffset = 15f; 

    void Start()
    {
        foreach (var config in configs)
        {
            StartCoroutine(SpawnRoutine(config));
        }
    }

    IEnumerator SpawnRoutine(SpawnConfig config)
    {
        // Espera inicial para que no aparezca todo apenas inicia el juego
        yield return new WaitForSeconds(Random.Range(1f, 3f));

        while (true)
        {
            // TIEMPO ALEATORIO: Hace que el flujo de enemigos se sienta natural
            float waitTime = Random.Range(config.minSpawnRate, config.maxSpawnRate);
            yield return new WaitForSeconds(waitTime);

            if (ObjectPoolling.Instance == null) break;

            // POSICIÓN: Usamos la posición del spawner (hijo de la cámara) + offset
            float spawnY = Random.Range(config.yRange.x, config.yRange.y);
            
            // Variación pequeña en X para que no se vea una fila india
            float spawnX = transform.position.x + xOffset + Random.Range(-1f, 1f);
            
            Vector3 spawnPos = new Vector3(spawnX, spawnY, 0);

            GameObject obj = ObjectPoolling.Instance.GetPoolObject(config.poolTag);
            
            if (obj != null)
            {
                obj.transform.position = spawnPos;
                // Opcional: Si el objeto tiene un script de reset, llámalo aquí
                // obj.GetComponent<IPoolable>()?.OnSpawn();
            }
        }
    }
}
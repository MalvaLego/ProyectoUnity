using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGems : MonoBehaviour
{
    public GameObject gemPrefab; // Prefab de la gema
    public int maxGems = 20; // Máximo de gemas permitidas en el plano
    public float spawnInterval = 7f; // Intervalo de generación
    private float fixedYPosition = 1f;

    private List<GameObject> gems = new List<GameObject>();
    private BoxCollider[] colliders;
    // Start is called before the first frame update
    void Start()
    {
       colliders = GetComponentsInChildren<BoxCollider>(); // Obtener todos los Box Colliders hijos
        StartCoroutine(SpawnGemsRoutine());
    }

    IEnumerator SpawnGemsRoutine()
    {
       while (true)
        {
            // Limpia la lista de gemas destruidas
            gems.RemoveAll(gem => gem == null);

            // Si el número de gemas activas es menor que el máximo, generamos una nueva
            if (gems.Count < maxGems)
            {
                // Elegir aleatoriamente un collider
                BoxCollider selectedCollider = colliders[Random.Range(0, colliders.Length)];
                Vector3 spawnPosition = GetRandomPositionInCollider(selectedCollider);
                
                GameObject newGem = Instantiate(gemPrefab, spawnPosition, Quaternion.identity);
                gems.Add(newGem);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector3 GetRandomPositionInCollider(BoxCollider collider)
    {
        // Obtener el rango de las coordenadas en los ejes X y Z del collider
        Vector3 randomPoint = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            fixedYPosition, // Ajustar la altura si es necesario
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );

        return randomPoint;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZoneAttack : MonoBehaviour
{
    public GameObject tentaclePrefab;
    public GameObject player;
    public float spawnInterval = 6f; // Intervalo entre ataques
    public float displayDuration = 4.5f;
    public float tentacleDelay = 1.5f;

    
    //private bool isSpawning = false;
    private GameObject currentTentacle;
    // Start is called before the first frame update
    void Start()
    {
       Destroy(currentTentacle);
        InvokeRepeating("SpawnRedZone", 2f, spawnInterval);
    }

    // Update is called once per frame
    void SpawnRedZone()
    {
        //if (!gameObject.activeSelf)
        //{
        Destroy(currentTentacle);
            // Activa el círculo rojo
            gameObject.SetActive(true);
            // Coloca el círculo en la posición del jugador
            transform.position = new Vector3(player.transform.position.x,0.1f,player.transform.position.z);

            Invoke("SpawnTentacle", tentacleDelay);

            // Después de un tiempo, desactiva el círculo
            StartCoroutine(DeactivateRedZone());
        //}
    }

    void SpawnTentacle()
    {
        Destroy(currentTentacle);
        // Instancia el tentáculo en la posición actual del círculo
        Vector3 spawnPosition = transform.position;
        spawnPosition.y += 2.5f;
        spawnPosition.x += -0.5f;
        spawnPosition.z += -2.5f;
        
        if (gameObject.activeSelf){
            currentTentacle = Instantiate(tentaclePrefab, spawnPosition, Quaternion.identity);
        }
        
    }

    IEnumerator DeactivateRedZone()
    {
        // Espera el tiempo especificado
        yield return new WaitForSeconds(displayDuration);
        // Desactiva el círculo
        gameObject.SetActive(false);

        // Destruye el tentáculo después de que desaparezca el círculo
        //if (currentTentacle != null)
        //{
            Destroy(currentTentacle);
        //}
    }
}

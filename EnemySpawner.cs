using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


}

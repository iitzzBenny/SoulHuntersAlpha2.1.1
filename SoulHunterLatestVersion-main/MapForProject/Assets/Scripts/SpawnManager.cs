using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefabs, new Vector3(-18, 0, -7), enemyPrefabs.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

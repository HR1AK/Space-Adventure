using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner: MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f;//1.5f; 
    [SerializeField] private float timeDestroy = 5f;//5f;
    [SerializeField] private float maxHeightRange = 0.1f;
    [SerializeField] private float minHeightRange = -0.1f;
    [SerializeField] private GameObject asteroidsPrefs;

    private float timer;

    void Start()
    {
       Spawner(); 
    }

    void Update()
    {
        if(timer > maxTime)
        {
            Spawner();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    void Spawner()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(minHeightRange, maxHeightRange));
        GameObject meteorits = Instantiate(asteroidsPrefs, spawnPosition, Quaternion.identity);

        Destroy(meteorits, timeDestroy);
    }
}

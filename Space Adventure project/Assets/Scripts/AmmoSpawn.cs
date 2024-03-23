using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawn : MonoBehaviour
{
    [SerializeField] private float maxTime = 10f;//1.5f; 
    [SerializeField] private float timeDestroy = 5f;//5f;
    [SerializeField] private float maxHeightRange = 1f;
    [SerializeField] private float minHeightRange = -1f;
    [SerializeField] private GameObject ammoPrefs;



    private float timer = 0;

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
        GameObject ammo = Instantiate(ammoPrefs, spawnPosition, Quaternion.identity);

        Destroy(ammo, timeDestroy);
    }
}

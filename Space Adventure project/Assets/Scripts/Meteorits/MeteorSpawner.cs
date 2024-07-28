using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class MeteorSpawner: MonoBehaviour
{
    [SerializeField] private float meteoritTimeDestroy = 5f;
    [SerializeField] private float maxHeightRange = 0.1f;
    [SerializeField] private float minHeightRange = -0.1f;
    [SerializeField] private GameObject asteroidsPrefs;



    //Cave///
    [SerializeField] private GameObject CaveEnter;
    [SerializeField] private GameObject[] CavePart = new GameObject[2];
    [SerializeField] private GameObject CaveExit;

    [SerializeField] private bool meteorithLocation;
    [SerializeField] private bool caveLocation;

    [SerializeField] private float caveTimeDestroy = 7f;
    int chanse;

    //BlackHole//
    [SerializeField] private GameObject BlackHole;

    void Start()
    {
        SetLocation();
        StartCoroutine(ISpawner());
    }

    IEnumerator ISpawner()
    {
        while(true)
        {
            if(meteorithLocation)
            {
                MeteoritSpawner();
                yield return new WaitForSeconds(1);
            }

            if(caveLocation)
            {
                yield return new WaitForSeconds(1);
                CaveSpawner();
                caveLocation = false;
                meteorithLocation = true;
                yield return new WaitForSeconds(9);
            }
            SetLocation();
        }
   }

    void MeteoritSpawner()
    {
            Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(minHeightRange, maxHeightRange));
            GameObject meteorits = Instantiate(asteroidsPrefs, spawnPosition, Quaternion.identity);

            if(Random.Range(0, 100f) < 10)
            {
                Instantiate(BlackHole, spawnPosition, Quaternion.identity);
            }
            Destroy(meteorits, meteoritTimeDestroy);
    }

    void CaveSpawner()
    {   
        Vector3 prevPosition = transform.position;
        prevPosition.x += 1f;
        GameObject enter = Instantiate(CaveEnter, prevPosition, Quaternion.identity);
        prevPosition.x += 1.5f;
        GameObject part1 = Instantiate(CavePart[0], prevPosition, Quaternion.identity);
        prevPosition.x += 0.8f;
        GameObject part2 = Instantiate(CavePart[1], prevPosition + new Vector3(2f, 0 ,0), Quaternion.identity);
        prevPosition.x += 2.5f;
        GameObject exit = Instantiate(CaveExit, prevPosition + new Vector3(1.5f, 0 ,0), Quaternion.identity);

        Destroy(enter, caveTimeDestroy);
        Destroy(part1, caveTimeDestroy+5);
        Destroy(part2, caveTimeDestroy+7);
        Destroy(exit, caveTimeDestroy+9);
    }

    void SetLocation()
    {
        chanse = Random.Range(0, 100);

        switch (chanse)
        {
            case < 90:
                meteorithLocation = true;
                break;
            case >=90:
                caveLocation = true;
                meteorithLocation = false;
                break;
        }
    }

}

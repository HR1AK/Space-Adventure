using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Unity.VisualScripting;
using UnityEngine;

public class LetMovement: MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject meteoritPref;
    private int meteoritsQuantiy; 
    private int j; //разброс от начальной позиции для метеоритов, считается по выведенной формуле
    private float spread = 0f; //разброс от начальной позиции для метеоритов, считается по выведенной формуле
    float dispersion; //разброс позиции метеорита уже внутри собственной области
    private float meteoriteScale;//0.05;
    private int spawnRange = 0;
    private float rotationSpeed = 0f;
    List<GameObject> meteorits = new List<GameObject>();

    void Start()
    {
        spawnRange = Random.Range(0, 100);
        switch (spawnRange)
        {
            case < 80: 
                meteoritsQuantiy = 3;
                break;
            case > 90:
                meteoritsQuantiy = 2;
                break;
            case > 80:
            case < 90:
                meteoritsQuantiy = 1;
                break;
        }

        rotationSpeed = Random.Range(100f, 300f);
        meteoriteScale = Random.Range(0.08f, 0.12f); 
       
        j = meteoritsQuantiy - 1; 
        //GameObject[] meteorits = new GameObject[meteoritsQuantiy];

        for (int i = 0; i < meteoritsQuantiy; i++)
        {
            spread = (i - (float)j)/meteoritsQuantiy;

            meteorits.Add(Instantiate(meteoritPref, transform.position, Quaternion.identity));
            meteorits[i].transform.localScale = new Vector3(meteoriteScale, meteoriteScale, meteoriteScale);
            meteorits[i].transform.parent = this.transform;
           
            dispersion = Random.Range(- 1/(float)meteoritsQuantiy + meteorits[i].transform.localScale.y, 
                                      + 1/(float)meteoritsQuantiy - meteorits[i].transform.localScale.y);
            
            meteorits[i].transform.position += new Vector3(Random.Range(-0.4f, 0.4f), spread + dispersion, 0f);
            j--;
        }

    }
    void Update()
    {
        meteoritsQuantiy = transform.childCount;
        transform.position += Vector3.left * speed * Time.deltaTime;

        for(int i = 0; i < meteoritsQuantiy; i++)
        {
            //meteorits[i].transform.Rotate(0, 0, rotationSpeed * Time.timeScale);
            if(meteorits[i] != null)
            {
                meteorits[i].transform.rotation *= Quaternion.Euler(0, 0, rotationSpeed * Time.timeScale * Time.deltaTime);
            }
        }
        
    }

}

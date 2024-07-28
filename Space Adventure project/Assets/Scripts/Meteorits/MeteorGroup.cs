using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Unity.VisualScripting;
using UnityEngine;

public class MeteorGroup: MonoBehaviour
{
    //[SerializeField] private float speed = 2f;
    private int meteoritsQuantiy; 
    private int j; //разброс от начальной позиции для метеоритов, считается по выведенной формуле
    private float spread = 0f; //разброс от начальной позиции для метеоритов, считается по выведенной формуле
    float dispersion; //разброс позиции метеорита уже внутри собственной области
    Meteorit meteorit = null;
    private Vector3 meteorPos;

    [SerializeField] private DefaultMeteoritFactory defaultMeteoritFactory;
    [SerializeField] private IceMeteoritFactory IceMeteoritFactory;
    [SerializeField] private RedMeteoritFactory RedMeteoritFactory;

    void Start()
    {
        meteoritsQuantiy = ChooseMeteoritQuantity();
        j = meteoritsQuantiy - 1; 

        for (int i = 0; i < meteoritsQuantiy; i++)
        {
            meteorit = MeteoritSpawnerWithChance();
            meteorit.transform.parent = this.transform;

            spread = (i - (float)j)/meteoritsQuantiy;
            dispersion = Random.Range(- 1/(float)meteoritsQuantiy + meteorit.transform.localScale.y, 
                                      + 1/(float)meteoritsQuantiy - meteorit.transform.localScale.y);
            
            meteorit.transform.position += new Vector3(Random.Range(-0.4f, 0.4f), spread + dispersion, 0f);
            
            j--;
        }

    }

    int ChooseMeteoritQuantity()
    {
        int Quantity;
        int spawnRange = Random.Range(0, 100);
        switch (spawnRange)
        {
            case < 80: 
                Quantity = 3;
                break;
            case > 90:
                Quantity = 2;
                break;
            case > 80:
            case <= 90:
                Quantity = 1;
                break;
        }

        return Quantity;
    }

    Meteorit MeteoritSpawnerWithChance()
    {
        int chanse = Random.Range(0, 100);
        switch (chanse)
        {
            case < 80:
                return defaultMeteoritFactory.GetNewInstance(transform.position);
            case > 90:
                return IceMeteoritFactory.GetNewInstance(transform.position);
            case > 80:
             case <= 90:
                return RedMeteoritFactory.GetNewInstance(transform.position);
        }
    }
}

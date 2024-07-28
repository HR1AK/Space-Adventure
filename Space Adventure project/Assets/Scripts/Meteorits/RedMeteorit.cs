using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMeteorit : Meteorit
{
    [SerializeField] private LittleMeteoritFactory littleMeteoritFactory;

    RedMeteorit()
    {
        health = 250;
        damage = 100;
    }

    public override void Die()
    {
        Vector3 newPposition = transform.position;
        for(int i = 0; i < 3; i++)
        {
            newPposition += new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.1f));
            littleMeteoritFactory.GetNewInstance(newPposition);
        }

        if(sfxManager == null) 
            sfxManager = GameObject.FindGameObjectWithTag("SFXManagerTag").GetComponent<SfxManager>();
        sfxManager.PlaySFC(explosionAudio);

        Instantiate(explosionAnimation, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

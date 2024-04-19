using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    [SerializeField] private int bulletCount = 10;
    [SerializeField] private int maxBullets = 10;
    [SerializeField] public Transform bulletPrefab;

    [SerializeField] private TextMeshProUGUI currentBulletsText;
    [SerializeField] private TextMeshProUGUI maxBulletsText;

    SfxManager sfxManager;

    public AudioClip shotAudio;
    public AudioClip takeAmmoAudio;
    // Update is called once per frame
    void Start()

    {
        currentBulletsText.text = bulletCount.ToString();
        maxBulletsText.text = maxBullets.ToString();
        if(sfxManager == null) 
            sfxManager = GameObject.FindGameObjectWithTag("SFXManagerTag").GetComponent<SfxManager>();
    }

    public void Shoot()
    {
        if(bulletCount > 0)
        {
            sfxManager.PlaySFC(shotAudio);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bulletCount--;
        }

        currentBulletsText.text = bulletCount.ToString();
        maxBulletsText.text = maxBullets.ToString();
    }

    public void AddAmmo(int ammo)
    {
        bulletCount = math.min(bulletCount + ammo,10);
        sfxManager.PlaySFC(takeAmmoAudio);
        currentBulletsText.text = bulletCount.ToString();
        maxBulletsText.text = maxBullets.ToString();
    }

}

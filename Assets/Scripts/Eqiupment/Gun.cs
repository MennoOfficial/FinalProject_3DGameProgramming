using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Gun : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] gunshotParticles;
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private GunData gunData;
    [SerializeField] private Transform muzzle;
    float timeSinceLastShot;

    public Camera fpsCam;

    public void Start()
    {
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReload;

        gunshotParticles = GetComponentsInChildren<ParticleSystem>();
    }
    public void StartReload()
    {
        if (!gunData.reloading)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        gunData.reloading = true;
        yield return new WaitForSeconds(gunData.reloadTime);
        gunData.currentAmmo = gunData.magSize;
        gunData.reloading = false;
    }
    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    public void Shoot()
    {
        RaycastHit hit;
        if (gunData.currentAmmo > 0)
        {
            if (CanShoot())
            {
                if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, gunData.maxDistance))
                {
                    IDamageable damageable = hit.transform.GetComponent<IDamageable>();
                    damageable?.Damage(gunData.damage);
                    Debug.Log(hit.transform.name);
                }
                foreach (ParticleSystem particleSystem in gunshotParticles)
                {
                        particleSystem.Play();
                }
            gunData.currentAmmo--;
            timeSinceLastShot = 0;
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);

            }
        }
    }
    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }
}

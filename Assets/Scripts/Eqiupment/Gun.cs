using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] gunshotParticles;
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private GunData gunData;
    [SerializeField] private Transform muzzle;
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private Image reloadBar;
    [SerializeField] private Image Bar;
    [SerializeField] private AudioSource gunAudioSource;
    public AudioClip shootingAudioClip;

    float timeSinceLastShot;
    public Camera fpsCam;
    public TextMeshProUGUI Text;

    void Start()
    {
        gunData.currentAmmo = gunData.magSize;
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReload;
        Text = FindObjectOfType<TextMeshProUGUI>();
        gunshotParticles = GetComponentsInChildren<ParticleSystem>();
        gunAudioSource = GetComponent<AudioSource>();
        gunAudioSource.clip = shootingAudioClip;
        UpdateUI();
    }

    private void UpdateUI()
    {
        ammoText.text = $"{gunData.currentAmmo}/{gunData.magSize}";
        Bar.gameObject.SetActive(gunData.reloading);
    }

    public void StartReload()
    {
        if (!gunData.reloading && gunData.currentAmmo != gunData.magSize)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        float startTime = Time.time;  // Record the start time of the reload
        gunData.reloading = true;
        UpdateUI();

        while (Time.time - startTime < gunData.reloadTime)
        {
            float progress = Mathf.Clamp01((Time.time - startTime/gunData.reloadTime));
            reloadBar.transform.localScale = new Vector3(progress, 1, 1);
            yield return null;
        }

        gunData.currentAmmo = gunData.magSize;
        gunData.reloading = false;
        UpdateUI();
    }



    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    public void Shoot()
    {
        if (UIManager.Instance.DeathUI.activeSelf)
        {
            return;
        }

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

                gunAudioSource.Play();

                gunData.currentAmmo--;
                timeSinceLastShot = 0;
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
                UpdateUI();
            }
        }
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletVelocity = 20f;
    public float bulletPreFabLifeTime = 3f;
    [SerializeField]
    float fireRate = 2f; // Ateş etme hızı
    private float nextFireTime = 0f; // Bir sonraki ateş zamanı
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetMouseButtonDown(1) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time +  1f / fireRate;
            Meteor();
        }

    }

    private void Meteor()
    {
        for (int i = 0; i < 25; i++) // 5 mermi oluştur
        {
            Vector3 randomOffset = new Vector3(UnityEngine.Random.Range(-8f, 8f), UnityEngine.Random.Range(6f, 12f), UnityEngine.Random.Range(-8f, 8f));
            Instantiate(bulletPrefab, firePoint.position + firePoint.forward * 10f + randomOffset, firePoint.rotation);
        }

    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletVelocity, ForceMode.Impulse);
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPreFabLifeTime));

    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float bulletPreFabLifeTime)
    {
        yield return new WaitForSeconds(bulletPreFabLifeTime);
        Destroy(bullet);
    }
}

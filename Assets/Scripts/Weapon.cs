using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletVelocity = 20f;
    public float bulletPreFabLifeTime = 3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
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

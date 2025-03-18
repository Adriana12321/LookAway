using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMech : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletSpeed;
        }
    }
}

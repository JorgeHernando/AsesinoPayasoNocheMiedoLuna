using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public float firerate;
    public float nextfire;
    public bool canTripleShoot;
    [SerializeField] GameObject prefabBullet;
    [SerializeField] GameObject prefabBulletLeft;
    [SerializeField] GameObject prefabBulletRight;
    [SerializeField] Vector3 posBullet;

    private void Start()
    {
        canTripleShoot = false;
    }

    public void SpawnBullet()
    {
        if( Time.time > firerate && canTripleShoot == false)
        {
            firerate = Time.time + nextfire;
            Debug.Log(nextfire);
            GameObject bulletPrefab = Instantiate(prefabBullet, this.transform.position + posBullet, Quaternion.identity);
            Destroy(bulletPrefab, 5);
            //prefabParticles
        }
        else if (Time.time > firerate && canTripleShoot == true)
        {
            firerate = Time.time + nextfire;
            Debug.Log(nextfire);
            GameObject bulletPrefabLeft = Instantiate(prefabBulletLeft, this.transform.position + posBullet, this.transform.rotation * Quaternion.Euler(0, 0, 33));

            GameObject bulletPrefabMiddle = Instantiate(prefabBulletRight, this.transform.position + posBullet, Quaternion.identity);
            GameObject bulletPrefabRight = Instantiate(prefabBulletLeft, this.transform.position + posBullet, this.transform.rotation * Quaternion.Euler(0, 0, -33));

            Destroy(bulletPrefabLeft, 5);
            Destroy(bulletPrefabMiddle, 5);
            Destroy(bulletPrefabRight, 5);
        }
    }
    public void SpawnPoweredBullet()
    {
        if (Time.time > firerate)
        {
            firerate = Time.time + .2f;
            Debug.Log(nextfire);
            GameObject bulletPrefab = Instantiate(prefabBullet, this.transform.position + posBullet, Quaternion.identity);
            Destroy(bulletPrefab, 5);
        }
        else if (Time.time > firerate && canTripleShoot == true)
        {
            firerate = Time.time + .2f;
            Debug.Log(nextfire);
            GameObject bulletPrefabLeft = Instantiate(prefabBulletLeft, this.transform.position + posBullet, this.transform.rotation * Quaternion.Euler(0, 0, 33));

            GameObject bulletPrefabMiddle = Instantiate(prefabBulletRight, this.transform.position + posBullet, Quaternion.identity);
            GameObject bulletPrefabRight = Instantiate(prefabBulletLeft, this.transform.position + posBullet, this.transform.rotation * Quaternion.Euler(0, 0, -33));

            Destroy(bulletPrefabLeft, 5);
            Destroy(bulletPrefabMiddle, 5);
            Destroy(bulletPrefabRight, 5);
        }
    }
}

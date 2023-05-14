using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] GameObject prefabBullet;
    [SerializeField] Vector3 posBullet;

    public void SpawnBullet()
    {
        if (prefabBullet != null)
        {
            GameObject bulletPrefab = Instantiate(prefabBullet, this.transform.position + posBullet, Quaternion.identity);
            Destroy(bulletPrefab, 5);
            //prefabParticles
        }
    }
}

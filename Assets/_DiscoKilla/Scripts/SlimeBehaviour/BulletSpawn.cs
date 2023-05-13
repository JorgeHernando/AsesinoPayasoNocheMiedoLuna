using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] GameObject prefabBullet;

    public void SpawnBullet()
    {
        if (prefabBullet != null)
        {
            GameObject bulletPrefab = Instantiate(prefabBullet, this.transform.position + new Vector3(0,1,0), Quaternion.identity);
            Destroy(bulletPrefab, 10);
            //prefabParticles
        }
    }
}

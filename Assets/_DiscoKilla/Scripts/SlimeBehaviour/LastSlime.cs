using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSlime : MonoBehaviour
{
    [SerializeField] GameObject prefabParticles;
    private Slime slime;

    void Start()
    {
        slime = GetComponent<Slime>();
    }

    public void Death()
    {
        if (prefabParticles != null)
        {
            GameObject explosionSlime = Instantiate(prefabParticles, this.transform.position , Quaternion.identity);
            Destroy(explosionSlime, .5f);
            slime.DestroyMe();
        }
    }
}

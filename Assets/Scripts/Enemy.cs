using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    [SerializeField] int hitPoints = 4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnParticleCollision(GameObject other)
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}

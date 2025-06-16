using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnParticleCollision(GameObject other)
    {

        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}

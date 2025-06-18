using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject playerExplosionVFX;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Friendly"){return;}
        Instantiate(playerExplosionVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAsteroid : MonoBehaviour
{

    [SerializeField] GameObject explosion;
    [SerializeField] GameObject playerExplosion;

    private void OnTriggerEnter(Collider other)
    {

        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player") Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}

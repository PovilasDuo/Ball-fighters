using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class EffectCollision : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionGameObject;
    [SerializeField]
    private bool spawnOnCollider = false;
    [SerializeField]
    private GameObject shockWaveGameObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 position = transform.position;
        if (collision.gameObject.tag == "Player")
        {
            if (spawnOnCollider) 
            {
                position = collision.transform.position;
                collision.gameObject.GetComponent<Stats>().health++;
            }
            GameObject explosion = Instantiate(explosionGameObject, position, Quaternion.identity);
            Destroy(explosion, 2f);
            GameObject shockwave = Instantiate(shockWaveGameObject, position, Quaternion.identity);
            shockwave.GetComponent<SchoWaveController>().CallShockWave();

            Destroy(this.gameObject);
            collision.gameObject.GetComponent<Stats>().health--;
        }
        if(collision.gameObject.tag == "Shield")
        {
            Instantiate(explosionGameObject, position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.UIElements;

public class EffectCollision : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionGameObject;
    [SerializeField]
    private bool spawnOnCollider = false;

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
            Instantiate(explosionGameObject, position, Quaternion.identity);
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

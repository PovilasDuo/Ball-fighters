using System;
using UnityEngine;

public class EffectCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Console.WriteLine(collision.gameObject);
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}

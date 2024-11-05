using System;
using System.Collections;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private Movement movementScript;
  
    void Start()
    {
        movementScript = GetComponent<Movement>();        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            movementScript.dragging = false;
        }
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    { 
        if (collision.gameObject.name == "Iceball(Clone)")
        {
            StartCoroutine(FreezePlayer());
        }
    }

    IEnumerator FreezePlayer()
    {
        movementScript.enabled = false;
        yield return new WaitForSeconds(2);
        movementScript.enabled = true;
    }
}

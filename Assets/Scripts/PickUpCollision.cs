using System;
using System.Collections;
using UnityEngine;

public class PickUpCollision : MonoBehaviour
{
    public GameObject prefab;
    public float moveSpeed = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollision(collision.gameObject);
    }

    public void HandleCollision(GameObject collider)
    {
        if (collider.CompareTag("Player"))
        {
            GameObject player = collider.gameObject;
            GameObject instantiated = Instantiate(prefab, player.transform.position, Quaternion.identity);
            Vector2 target = Vector2.zero;
            if (collider.gameObject.name == "P1")
            {
                Vector2 playerPosition = GameObject.Find("P2").GetComponent<Transform>().position;
                target = playerPosition;
                instantiated.layer = 10; //P1 layer number is 9; P2 layer number is 10
            }
            else if (collider.gameObject.name == "P2")
            {
                Vector2 playerPosition = GameObject.Find("P1").GetComponent<Transform>().position;
                target = GameObject.Find("P1").GetComponent<Transform>().position;
                instantiated.layer = 9; 
            }
            if (target != Vector2.zero) 
            {
                instantiated.GetComponent<MoveTowardsThePlayer>().isMoving = true;
                instantiated.GetComponent<MoveTowardsThePlayer>().moveSpeed = moveSpeed;
                instantiated.GetComponent<MoveTowardsThePlayer>().target = target;
            }
        }
    }
}

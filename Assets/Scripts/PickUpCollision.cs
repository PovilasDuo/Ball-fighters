using System;
using System.Collections;
using UnityEngine;

public class PickUpCollision : MonoBehaviour
{
    public GameObject prefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollision(collision.gameObject);
    }

    public void HandleCollision(GameObject collider)
    {
        if (collider.CompareTag("Player"))
        {
            GameObject player = collider.gameObject;
            GameObject instantiated = Instantiate(prefab, player.transform.position, prefab.transform.rotation);
            Vector2 target = Vector2.zero;
            Vector2 playerPosition;
            if (collider.gameObject.name == "P1")
            {
                playerPosition = GameObject.Find("P2").GetComponent<Transform>().position;
                target = playerPosition;
                instantiated.layer = 10; //P1 layer number is 9; P2 layer number is 10
            }
            else if (collider.gameObject.name == "P2")
            {
                playerPosition = GameObject.Find("P1").GetComponent<Transform>().position;
                target = GameObject.Find("P1").GetComponent<Transform>().position;
                instantiated.layer = 9; 
            }
            if (this.tag == "Attack")
            {
                if (target != Vector2.zero)
                {
                    instantiated.GetComponent<MoveTowardsThePlayer>().isMoving = true;
                    instantiated.GetComponent<MoveTowardsThePlayer>().target = target;
                }
            }
            else if (this.tag == "Defense")
            {
                prefab.GetComponent<StickToPlayer>().playerGameObject = collider.gameObject;
            }

        }
    }
}

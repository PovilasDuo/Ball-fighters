using System.Collections;
using UnityEngine;

public class PickUpCollision : MonoBehaviour
{
    public GameObject prefab;
    private Material ghostMaterial;
    public float cooldownTime = 5f;
    public float delayShootTime = 3f;

    private void Start()
    {
        ghostMaterial = (Material)Resources.Load("GhostMat");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.CompareTag("Player"))
        {
            GameObject player = collider.gameObject;
            GameObject instantiated = Instantiate(prefab, player.transform.position, prefab.transform.rotation);
            instantiated.layer = 11;

            if (this.tag == "Attack")
            {
                StartCoroutine(DelayMovement(instantiated, player));
            }
            else if (this.tag == "Defense")
            {
                instantiated.GetComponent<StickToPlayer>().playerGameObject = player;
                if (this.name == "Heal")
                {
                    player.GetComponent<Stats>().health++;
                }
            }
            Cooldown();
        }
    }

    private IEnumerator DelayMovement(GameObject instantiated, GameObject player)
    {
        instantiated.gameObject.GetComponent<StickToPlayer>().playerGameObject = player;
        yield return new WaitForSeconds(delayShootTime);
        int layer;
        Vector2 target = CaclulateTargetPosition(player, out layer);
        instantiated.layer = layer;
        instantiated.GetComponent<MoveTowardsThePlayer>().isMoving = true;
        instantiated.GetComponent<MoveTowardsThePlayer>().direction = (target - instantiated.GetComponent<Rigidbody2D>().position).normalized;
    }

    private Vector2 CaclulateTargetPosition(GameObject targetGameObject, out int layer)
    {
        if (targetGameObject.name == "P1")
        {
            layer = 10; //P1 layer number is 9; P2 layer number is 10
            return GameObject.Find("P2").GetComponent<Transform>().position;
        }
        else if (targetGameObject.name == "P2")
        {
            layer = 9;
            return GameObject.Find("P1").GetComponent<Transform>().position;
        }
        layer = 0;
        return Vector2.zero;
    }

    private void Cooldown()
    {
        Material currentMaterial = this.gameObject.GetComponent<SpriteRenderer>().material;
        this.gameObject.GetComponent<SpriteRenderer>().material = ghostMaterial;
        StartCoroutine(ReturnDefaultMaterial(currentMaterial));
    }

    private IEnumerator ReturnDefaultMaterial(Material currentMaterial)
    {
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(cooldownTime);
        this.gameObject.GetComponent<SpriteRenderer>().material = currentMaterial;
        this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }
}

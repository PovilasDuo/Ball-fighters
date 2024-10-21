using System;
using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveTowardsThePlayer : MonoBehaviour
{
    public bool isMoving = false;
    public Vector2 target;
    public float moveSpeed = 5;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //Destroy(this.gameObject, 2.5f);
    }

    private void FixedUpdate()
    {
        if (isMoving && target != null)
        {
            StartCoroutine(DelaySpawn());
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        Vector2 newPosition = Vector2.MoveTowards(rb2d.position, target, moveSpeed * Time.fixedDeltaTime);
        Vector2 direction = target - rb2d.position;
        rb2d.MovePosition(newPosition);

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg * 2;
        rb2d.rotation = targetAngle;

        if (Vector2.Distance(rb2d.position, target) < 0.1f)
        {
            isMoving = false;
            //Destroy(this.gameObject);
        }
    }

    IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(1.5f);
    }
}

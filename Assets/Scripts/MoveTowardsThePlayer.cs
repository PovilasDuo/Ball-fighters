using System.Collections;
using UnityEngine;

public class MoveTowardsThePlayer : MonoBehaviour
{
    public bool isMoving = false;
    public float moveSpeed = 5;

    private Rigidbody2D rb2d;

    private bool positionCalculated = false;
    public Vector2 direction;

    private void Start()
    {
        //Destroy(this.gameObject, 4f);
        rb2d = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        if (isMoving && direction != null)
        {
            StartCoroutine(DelaySpawn());
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        Vector2 newPosition = rb2d.position + direction * moveSpeed * Time.fixedDeltaTime;
        rb2d.MovePosition(newPosition);

        if (!positionCalculated) 
        {
            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (this.gameObject.transform.position.y > 0) rb2d.rotation = 180 - targetAngle * -2;
            else rb2d.rotation = targetAngle * 2;
            positionCalculated = true;
        }
    }

    IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(1.5f);
    }
}

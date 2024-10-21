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
        if(collision.gameObject.tag == "Wall")
        {
            movementScript.dragging = false;
        }
    }
}

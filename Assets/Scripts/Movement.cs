using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class Movement : MonoBehaviour
{
    private Vector3 offset;
    public bool dragging = false;
    private int touchId = -1;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (UnityEngine.Touch touch in Input.touches)
            {
                Vector3 touchPosition = TouchPositino(touch);
                if (touch.phase == TouchPhase.Began)
                {
                    RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);
                    if (hit.collider != null && hit.collider.gameObject == this.gameObject)
                    {
                        dragging = true;
                        touchId = touch.fingerId;
                        offset = this.transform.position - touchPosition;
                    }
                }
                if (touch.phase == TouchPhase.Moved && dragging && touch.fingerId == touchId)
                {
                    this.transform.position = touchPosition + offset;
                }

                if ((touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) && touch.fingerId == touchId)
                {
                    if (dragging && touch.fingerId == touchId)
                    {
                        dragging = false;
                        touchId = -1;
                    }
                }
            }
        }
    }

    private Vector3 TouchPositino(UnityEngine.Touch touch)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(touch.position);
        position.z = 0;
        return position;
    }
}

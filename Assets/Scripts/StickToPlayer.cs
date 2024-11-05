using System.Collections;
using UnityEngine;

public class StickToPlayer : MonoBehaviour
{
    public GameObject playerGameObject;
    public float stickTime = 3f;

    void Start()
    {
        Destroy(this.gameObject, stickTime + 1);
        StartCoroutine(StickToPlayerForFewSeconds());
    }

    IEnumerator StickToPlayerForFewSeconds()
    {
        float timer = stickTime;
        while (timer > 0)
        {
            transform.position = playerGameObject.transform.position;
            timer -= Time.deltaTime;
            yield return null;
        }
    }
}

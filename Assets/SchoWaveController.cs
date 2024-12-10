using System.Collections;
using UnityEngine;

public class SchoWaveController : MonoBehaviour
{
    [SerializeField]
    private float shockwaveTime = 1f;
    private Material shockwaveMaterial;
    private static int waveDistanceFromCenter = Shader.PropertyToID("_WaveDistance");

    private void Awake()
    {
        shockwaveMaterial = GetComponent<SpriteRenderer>().material;
    }

    public void CallShockWave()
    {
        StartCoroutine(ShockWaveAction(-0.1f, 1f));
    }

    private IEnumerator ShockWaveAction(float startPosition, float endPosition)
    {
        shockwaveMaterial.SetFloat(waveDistanceFromCenter, startPosition);
        float lerpedAmount = 0f;
        float elapsedTime = 0f;
        while (elapsedTime < shockwaveTime)
        {
            elapsedTime += Time.deltaTime;
            lerpedAmount = Mathf.Lerp(startPosition, endPosition, elapsedTime / shockwaveTime);
            shockwaveMaterial.SetFloat(waveDistanceFromCenter, lerpedAmount);
            yield return null;
        }
        Destroy(gameObject, 3f);
    }
}

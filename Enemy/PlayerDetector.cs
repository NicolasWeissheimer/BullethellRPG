using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public bool detectedPlayer;
    public bool detectedEnemy;
    public float delay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopCoroutine(DetectPlayer(true));
            StartCoroutine(DetectPlayer(true));
        }

        if (collision.CompareTag("Enemy"))
        {
            StopCoroutine(DetectEnemy(true));
            StartCoroutine(DetectEnemy(true));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopCoroutine(DetectPlayer(false));
            StartCoroutine(DetectPlayer(false));
        }

        if (collision.CompareTag("Enemy"))
        {
            StopCoroutine(DetectEnemy(false));
            StartCoroutine(DetectEnemy(false));
        }
    }

    IEnumerator DetectPlayer(bool _detected)
    {
        float i = Random.Range(0, delay);
        yield return new WaitForSeconds(i);
        detectedPlayer = _detected;
    }

    IEnumerator DetectEnemy(bool _detected)
    {
        float i = Random.Range(0, delay);
        yield return new WaitForSeconds(i);
        detectedEnemy = _detected;
    }
}

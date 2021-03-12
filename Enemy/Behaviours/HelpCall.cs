using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpCall : MonoBehaviour
{
    public GameObject caller;
    public float lifeTime;
    public CircleCollider2D radius;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}

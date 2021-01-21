using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerCollider();
    }

    private void AddNonTriggerCollider()
    {
        Collider nonTriggerCollider = gameObject.AddComponent<BoxCollider>();
        nonTriggerCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
    }
}

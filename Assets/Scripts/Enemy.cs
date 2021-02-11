using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int hitPoints = 10;

    ScoreBoard scoreBoard;
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
        GameObject newDeathFX = Instantiate(deathFX, transform.position, Quaternion.identity);
        newDeathFX.transform.parent = parent;
        Destroy(gameObject);
        scoreBoard.ScoreHit(hitPoints);
    }
}

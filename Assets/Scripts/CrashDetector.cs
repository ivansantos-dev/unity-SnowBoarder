using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    CircleCollider2D head;

    void Start() {
        head = GetComponent<CircleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.collider.tag == "Ground" && head.IsTouching(other.collider))
        {
            Debug.Log("Hit head");
        }
    }
}

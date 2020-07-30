using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        Destroy(gameObject);
    }

    public void Initialize(Vector3 _direction, float speed)
    {
        transform.forward = _direction;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = _direction * speed;
    }
}

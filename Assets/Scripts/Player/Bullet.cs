using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    
    void Update()
    {
        rb.velocity = transform.TransformDirection(Vector3.forward * (speed * Time.deltaTime));
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}

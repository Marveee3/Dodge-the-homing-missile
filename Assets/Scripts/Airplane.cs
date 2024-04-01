using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float rotateSpeed = 250;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector2 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePos);
        
        Vector2 direction = mousePosWorld - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;
    }

}

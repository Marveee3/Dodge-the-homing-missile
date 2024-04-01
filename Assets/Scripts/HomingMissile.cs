using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{
    [SerializeField]private Transform target;
    [SerializeField]private float speed = 5;
    [SerializeField]private float rotateSpeed = 250;
    [SerializeField]private GameObject explosionEffect;
    private Rigidbody2D rb;

    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        if(target == null)target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {   
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;

        // Ограничиваем минимальное значение позиции по оси Z
        if (transform.position.z < -9)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -9);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
	{   
        if(col.tag == "Player")//checking for a collision with another pin
        {   
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
		    Destroy(gameObject);
            FindObjectOfType<GameManager>().EndGame();
        }
        else
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
		    Destroy(gameObject);
        }
	}

}

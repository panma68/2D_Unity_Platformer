using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingObject : MonoBehaviour
{
    [SerializeField] private Transform posA, posB;
    [SerializeField] private float speed;
    Vector3 targetPos;

    player_Movement playerMovement;
    Rigidbody2D rb;
    Vector3 moveDirection;
    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<player_Movement>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        targetPos = posB.position;
        DirectionalCalculate();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < 0.2f)
        {
            targetPos = posB.position;
            DirectionalCalculate();
        }
        if (Vector2.Distance(transform.position, posB.position) < 0.2f)
        {
            targetPos = posA.position;
            DirectionalCalculate();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * speed;
    }

    void DirectionalCalculate()
    {
        moveDirection = (targetPos - transform.position).normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerMovement.isOnPlatform = true;
            playerMovement.platformRb = rb;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerMovement.isOnPlatform = false;
        }
    }

}

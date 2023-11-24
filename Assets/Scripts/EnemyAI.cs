using UnityEngine;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float decisionDelay = 2.0f;
    private Vector3 moveDirection;
    private float timer;

    void Start()
    {
        ChooseNewDirection();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > decisionDelay)
        {
            ChooseNewDirection();
            timer = 0;
        }
    }

    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    void ChooseNewDirection()
    {
        List<Vector3> possibleDirections = new List<Vector3>
        {
            Vector3.forward,
            Vector3.back,
            Vector3.left,
            Vector3.right
        };

        moveDirection = possibleDirections[Random.Range(0, possibleDirections.Count)];
        transform.LookAt(transform.position + moveDirection); // Az ellens�g n�zzen az �j ir�nyba
    }

    void OnCollisionEnter(Collision collision)
    {
        // Ha falnak �tk�zik, v�lasszon �j ir�nyt
        if (collision.gameObject.CompareTag("Wall"))
        {
            ChooseNewDirection();
        }
    }
}

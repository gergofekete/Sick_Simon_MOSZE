using UnityEngine;
using System.Collections.Generic;


public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float decisionDelay = 1.0f;
    public float raycastDistance = 2.0f;

    private Vector3 moveDirection;
    private float timer;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ChooseNewDirection();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > decisionDelay)
        {
            timer = 0;
            if (IsPathBlocked())
            {
                ChooseNewDirection();
            }
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveDirection * moveSpeed;
    }

    bool IsPathBlocked()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, moveDirection, out hit, raycastDistance))
        {
            return hit.collider.CompareTag("Wall");
        }
        return false;
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

        int randomIndex = Random.Range(0, possibleDirections.Count);
        moveDirection = possibleDirections[randomIndex];

        if (IsPathBlocked())
        {
            // Ha az elsõ választott irány blokkolva van, próbáljunk meg egy másikat választani
            randomIndex = (randomIndex + Random.Range(1, possibleDirections.Count)) % possibleDirections.Count;
            moveDirection = possibleDirections[randomIndex];
        }

        transform.LookAt(transform.position + moveDirection);
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            ChooseNewDirection();
        }
    }
}

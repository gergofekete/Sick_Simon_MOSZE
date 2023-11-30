using UnityEngine;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float decisionDelay = 2.0f;
    public float raycastDistance = 2.0f;
    private Vector3 moveDirection;
    private float timer;

    void Start()
    {
        ChooseNewDirection();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > decisionDelay || IsPathBlocked())
        {
            ChooseNewDirection();
            timer = 0;
        }
    }

    void FixedUpdate()
    {
        transform.Translate(moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    bool IsPathBlocked()
    {
        RaycastHit hit;
        // Raycast elõre az ellenség mozgási irányában
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

        do
        {
            moveDirection = possibleDirections[Random.Range(0, possibleDirections.Count)];
        } while (IsPathBlocked());

        transform.LookAt(transform.position + moveDirection); // Az ellenség nézzen az új irányba
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            ChooseNewDirection();
        }
    }
}

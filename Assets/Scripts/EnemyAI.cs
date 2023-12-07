using UnityEngine;
using System.Collections.Generic;


public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float decisionDelay = 1.0f;
    public float raycastDistance = 2.0f;



    public Transform spawnPoint;

    private Vector3 moveDirection;
    private float timer;

    private Rigidbody rb;

    private int layerMask;

    void Awake()
    {
        // Így hívjuk meg a NameToLayer-t az Awake metódusban
        layerMask = 1 << LayerMask.NameToLayer("Wall");
    }

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

        Vector3 raycastOrigin = transform.position + new Vector3(0, 0.1f, 0);
        RaycastHit hit;

        if (Physics.Raycast(raycastOrigin, moveDirection, out hit, raycastDistance, layerMask))

        {
            // Ha találtunk ütközést, módosítsuk az irányt
            Vector3 newDirection = Vector3.Reflect(moveDirection, hit.normal);
            moveDirection = newDirection.normalized;

            // Most már lehet, hogy újra kell nézni az új irányba
            transform.LookAt(transform.position + moveDirection);
        }
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
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.IncreaseEnemyMeet();
                RespawnEnemy();
            }
        }
    }

    void RespawnEnemy()
    {

        // Spawn a new enemy at a random position
        Vector3 randomPosition = new Vector3(Random.Range(-5.5f, 4.5f), 0.3f, Random.Range(-5.5f, 4.5f));

        // Instantiate the new enemy
        transform.position = randomPosition;

    }


}

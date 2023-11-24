using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float sebesseg = 1.5f;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal != 0)
        {
            MoveCharacter(moveHorizontal, 0); // Move left or right
        }
        else if (moveVertical != 0)
        {
            MoveCharacter(0, moveVertical); // Move up or down
        }
    }

    void MoveCharacter(float x, float y)
    {
        Vector3 movement = new Vector3(x, 0.0f, y);
        transform.Translate(movement * sebesseg * Time.deltaTime);
    }
}
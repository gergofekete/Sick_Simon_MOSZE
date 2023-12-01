using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float sebesseg = 1.5f;
    private int felvettItemekSzama = 0; // Sz�ml�l� az felvett itemek sz�m�hoz
    private int itemCount = 0; // Sz�ml�l� az itemek sz�m�ra

    public void PickUpItem(GameObject item)
    {
        // Itt �rd meg, mit kell tenni, amikor a j�t�kos felvette az itemet
        Debug.Log("Item felv�ve: " + item.name);

        // N�veld a felvett itemek sz�m�t
        felvettItemekSzama++;
        Debug.Log("Felvett itemek sz�ma: " + felvettItemekSzama);
    }
    public void IncreaseItemCount()
    {
        itemCount++;
        Debug.Log("Itemek sz�ma: " + itemCount);
    }
    public int GetPickedUpItemCount()
    {
        return felvettItemekSzama;
    }

    public int GetTotalItemCount()
    {
        return itemCount;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Csak v�zszintesen vagy f�gg�legesen mozoghat
        if (Mathf.Abs(moveHorizontal) > Mathf.Abs(moveVertical))
        {
            movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        }
        else
        {
            movement = new Vector3(0.0f, 0.0f, moveVertical);
        }

        transform.Translate(movement * sebesseg * Time.deltaTime);
    }

}

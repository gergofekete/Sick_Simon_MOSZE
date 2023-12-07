using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float sebesseg = 2.5f;
    private int felvettItemekSzama = 0; 
    private int itemCount = 0;
    public int eletero = 4;



    public void PickUpItem(GameObject item)
    {
        Debug.Log("Item felvéve: " + item.name);
        felvettItemekSzama++;
        Debug.Log("Felvett itemek száma: " + felvettItemekSzama);

        // Egészség növelése, ha szükséges
      //GameManager.Instance.heartScript.Heal();
    }

    public void IncreaseEnemyMeet()
    {
        eletero--;
        Debug.Log("Életerõ: " + eletero);
    }
    public void IncreaseItemCount()
    {
        itemCount++;
        Debug.Log("Itemek száma: " + itemCount);
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

        // Csak vízszintesen vagy függõlegesen mozoghat
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

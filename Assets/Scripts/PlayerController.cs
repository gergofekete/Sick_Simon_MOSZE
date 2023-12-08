using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float sebesseg = 2.5f;
    private int felvettItemekSzama = 0; 
    public int itemCount = 0;
    public int eletero = 4;




    public void PickUpItem(GameObject item)
    {
        Debug.Log("Item felv�ve: " + item.name);
        felvettItemekSzama++;
        Debug.Log("Felvett itemek sz�ma: " + felvettItemekSzama);

        // Eg�szs�g n�vel�se, ha sz�ks�ges
      //GameManager.Instance.heartScript.Heal();
    }

    public void IncreaseEnemyMeet()
    {
        eletero--;
        Debug.Log("�leter�: " + eletero);
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

    void CheckHealth()
    {
        // Ellen�rizd, hogy az �leter� el�rte-e a null�t
        if (eletero <= 0)
        {
            // Ha igen, hozd be a j�t�k v�ge jelenetet
            SceneManager.LoadScene("GameEndScene");
        }
    }

}

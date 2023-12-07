using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{

    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Heart4;

    private PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        int health = playerController != null ? playerController.eletero : 0;


        switch (health)
        {
            case 0:
                {
                    Heart1.gameObject.SetActive(false);
                    Heart2.gameObject.SetActive(false);
                    Heart3.gameObject.SetActive(false);
                    Heart4.gameObject.SetActive(false);
                    break;
                }
            case 1:
                {
                    Heart1.gameObject.SetActive(true);
                    Heart2.gameObject.SetActive(false);
                    Heart3.gameObject.SetActive(false);
                    Heart4.gameObject.SetActive(false);
                    break;
                }
            case 2:
                {
                    Heart1.gameObject.SetActive(true);
                    Heart2.gameObject.SetActive(true);
                    Heart3.gameObject.SetActive(false);
                    Heart4.gameObject.SetActive(false);
                    break;
                }
            case 3:
                {
                    Heart1.gameObject.SetActive(true);
                    Heart2.gameObject.SetActive(true);
                    Heart3.gameObject.SetActive(true);
                    Heart4.gameObject.SetActive(false);
                    break;
                }
            case 4:
                {
                    Heart1.gameObject.SetActive(true);
                    Heart2.gameObject.SetActive(true);
                    Heart3.gameObject.SetActive(true);
                    Heart4.gameObject.SetActive(true);
                    break;
                }
        }
        
    }
}

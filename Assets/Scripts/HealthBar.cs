using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image FillImage;
    private PlayerController playerController;
    public float fillSpeed = 2f; // A health bar növekedési sebessége

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        float currentHealth = playerController.itemCount;
        float targetHealth = currentHealth / 6f; // Százalékra alakítjuk a currentHealth-et

        // Használjuk a Mathf.Lerp-et a smooth növekedéshez
        FillImage.fillAmount = Mathf.Lerp(FillImage.fillAmount, targetHealth, Time.deltaTime * fillSpeed);
    }
}


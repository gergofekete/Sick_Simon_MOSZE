using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image FillImage;
    private PlayerController playerController;
    public float fillSpeed = 2f; // A health bar n�veked�si sebess�ge

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        float currentHealth = playerController.itemCount;
        float targetHealth = currentHealth / 6f; // Sz�zal�kra alak�tjuk a currentHealth-et

        // Haszn�ljuk a Mathf.Lerp-et a smooth n�veked�shez
        FillImage.fillAmount = Mathf.Lerp(FillImage.fillAmount, targetHealth, Time.deltaTime * fillSpeed);
    }
}


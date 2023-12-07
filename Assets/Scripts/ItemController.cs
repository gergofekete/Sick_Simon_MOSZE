using UnityEngine;

public class ItemController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.PickUpItem(gameObject);
                playerController.IncreaseItemCount();

                Destroy(gameObject);
            }
        }
    }
}

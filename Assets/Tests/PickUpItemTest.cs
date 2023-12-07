using NUnit.Framework;
using UnityEngine;

public class PickUpItemTest
{
    private GameObject playerGameObject;
    private PlayerController playerController;
    private GameObject itemGameObject;
    private ItemController itemController;

    [SetUp]
    public void Setup()
    {
        
        playerGameObject = new GameObject();
        playerController = playerGameObject.AddComponent<PlayerController>();

        
        itemGameObject = new GameObject();
        itemController = itemGameObject.AddComponent<ItemController>();
    }

    [Test]
    public void PlayerController_IncrementsItemCount_WhenPickingUpItem()
    {
       
        playerController.PickUpItem(itemGameObject);
        playerController.IncreaseItemCount();

        
        Assert.AreEqual(1, playerController.GetPickedUpItemCount());
        Assert.AreEqual(1, playerController.GetTotalItemCount());
    }

   
}

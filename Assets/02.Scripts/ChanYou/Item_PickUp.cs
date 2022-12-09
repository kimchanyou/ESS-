using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_PickUp : MonoBehaviour
{
    public int itemID;
    public int _count;
    public string pickUpSound;

    private void OnTriggerStay(Collider collision)
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SoundManager.instance.Play(pickUpSound);
            InventoryUI.instance.GetAnItem(itemID, _count); //인벤토리 추가
            Destroy(this.gameObject);
        }
    }
}

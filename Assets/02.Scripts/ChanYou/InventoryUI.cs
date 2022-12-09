using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;

    private ItemData itemData;
    private List<Item_Info> inventoryItemList; //플레이어가 소지한 아이템 리스트

    public GameObject invenGO; // 인벤토리 오브젝트
    public GameObject equipGO; // 장비창 오브젝트
    public Image selectImg; //아이템 선택했을때 표시 되도록

    public Text okText;
    public Text ccText;

    public bool activInven; //인벤토리가 켜지면 true
    public bool activEquip; //장비창이 켜지면 true

    void Start()
    {
        itemData = FindObjectOfType<ItemData>();
        inventoryItemList = new List<Item_Info>();
    }


    void Update()
    {
        ShowInven();
        ShowEquip();
    }
    public void GetAnItem(int _itemID, int _count = 1)
    {
        for (int i = 0; i < itemData.itemList.Count; i++)
        {
            if (_itemID == itemData.itemList[i].itemID)
            {
                for (int j = 0; j < inventoryItemList.Count; j++) //소지품에 같은 아이템이 있는지 검색
                {
                    if (inventoryItemList[j].itemID == _itemID) //소지품에 같은 아이템이 있다 -> 갯수만 증감시켜줌
                    {
                        if (inventoryItemList[j].item_type == Item_Info.ItemType.Consume)
                        {
                            inventoryItemList[j].itemCount += _count;
                        }
                        else
                        {
                            inventoryItemList.Add(itemData.itemList[i]);
                        }
                        return;
                    }
                }
                inventoryItemList.Add(itemData.itemList[i]); //소지품에 해당 아이템 추가
                inventoryItemList[inventoryItemList.Count - 1].itemCount = _count;
                return;
            }
        }
    }

    void ShowInven()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activInven = !activInven;
            if (activInven)
            {
                invenGO.SetActive(true);
                //SeletedItem();
            }
            else
            {
                invenGO.SetActive(false);
            }
        }
    }
    void ShowEquip()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            activEquip = !activEquip;
            if (activEquip)
            {
                equipGO.SetActive(true);
            }
            else
            {
                equipGO.SetActive(false);
            }
        }
    }

    void SeletedItem() //아이템을 클릭했을 때 테두리에 선택되었다는 표시
    {
        selectImg.transform.position = Drag.instance.itemTr.position;
        Color color = selectImg.color;
        color.a = 1f;
    }
}

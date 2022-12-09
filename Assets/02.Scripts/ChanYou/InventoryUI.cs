using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;

    private ItemData itemData;
    private List<Item_Info> inventoryItemList; //�÷��̾ ������ ������ ����Ʈ

    public GameObject invenGO; // �κ��丮 ������Ʈ
    public GameObject equipGO; // ���â ������Ʈ
    public Image selectImg; //������ ���������� ǥ�� �ǵ���

    public Text okText;
    public Text ccText;

    public bool activInven; //�κ��丮�� ������ true
    public bool activEquip; //���â�� ������ true

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
                for (int j = 0; j < inventoryItemList.Count; j++) //����ǰ�� ���� �������� �ִ��� �˻�
                {
                    if (inventoryItemList[j].itemID == _itemID) //����ǰ�� ���� �������� �ִ� -> ������ ����������
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
                inventoryItemList.Add(itemData.itemList[i]); //����ǰ�� �ش� ������ �߰�
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

    void SeletedItem() //�������� Ŭ������ �� �׵θ��� ���õǾ��ٴ� ǥ��
    {
        selectImg.transform.position = Drag.instance.itemTr.position;
        Color color = selectImg.color;
        color.a = 1f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Item_Info
{
    public int itemID; //�������� ���� ID��. �ߺ� �Ұ�
    public string itemName; //�������� �̸�. �ߺ� ����
    public string itemDescription; //������ ����
    public int itemCount; //���� ����
    public Sprite itemIcon; //�������� ������.
    public ItemType item_type;
    public enum ItemType
    {
        Consume,
        Equip,
        Quest,
        ETC
    }
    public Item_Info(int _itemID, string _itemName, string _itemDes, ItemType _itemType, int _itemCount = 1)
    {
        itemID = _itemID;
        itemName = _itemName;
        itemDescription = _itemDes;
        item_type = _itemType;
        itemCount = _itemCount;
        itemIcon = Resources.Load("ItemImage/" + _itemID.ToString(), typeof(Sprite)) as Sprite;
    }
}

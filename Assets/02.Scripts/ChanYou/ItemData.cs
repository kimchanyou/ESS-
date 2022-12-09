using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public static ItemData instance;
    private PlayerStat thePlayerStat;
    public GameObject prefabs_Floating_Text;
    public GameObject parent;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }
    public string[] var_name;
    public float[] var;

    public string[] switch_name;
    public bool[] switches;

    public List<Item_Info> itemList = new List<Item_Info>();
    private void FloatingText(int number, string color)
    {
        Vector3 vector = thePlayerStat.transform.position;
        vector.y += 60;

        GameObject clone = Instantiate(prefabs_Floating_Text, vector, Quaternion.Euler(Vector3.zero));
        clone.GetComponent<FloatingText>().text.text = number.ToString();
        if (color == "GREEN")
            clone.GetComponent<FloatingText>().text.color = Color.green;
        else if (color == "BLUE")
            clone.GetComponent<FloatingText>().text.color = Color.blue;
        clone.GetComponent<FloatingText>().text.fontSize = 25;
        clone.transform.SetParent(parent.transform);
    }
    public void UseItem(int _itemID)
    {
        switch (_itemID)
        {
            case 10001:
                if (thePlayerStat.hp >= thePlayerStat.currentHP + 50)
                    thePlayerStat.currentHP += 50;
                else
                    thePlayerStat.currentHP = thePlayerStat.hp;
                FloatingText(50, "GREEN");
                break;
            case 10002:
                if (thePlayerStat.mp >= thePlayerStat.currentMP + 50)
                    thePlayerStat.currentMP += 15;
                else
                    thePlayerStat.currentMP = thePlayerStat.mp;
                FloatingText(50, "BLUE");
                break;
        }
    }
    void Start()
    {
        thePlayerStat = FindObjectOfType<PlayerStat>();
        itemList.Add(new Item_Info(111, "���� ����", "ü���� 50 ȸ�������ִ� ������ ����", Item_Info.ItemType.Consume));
        itemList.Add(new Item_Info(121, "�Ķ� ����", "������ 15 ȸ�������ִ� ������ ����", Item_Info.ItemType.Consume));
        itemList.Add(new Item_Info(112, "���� ���� ����", "ü���� 350 ȸ�������ִ� ������ ���� ����", Item_Info.ItemType.Consume));
        itemList.Add(new Item_Info(122, "���� �Ķ� ����", "������ 80 ȸ�������ִ� ������ ���� ����", Item_Info.ItemType.Consume));
        itemList.Add(new Item_Info(411, "���� ����", "�������� ������ ���´�. ���� Ȯ���� ��", Item_Info.ItemType.Consume));
        itemList.Add(new Item_Info(211, "ª�� ��", "�⺻���� ����� ��", Item_Info.ItemType.Equip));
        itemList.Add(new Item_Info(251, "�����̾� ����", "1�п� �̴� 1�� ȸ�������ִ� ���� ����", Item_Info.ItemType.Equip));
        itemList.Add(new Item_Info(311, "��� ������ ����1", "������ �ɰ��� ��� ������ ����", Item_Info.ItemType.Quest));
        itemList.Add(new Item_Info(312, "��� ������ ����2", "������ �ɰ��� ��� ������ ����", Item_Info.ItemType.Quest));
        itemList.Add(new Item_Info(313, "��� ����", "��� ������ �����ִ� ����� ����", Item_Info.ItemType.Quest));
    }
    /*
    ������ ������ȣ 
    ù��° �ڸ� : ������ Ÿ��, �ι�° �ڸ� : �ش� Ÿ�� ����ȭ, ����° �ڸ� : ���(���ڰ� �������� ����)
    ���� : 1, ��� : 2, ����Ʈ : 3, ��Ÿ : 4
    ü������ 11 �������� 12
    ���� 21, ���� 22, ���� 23, �Ź� 24, �Ǽ��縮 25

    */
}

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
        itemList.Add(new Item_Info(111, "빨간 포션", "체력을 50 회복시켜주는 기적의 물약", Item_Info.ItemType.Consume));
        itemList.Add(new Item_Info(121, "파란 포션", "마나를 15 회복시켜주는 기적의 물약", Item_Info.ItemType.Consume));
        itemList.Add(new Item_Info(112, "농축 빨간 포션", "체력을 350 회복시켜주는 기적의 농축 물약", Item_Info.ItemType.Consume));
        itemList.Add(new Item_Info(122, "농축 파란 포션", "마나를 80 회복시켜주는 기적의 농축 물약", Item_Info.ItemType.Consume));
        itemList.Add(new Item_Info(411, "랜덤 상자", "랜덤으로 포션이 나온다. 낮은 확률로 꽝", Item_Info.ItemType.Consume));
        itemList.Add(new Item_Info(211, "짧은 검", "기본적인 용사의 검", Item_Info.ItemType.Equip));
        itemList.Add(new Item_Info(251, "사파이어 반지", "1분에 미니 1을 회복시켜주는 마법 반지", Item_Info.ItemType.Equip));
        itemList.Add(new Item_Info(311, "고대 유물의 조각1", "반으로 쪼개진 고대 유물의 파편", Item_Info.ItemType.Quest));
        itemList.Add(new Item_Info(312, "고대 유물의 조각2", "반으로 쪼개진 고대 유물의 파편", Item_Info.ItemType.Quest));
        itemList.Add(new Item_Info(313, "고대 유물", "고대 유적에 잠들어있던 고대의 유물", Item_Info.ItemType.Quest));
    }
    /*
    아이템 고유번호 
    첫번째 자리 : 아이템 타입, 두번째 자리 : 해당 타입 세분화, 세번째 자리 : 등급(숫자가 높을수록 좋음)
    포션 : 1, 장비 : 2, 퀘스트 : 3, 기타 : 4
    체력포션 11 마나포션 12
    무기 21, 투구 22, 갑옷 23, 신발 24, 악세사리 25

    */
}

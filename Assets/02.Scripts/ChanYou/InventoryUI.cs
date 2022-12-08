using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject invenGO; // 인벤토리 오브젝트
    public GameObject equipGO; // 장비창 오브젝트
    public Image selectImg; //아이템 선택했을때 표시 되도록

    public Text okText;
    public Text ccText;

    public bool activInven; //인벤토리가 켜지면 true
    public bool activEquip; //장비창이 켜지면 true

    void Start()
    {
        
    }

    
    void Update()
    {
        ShowInven();
        ShowEquip();
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

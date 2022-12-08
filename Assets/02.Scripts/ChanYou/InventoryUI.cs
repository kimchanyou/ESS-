using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject invenGO; // �κ��丮 ������Ʈ
    public GameObject equipGO; // ���â ������Ʈ
    public Image selectImg; //������ ���������� ǥ�� �ǵ���

    public Text okText;
    public Text ccText;

    public bool activInven; //�κ��丮�� ������ true
    public bool activEquip; //���â�� ������ true

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

    void SeletedItem() //�������� Ŭ������ �� �׵θ��� ���õǾ��ٴ� ǥ��
    {
        selectImg.transform.position = Drag.instance.itemTr.position;
        Color color = selectImg.color;
        color.a = 1f;
    }
}

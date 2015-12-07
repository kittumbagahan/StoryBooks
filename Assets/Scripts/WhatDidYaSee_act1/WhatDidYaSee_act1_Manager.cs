using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WhatDidYaSee_act1_Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InventoryManager.ins.eDragDir = EDragDirection.x;
        for(int i=0; i<InventoryManager.ins.items.Count; i++)
        {
            Item itm = InventoryManager.ins.items[i].GetComponent<Item>();
            itm.delegateDrop += Check;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Check()
    {
        int cnt = 0;
        if(InventoryManager.ins.slots[0].transform.GetChild(0).GetComponent<Image>().sprite.name.Contains("0"))
        {
            cnt++;
        }
        if (InventoryManager.ins.slots[1].transform.GetChild(0).GetComponent<Image>().sprite.name.Contains("1"))
        {
            cnt++;
        }
        if (InventoryManager.ins.slots[2].transform.GetChild(0).GetComponent<Image>().sprite.name.Contains("2"))
        {
            cnt++;
        }
        if (InventoryManager.ins.slots[3].transform.GetChild(0).GetComponent<Image>().sprite.name.Contains("3"))
        {
            cnt++;
        }
        if (InventoryManager.ins.slots[4].transform.GetChild(0).GetComponent<Image>().sprite.name.Contains("4"))
        {
            cnt++;
        }
        if(cnt == 5)
        {
            print("WIN!");
        }
    }

   
}

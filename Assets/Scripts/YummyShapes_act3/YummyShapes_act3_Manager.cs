using UnityEngine;
using System.Collections;

public class YummyShapes_act3_Manager : MatchingManager {


    int pts = 0;

	void Start () {
        SetLen = 4;
        //GameOn();
        StartCoroutine(IENext());
	}

    public void GameOn()
    {
       
        if (Index < objItem.Length-1)
        {
           
            SpawnSet();
            for (int i = 0; i < InventoryManager.ins.items.Count; i++)
            {
                Item itm = InventoryManager.ins.items[i].GetComponent<Item>();
                itm.delegateDrop += IncPts;
            }
        }

       
    }

    void IncPts()
    {
        pts++;
        if(pts >= MaxPts)
        {
            print("WIN!");
           
            StartCoroutine(IENext());
        }
    }

    IEnumerator IENext()
    {
        yield return new WaitForSeconds(0.1f);
        DestroyItems();
        EmptySlots();
        pts = 0;
       
        yield return new WaitForSeconds(0.1f);
        GameOn();
        yield return new WaitForSeconds(0.1f);
        ShuffleItems();
    }
}

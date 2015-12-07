using UnityEngine;
using System.Collections;

public class ColorsMixedUpMatchingManager : MonoBehaviour {

    int point = 0;
   

	void Start () {
        Item itm = null;       
        for(int i=0; i<InventoryManager.ins.items.Count; i++)
        {
            itm = InventoryManager.ins.items[i].GetComponent<Item>();
            itm.delegateDrop += IncPoints;
        }
	}

    void IncPoints() {
        point++;
        //print(point);
        if (point == 4)
        {
            GameOver();
        }
    }

    void GameOver() {
        print("Game over");
    }
}

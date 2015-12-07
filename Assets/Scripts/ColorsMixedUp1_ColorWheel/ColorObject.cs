using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorObject : MonoBehaviour {

    public delegate void DelInsert();
    public DelInsert OnInserted;
   
    Item itm;
    void Start () {
        //container = transform.parent;
        itm = GetComponent<Item>();
        itm.delegateDrop += Drop;
        //OnInserted += ColorWheelManager.ins.IncPoints;
	}

    void Drop()
    {
        Slot s = null;
        Image img = null;
        img = transform.parent.parent.GetComponent<Image>();
        s = GetComponentInParent<Slot>();
        if (itm.eColor == s.eColor)
        {
            print("WOW");
            gameObject.SetActive(false);
            img.enabled = false;
            if(OnInserted != null)
            {
                OnInserted();
                //OnInserted -= ColorWheelManager.ins.IncPoints;
            }
            //ColorWheelManager.ins.Point++;
        }
    }
  
}

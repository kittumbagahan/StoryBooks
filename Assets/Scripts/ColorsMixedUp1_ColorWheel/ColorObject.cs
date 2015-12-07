using UnityEngine;
using System.Collections;

public class ColorObject : MonoBehaviour {

    //public EColor ecolor = new EColor();
    //Transform container;
    Item itm;
    void Start () {
        //container = transform.parent;
        itm = GetComponent<Item>();
        itm.delegateDrop += Drop;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void Drop()
    {
        Slot s = null;
        s = GetComponentInParent<Slot>();
        if (itm.eColor == s.eColor)
        {
            print("WOW");
            gameObject.SetActive(false);
            ColorWheelManager.ins.Point++;
        }
    }
    /*
    void Drop(){
        ColorSlot clrSlot = null;
       
        if(GetComponentInParent<ColorSlot>() != null)
        {
            clrSlot = GetComponentInParent<ColorSlot>();
            
        }
        if (clrSlot.ecolor == ecolor)
        {
            //print("WOW");
            gameObject.SetActive(false);
            ColorWheelManager.ins.Point++;
        }
        else {
           
            print(transform.parent.name);
            itm.Origin = container;
            transform.SetParent(container);
            transform.SetLocalXPos(0);
            transform.SetLocalYPos(0);
            
        }
        
    }
    
    **/
}

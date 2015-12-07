using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;



public class ColorWheelManager : MonoBehaviour {
    [SerializeField]
    RectTransform ColorWheel;

    Animator animator;

    public static ColorWheelManager ins;
    public List<GameObject> lstColorItem;
    public List<GameObject> lstColorSlot;
    [SerializeField] int point = 0;

    public float spinSpd = 0.2f;
    public int Point {
        set { point = value; }
        get { return point; }
    }

	void Start () {
        animator = ColorWheel.GetComponent<Animator>();

        ins = this;
        StartCoroutine(IELate());
 
    }
    IEnumerator IELate() {
        yield return new WaitForSeconds(1);
        Item itm = null;

        lstColorItem = InventoryManager.ins.items;
        lstColorSlot = InventoryManager.ins.slots;

        for (int i = 0; i < InventoryManager.ins.items.Count; i++)
        {
            itm = InventoryManager.ins.items[i].GetComponent<Item>();
            itm.delegateDrop += Spin;
        }       
    }

    void Spin()
    {
        if (point == 5)
        {
            animator.SetTrigger("play");
            print("done");
        }        
    }



   
}

using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public EColor eColor = new EColor();
    [SerializeField]
    Transform origin;

	bool dragging=false; //for local dragging
	bool locked; //use along with WorldGameManager if item is under clue

	public delegate void DelDrop();
	public DelDrop delegateDrop;
	//public event delDrop OnDrop;

	#region
	public Transform Origin{
		set{origin = value;}
		get{return origin;}
	}

    public bool Locked
    {
        set { locked = value; }
        get { return locked; }
    }

    #endregion

    void Start () {
		origin = transform.parent;
		//InventoryManager.ins.items.Add(this.gameObject);

	}

 
    public void SetParentToParent()
    {
        origin = transform.parent;
    }

	
	public void Drag()
	{
		if(dragging){
            if (InventoryManager.ins.eDragDir == EDragDirection.all)
            {
                transform.position = Input.mousePosition;
            }
            else if (InventoryManager.ins.eDragDir == EDragDirection.x)
            {
                transform.SetXPos(Input.mousePosition.x);
            }
            else {
                transform.SetXPos(Input.mousePosition.y);
            }
		}

	}

	public void Drop()
	{
       
        if (InventoryManager.ins.IsReparented(this.gameObject)) {
            //reparent happened
            if (delegateDrop != null) {
                delegateDrop();
                transform.SetLocalZRot(transform.parent.GetLocalZRot());
            }
            //WordGameManager.ins.CheckWord();
        }
        else if (InventoryManager.ins.IsSwapped(this.gameObject))
        {
            if (delegateDrop != null)
            {
                delegateDrop();
            }
        }
        else {
            transform.SetParent(origin);
            transform.SetLocalXPos(0);
            transform.SetLocalYPos(0);
            //print("wow");
        }
			
		dragging  =false;
		InventoryManager.ins.Dragging = false;

	}

	public void Begin()
	{
        // print("drag begin");
        InventoryManager.ins.TransItemRecentSlot = origin;
        if (!InventoryManager.ins.Dragging && !locked){
            //print("drag begin");
            
			//remove object from its slot
			transform.SetParent(InventoryManager.ins.transform);
			InventoryManager.ins.Dragging = true;
			InventoryManager.ins.DraggedObject = this.gameObject;
			dragging = true;
		}
	}

    public void Hi() {
        print("Hi");
    }

}

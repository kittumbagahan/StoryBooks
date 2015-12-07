using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Swipe : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

//	[SerializeField]
//	float distance;


	float distance, startPos, endPos, total;


	// Use this for initialization
	void Start () {
		distance = Screen.width / 4;
		print(distance);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		startPos = Input.mousePosition.x;
		//print("start drag " + startPos);
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
	//	print("drag");
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		endPos = Input.mousePosition.x;
		total = startPos - endPos;

		//print("total :" + total + ", distance: " + distance);

		if(Mathf.Abs(total) >= distance)
		{
			if(total < 0)
			{
                SceneSpawner.ins.Next();
			}
			else
			{
                SceneSpawner.ins.Prev();
              
			}
		}
	}

	#endregion
}

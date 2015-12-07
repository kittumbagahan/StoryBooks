using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BookCategory : MonoBehaviour, IPointerClickHandler {

	BookCarouselArrange book;

	[SerializeField]
	byte bookIndex; 
	
//	[SerializeField]
//	Text text;

	RectTransform rect;

	// Use this for initialization
	void Start () {
		book = GetComponent<BookCarouselArrange>();
		rect = GetComponent<RectTransform>();
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log(transform.position);
		if(rect.position.x >= 450 && rect.position.x <= 550)
		{
			transform.localScale = new Vector2(1.5f, 1.5f);
			transform.SetAsLastSibling();
			Book.instance.BookCover(bookIndex);
			Book.instance.BOokDescription(bookIndex);
			GetComponent<Image>().raycastTarget = true;
		}
		else
		{
			transform.localScale = new Vector2(0.8f, 0.8f);
			GetComponent<Image>().raycastTarget = false;
		}

		if(rect.position.x > 850)
		{
			transform.localPosition = new Vector3(book.AfterMe.transform.localPosition.x - 135,
			                                      book.AfterMe.transform.localPosition.y,
			                                      book.AfterMe.transform.localPosition.z);
		}
		else if(rect.position.x <= -350)
		{
			transform.localPosition = new Vector3(book.BeforeMe.transform.localPosition.x + 135,
			                                      book.BeforeMe.transform.localPosition.y,
			                                      book.BeforeMe.transform.localPosition.z);
		}
	}

	void ObjectDrag (float distance)
	{
		transform.position = new Vector2(transform.position.x + distance, transform.position.y);
		//text.text = rect.transform.position.ToString();
	}

	void OnEnable()
	{
		ContainerDrag.OnObjectDrag += ObjectDrag;
	}

	void OnDisable()
	{
		ContainerDrag.OnObjectDrag -= ObjectDrag;
	}

	#region IPointerClickHandler implementation
	public void OnPointerClick (PointerEventData eventData)
	{
		KuyaTamAnimation.instance.OK();
	}
	#endregion
}

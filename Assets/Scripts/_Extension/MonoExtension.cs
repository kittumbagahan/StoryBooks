using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
public static class MonoExtension{



    public static string RandomLetter()
    {
        string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return str[UnityEngine.Random.Range(0, str.Length)].ToString();
    }

    //

    public static void SetXPos(this Transform t, float newX)
    {
        t.position = new Vector3(newX,t.position.y,t.position.z);
    }

    public static void SetYPos(this Transform t, float newY)
    {
        t.position = new Vector3(t.position.x, newY, t.position.z);
    }

    public static void SetZPos(this Transform t, float newZ)
    {
        t.position = new Vector3(t.position.x, t.position.y, newZ);
    }

    public static float GetXPos(this Transform t)
    {
        return t.position.x;
    }

    public static float GetYPos(this Transform t)
    {
        return t.position.y;
    }

    public static float GetZPos(this Transform t)
    {
        return t.position.z;
    }

	#region/*LOCAL*/
	public static void SetLocalXPos(this Transform t, float newX)
	{
		t.localPosition = new Vector3(newX, t.localPosition.y, t.localPosition.z);
	}
	public static void SetLocalYPos(this Transform t, float newY)
	{
		t.localPosition = new Vector3(t.localPosition.x, newY, t.localPosition.z);
	}
    public static void SetLocalXRot(this Transform t, float newX)
    {
        t.localRotation = Quaternion.Euler(new Vector3(newX, t.localRotation.y, t.localRotation.z));

    }
    public static void SetLocalYRot(this Transform t, float newY)
    {
        t.localRotation = Quaternion.Euler(new Vector3(t.localRotation.x, newY, t.localRotation.z));

    }
    public static void SetLocalZRot(this Transform t, float newZ)
    {
        t.localRotation = Quaternion.Euler(new Vector3(t.localRotation.x, t.localRotation.y, newZ));
        
    }

    public static float GetLocalZRot(this Transform t)
    {
        return t.localRotation.z;
    }
    
    public static void SetLocalWidth(this Transform t, float width)
    {
        t.localScale = new Vector3(width, t.localScale.y, t.localScale.z);
    }
    public static void SetLocalHeight(this Transform t, float height) {
        t.localScale = new Vector3(t.localScale.x,height,t.localScale.z);
    }
	public static float GetLocalWidth(this Transform t){
		return t.localScale.x;
	}
	public static float GetLocalHeight(this Transform t){
		return t.localScale.y;
	}
	public static float GetLocalXPos(this Transform t){
		return t.localPosition.x;
	}
	public static float GetLocalYPos(this Transform t){
		return t.localPosition.y;
	}
	#endregion
    public static void SetHeight(this RectTransform t, float height) {
        t.sizeDelta = new Vector2(t.sizeDelta.x, height);
    }
    public static void SetWidth(this RectTransform t, float width)
    {
        t.sizeDelta = new Vector2(width, t.sizeDelta.y);
    }
	public static float GetWidth(this RectTransform t){
		return t.sizeDelta.x;
	}

    public static void SetLocalWidth(this RectTransform t, float width) {
        t.localScale = new Vector3(width, t.localScale.y, t.localScale.z);
    }
    public static void SetLocalHeight(this RectTransform t, float height)
    {
        t.localScale = new Vector3(t.localScale.x, height, t.localScale.z);
    }
}

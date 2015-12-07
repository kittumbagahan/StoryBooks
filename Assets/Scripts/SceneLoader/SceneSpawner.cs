using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SceneSpawner : MonoBehaviour {
    public static SceneSpawner ins;

	public Button UIBtnNext, UIBtnPrev;
    public List<GameObject> lstScenes = new List<GameObject>();
    List<GameObject> lstPool = new List<GameObject>();
    GameObject curr, prev, next;
    GameObject o;
    
    int sceneIndex=0; 
	
    void Start () {
		print(lstScenes.Count-1);
        ins = this;
        o = (GameObject)Instantiate(lstScenes[sceneIndex]);
        lstPool.Add(o);
        curr = o;
        sceneIndex++; //for the "next" object see Line 26

        try 
        {
            //pool the next object
            o = (GameObject)Instantiate(lstScenes[sceneIndex]);
            lstPool.Add(o);
            next = o;
            next.SetActive(false);
        }
        catch(System.ArgumentOutOfRangeException ex)
        {
			print(ex.Message.ToUpper());
        }
        curr.SetActive(true);
		Trace();

	}

    public void Prev() 
    {
        if (UIBtnPrev.interactable)
        {
            sceneIndex--;
            curr = prev;
            try
            {
                prev = lstPool[sceneIndex - 2];
                next = lstPool[sceneIndex];
                if (prev != null) { prev.SetActive(false); }
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                prev = null;
                next = lstPool[sceneIndex];
                print(ex.Message);
                //sceneIndex++;
                UIBtnPrev.interactable = false;
            }

            next.SetActive(false);
            if (curr != null) curr.SetActive(true);
            print("pressed prev " + sceneIndex);
            print("---prev---");
            Trace();
            UIBtnNext.interactable = true;
        }
		
    }

    public void Next() 
    {
        if (UIBtnNext.interactable)
        {
            prev = curr;
            curr = next;
            sceneIndex++; //for the "next" object
            try
            {
                if (HasDuplicate(lstScenes[sceneIndex]))
                {
                    next = lstPool[sceneIndex];
                }
                else if (!HasDuplicate(lstScenes[sceneIndex]))
                {
                    o = (GameObject)Instantiate(lstScenes[sceneIndex]);
                    lstPool.Add(o);
                    next = o;
                }
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                next = null;
                UIBtnNext.interactable = false;
            }

            if (curr != null) curr.SetActive(true);
            if (next != null) next.SetActive(false);
            if (prev != null) prev.SetActive(false);
            print("pressed next " + sceneIndex);
            print("---NEXT---");
            Trace();

            UIBtnPrev.interactable = true;
        }
      
	}

	void Trace(){
		if(prev != null)print("prev " + prev.gameObject.name);
		if(curr != null)print("curr " + curr.gameObject.name);
		if(next != null)print("next " + next.gameObject.name);
	}

    bool HasDuplicate(GameObject obj) 
    {
        string s;
        for (int i = 0; i < lstPool.Count; i++ )
        {
            s = lstPool[i].gameObject.name.Replace("(Clone)", "");
            if(s == obj.name)
            {
                return true;
            }
        }

        return false;
    }

    
   
}

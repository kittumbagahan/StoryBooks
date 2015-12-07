using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class SpotDiffManager : MonoBehaviour {
    public static SpotDiffManager ins;
    public List<Sprite> lstClone;
    public List<Sprite> lstDiff;
    public List<Transform> lstObjectToSpot;

    int setIndex = -1;
    	
   
	void Start () {
        ins = this;
        GenerateSpot();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   public void GenerateSpot()
    {
        StartCoroutine(IEGenerateSpot());
    }

    void Reset()
    {
        ObjectToSpot ots = null;
        for (int i=0; i<lstObjectToSpot.Count; i++)
        {
            ots = lstObjectToSpot[i].GetComponent<ObjectToSpot>();
            ots.different = false;
        }
    }

    IEnumerator IEGenerateSpot()
    {
        yield return new WaitForSeconds(1f);

        if (setIndex < lstClone.Count - 1)
        {
            setIndex++; //starting from -1
            Reset();
            ObjectToSpot ots = null;
            lstObjectToSpot.Shuffle();
            //clones
            lstObjectToSpot[0].GetComponent<Image>().sprite = lstClone[setIndex];
            lstObjectToSpot[1].GetComponent<Image>().sprite = lstClone[setIndex];
            lstObjectToSpot[2].GetComponent<Image>().sprite = lstClone[setIndex];
            //diff
            lstObjectToSpot[3].GetComponent<Image>().sprite = lstDiff[setIndex];
            ots = lstObjectToSpot[3].GetComponent<ObjectToSpot>();
            ots.different = true;
        }
        else {
            print("GameOver");
        }
       
    }

    
}

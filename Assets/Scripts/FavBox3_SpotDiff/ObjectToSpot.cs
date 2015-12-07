using UnityEngine;
using System.Collections;

public class ObjectToSpot : MonoBehaviour {

    public bool different = false;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Click()
    {
        if (different)
        {
            print("YOU FOUND IT!");
            SpotDiffManager.ins.GenerateSpot();
        }
        else
        {
            print("TRY AGAIN");
            //SpotDiffManager.ins.PlayWrongSound();
        }
    }
}

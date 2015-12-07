using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class WordGameManager : MonoBehaviour {
	public static WordGameManager ins;
	public List<string> wordList;

	//inventory canvas
	public GameObject groupClue, groupLetters;
	public GameObject slot, itemLetter;
	//end inventory canvas
	public List<GameObject> lstPoolClueLetters;
	public List<GameObject> lstPoolMissingLetter;

    public delegate void ActionGenerateWord();
    public ActionGenerateWord delGenerateWord;

	List<GameObject> emptyList = new List<GameObject>(); //for emptying list on next word
	string strExtracted;
	string strClue;  //clue
	string word;
	int index=0, rnd=0;

	void ExtractWord()
	{
		strExtracted = "";
		int cnt = strClue.Length/2;

		while (cnt > 0) {
			rnd = UnityEngine.Random.Range(0,strClue.Length);
			strExtracted += strClue[rnd];
			strClue = strClue.Remove(rnd, 1);
			cnt--;
			//strClue = strClue.Replace(strClue[rnd]
		}

	}

	void SpawnSlotTo(Transform container, List<GameObject> lstInventory)
	{
		GameObject o = null;
		/*
		bool f=false;

		for(int i=0; i<lstInventory.Count && !f; i++)
		{
			if(lstInventory[i].activeInHierarchy == false)
			{
				lstInventory[i].SetActive(true);
				f = true;
				print("wow");
			}
		}
		if(!f){
			o = (GameObject)Instantiate(slot,transform.position, Quaternion.identity);
			lstInventory.Add(o);
		}
		*/
		o = (GameObject)Instantiate(slot,transform.position, Quaternion.identity);
		o.transform.SetParent(container);
		o.transform.SetLocalXPos(0);
		o.transform.SetLocalYPos(0);
		lstInventory.Add(o);
	
	}

	void SpawnLetterTo(Transform parent, List<GameObject> lstInventory, List<GameObject> pool)
	{
		GameObject o = null;
		Text txt = null;
		/*
		bool f=false;
		for(int i=0; i<lstInventory.Count; i++)
		{
			if(lstInventory[i].activeInHierarchy == false)
			{
				lstInventory[i].SetActive(true);
				f = true;
			}
		}
		if(!f)
		{
			o = (GameObject)Instantiate(itemLetter,transform.position, Quaternion.identity);
			lstInventory.Add(o);
			pool.Add(o);
		}
		*/

		o = (GameObject)Instantiate(itemLetter,transform.position, Quaternion.identity);
		o.transform.SetParent(parent);
		o.transform.SetLocalXPos(0);
		o.transform.SetLocalYPos(0);
		txt = o.transform.GetChild(0).GetComponent<Text>();
		lstInventory.Add(o);
		pool.Add(o);
       
	}

	void ChangeTextsValueTo(List<GameObject> pool, string value)
	{
		int n = 0;

		for(int i=0; i<value.Length; i++)
		{
			Text txt = pool[i].transform.GetChild(0).GetComponent<Text>();
			txt.text = value[n].ToString();
			n++;
		}
	}

	void AlignSlots(Transform container,float dist)
	{
		float tempDist = dist;
		for(int i=0; i<container.childCount; i++){
			Transform t = null;
			t = container.GetChild(i).GetComponent<Transform>();
			t.SetXPos(tempDist);
			tempDist += dist;
		}
	}

	public void CheckWord()
	{
		string str="";
		for(int i=0; i<groupClue.transform.childCount; i++)
		{
			Transform slot = groupClue.transform.GetChild(i);
			Transform item = null;
			Text txt = null;
			if(slot.childCount >= 1)
			{
				item = slot.GetChild(0);
			}
			
			if(item != null && item.childCount >= 1)
			{
				txt = item.GetChild(0).GetComponent<Text>();
			}
			if(txt != null)
			{
				str += txt.text;
			}

		}
		if(str == word)
		{
			print("Wow! Fantastic baby!");
			index++;

			StartCoroutine(IEGoNext());
			//Next();
		}else{
			print("DONT GIVE UP");
		}
	}

	void DisableItems(List<GameObject> lstObj, bool val)
	{
		Item itm=null;
		//GameObject o=null;
		for(int i=0; i<lstObj.Count; i++)
		{
			itm = lstObj[i].GetComponent<Item>();
			//itm.enabled = false;
			itm.Locked = val;
		}
	}

	void DestroyAll()
	{
		//DisableItems(lstPoolClueLetters, false);

		for(int i=0; i<InventoryManager.ins.slots.Count; i++){
			//InventoryManager.ins.slots[i].SetActive(false);
			Destroy(InventoryManager.ins.slots[i]);
		}
		//remove items from the slot
		for(int i=0; i<InventoryManager.ins.items.Count; i++){
			Item itm = InventoryManager.ins.items[i].GetComponent<Item>();
			itm.delegateDrop -= CheckWord;
			Destroy(InventoryManager.ins.items[i]);
			/*
			Transform t = null;
			t = InventoryManager.ins.items[i].transform;
			t.SetParent(this.transform);
			t.gameObject.SetActive(false);
			*/
		}
		
		//remove slots from the container
		/*
		for(int i=0; i<InventoryManager.ins.slots.Count; i++){
			Destroy(InventoryManager.ins.slots[i]);

			Transform t = null;
			t = InventoryManager.ins.slots[i].transform;
			t.SetParent(this.transform);
			t.gameObject.SetActive(false);

		}
		*/

		InventoryManager.ins.slots.Clear();
		InventoryManager.ins.items.Clear();
		lstPoolClueLetters.Clear();
		lstPoolMissingLetter.Clear();
		/*
		InventoryManager.ins.slots = emptyList;
		InventoryManager.ins.items = emptyList;
		lstPoolClueLetters = emptyList;
		lstPoolMissingLetter = emptyList;
		*/
	}
	/*
	String RandomLetter(){
		string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		return str[UnityEngine.Random.Range(0,str.Length)].ToString();
	}
    */
	void GenerateWord()
	{
		try
		{
			word = wordList[index];
			print(word);
			strClue = word;
			ExtractWord();
			int clueIndex = 0; //for aligning clue letters 
			//spawn slots
			for(int i=0; i<word.Length; i++){
				SpawnSlotTo(groupClue.transform, InventoryManager.ins.slots);
			}
			for(int i=0; i<strExtracted.Length + 1; i++) //+1 extra slot for extra letter
			{
				SpawnSlotTo(groupLetters.transform, InventoryManager.ins.slots);
			}
			
			//spawn letters
			for(int i=0; i<strExtracted.Length + 1; i++) //+1 for extra letter
			{	
                 
				Transform slot = groupLetters.transform.GetChild(i).transform;
                SpawnLetterTo(slot, InventoryManager.ins.items, lstPoolMissingLetter);
			}
			
			for(int i=0; i<word.Length; i++)
			{
				Transform slot = groupClue.transform.GetChild(i).transform;
				try
				{
					if(word[i] == strClue[clueIndex])//strClue[clueIndex])
					{
						clueIndex++;
						SpawnLetterTo(slot, InventoryManager.ins.items, lstPoolClueLetters);
					}
				}catch(IndexOutOfRangeException)
				{
					
				}
			}
			ChangeTextsValueTo(lstPoolClueLetters, strClue);
			ChangeTextsValueTo(lstPoolMissingLetter, strExtracted + MonoExtension.RandomLetter());
			DisableItems(lstPoolClueLetters, true);
			//Add Checkword method on Item delegates
			for(int i=0; i<InventoryManager.ins.items.Count; i++)
			{
				Item itm = InventoryManager.ins.items[i].GetComponent<Item>();
				itm.delegateDrop += CheckWord;
			}
            for(int i=0; i<InventoryManager.ins.slots.Count; i++)
            {
                Slot s = InventoryManager.ins.slots[i].GetComponent<Slot>();
                s.CheckSlot();
            }

            if (delGenerateWord != null)
            {
                delGenerateWord();
            }
		}
		catch(ArgumentOutOfRangeException)
		{
			print("All words has been answered. GAME OVER");
		}
	}


	IEnumerator IEGoNext(){
		yield return new WaitForSeconds(0.5f);
		DestroyAll();
		yield return new WaitForSeconds(1f);
		GenerateWord();
	}

	void Start () {
		ins = this;
		wordList.Shuffle();
		GenerateWord();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

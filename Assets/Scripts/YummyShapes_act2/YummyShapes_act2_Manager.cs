using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class YummyShapes_act2_Manager : MonoBehaviour {

    public Sprite[] sprtFruitIdle;
    public Sprite[] sprtFruitWrong;
    public Sprite[] sprtFruitRight;
    public Button[] btnFruits;

    int index = 0;
    Sprite sprtDifferentGray;
    Sprite sprtDifferentColored;
    string strFruitAns, strFruitWrong;
    SpriteState sprtTempState;

	void Start () {
        GameOn();
	}

    void GameOn()
    {
        btnFruits.Shuffle();
        for (int i = 0; i < btnFruits.Length; i++)
        {
            //btnFruits[i].spriteState = sprtTempState;
            btnFruits[i].interactable = true;
        }
        btnFruits[0].GetComponent<Image>().sprite = sprtFruitIdle[index];
        strFruitAns = GetFruitSpriteName(sprtFruitIdle[index].name);
        //
        sprtDifferentGray = GetDifferentFrom(strFruitAns);
        //strFruitWrong = GetFruitSpriteName(sprtDifferent.name);
        btnFruits[1].GetComponent<Image>().sprite = sprtDifferentGray;
        btnFruits[1].spriteState = sprtTempState;
        btnFruits[2].GetComponent<Image>().sprite = sprtDifferentGray;
        btnFruits[2].spriteState = sprtTempState;
        btnFruits[3].GetComponent<Image>().sprite = sprtDifferentGray;
        btnFruits[3].spriteState = sprtTempState;
    }

    Sprite GetDifferentFrom(string str)
    {
        Sprite sprt = null;

        while(sprt == null)
        {
            int rnd = Random.Range(0, sprtFruitIdle.Length);
            sprt = sprtFruitIdle[rnd];
            if (GetFruitSpriteName(sprt.name) == str)
            {
                sprt = null;
            }
            else
            {
                sprtTempState.disabledSprite = sprtFruitWrong[rnd];
                sprtDifferentColored = sprtFruitRight[rnd];
            }
        }
        return sprt;
        
    }

    string GetFruitSpriteName(string sprtName)
    {
     
        if (sprtName.Contains("apple")) { return "apple"; }
        if (sprtName.Contains("banana")) { return "banana"; }
        if (sprtName.Contains("strawberry")) { return "strawberry"; }
        if (sprtName.Contains("orange")) { return "orange"; }
        if (sprtName.Contains("jackfruit")) { return "jackfruit"; }
        if (sprtName.Contains("mango")) { return "mango"; }

        return "";
    }

    public void Choose(Image img)
    {
        string strChoice = GetFruitSpriteName(img.sprite.name);
        Button btn = img.GetComponent<Button>();
        if (strFruitAns == strChoice)
        {
            print("wow");
            img.sprite = sprtFruitRight[index];
            Correct();
        }
        else
        {
            print("ngek");
            //img.sprite = sprtFruitWrong[index];
            btn.interactable = false;
        }
    }

    void Correct()
    {
        sprtTempState.disabledSprite = sprtDifferentColored;
        if (index < sprtFruitIdle.Length - 1)
        {
            index++;
        }
        for(int i=1; i<btnFruits.Length; i++)
        {
            btnFruits[i].spriteState = sprtTempState;
            btnFruits[i].interactable = false;
        }
        StartCoroutine(IENext());
    }

    IEnumerator IENext()
    {
        yield return new WaitForSeconds(1f);
        GameOn();
    }
}

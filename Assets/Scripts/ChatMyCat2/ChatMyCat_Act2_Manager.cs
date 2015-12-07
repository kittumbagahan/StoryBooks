using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ChatMyCat_Act2_Manager : MonoBehaviour {

    public Button[] UIBtns;
    public string[] words;
    public Sprite[] wordSprites;
    public Text txtToFillIn;
    public Text txtMissing;
    public Image wordImg;
    public Sprite sprtWrongChoice;
    public Sprite sprtRightChoice;

    int wordIndex = 0;
    char answer;

	void Start () {
        words.Shuffle();
        GameOn();
    
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void GameOn()
    {
        Text txt = null;
        string wordToGuess = words[wordIndex];
        SelectSprite(wordToGuess);
        txtMissing.text = "";
        txtToFillIn.text = "_";
        txtToFillIn.text += wordToGuess.Substring(1, wordToGuess.Length-1);
        answer = wordToGuess[0];

        UIBtns.Shuffle();
        txt = UIBtns[0].GetComponent<Transform>().GetChild(0).GetComponent<Text>();
        txt.text = answer.ToString();
        //--random
        txt = UIBtns[1].GetComponent<Transform>().GetChild(0).GetComponent<Text>();
        txt.text = MonoExtension.RandomLetter();
        txt = UIBtns[2].GetComponent<Transform>().GetChild(0).GetComponent<Text>();
        txt.text = MonoExtension.RandomLetter();
        txt = UIBtns[3].GetComponent<Transform>().GetChild(0).GetComponent<Text>();
        txt.text = MonoExtension.RandomLetter();

        UIBtns[0].interactable = true;
        UIBtns[1].interactable = true;
        UIBtns[2].interactable = true;
        UIBtns[3].interactable = true;
    }

    void SelectSprite(string word)
    {
        switch (word)
        {
            case "Bat":
                wordImg.sprite = wordSprites[0]; break;
            case "Cat":
                wordImg.sprite = wordSprites[1]; break;
            case "Hat":
                wordImg.sprite = wordSprites[2]; break;
            case "Rat":
                wordImg.sprite = wordSprites[3]; break;
            case "Splat":
                wordImg.sprite = wordSprites[4]; break;
            default: break;
        }
    }

    public void Choose(Button btn)
    {
        Text txtBtnTextValue = btn.GetComponent<Transform>().GetChild(0).GetComponent<Text>();
        SpriteState tempSprtState = btn.spriteState;
        if (txtBtnTextValue.text == answer.ToString())
        {
            print("Correct");
            StartCoroutine(IENext());
            txtMissing.text = answer.ToString();
            tempSprtState.disabledSprite = sprtRightChoice;
            btn.spriteState = tempSprtState;
        }
        else
        {
            print("Wrong");
            tempSprtState.disabledSprite = sprtWrongChoice;
            btn.spriteState = tempSprtState;
        }
        btn.interactable = false;
    }

    IEnumerator IENext()
    {
        yield return new WaitForSeconds(2f);
        if (wordIndex < words.Length - 1)
        {
            wordIndex++;
            GameOn();
        }
    }
}

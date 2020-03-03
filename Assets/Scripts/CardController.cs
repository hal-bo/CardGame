using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour {

	CardModel cardModel;
	int cardIndex = 0;

	public GameObject card;

	private void Awake(){
		cardModel = card.GetComponent<CardModel> ();
	}
		
	void OnGUI()
	{
		if(GUI.Button(new Rect(10,10,100,28), "Hit me!")){
			if (cardIndex >= cardModel.faces.Length){
				cardIndex = 0;
				cardModel.Flip(cardModel.faces[cardModel.faces.Length - 1], cardModel.cardBack, -1);
			}else{
				if (cardIndex > 0){
					cardModel.Flip(cardModel.faces[cardIndex - 1], cardModel.faces[cardIndex], cardIndex);
				}else{
					cardModel.Flip(cardModel.cardBack, cardModel.faces[cardIndex], cardIndex);
				}
				cardIndex++;
			}

		}

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModel : MonoBehaviour {

	SpriteRenderer spriteRenderer;

	CardFlipper flipper;

	public Sprite[] faces;
	public Sprite cardBack;

	public int cardIndex;

	public void ToggleFace(bool showFace){
		if(showFace){
			spriteRenderer.sprite = faces [cardIndex];
		}else{
			spriteRenderer.sprite = cardBack;
		}
	}

	public void Flip(Sprite startImage, Sprite endImage, int cardIndex){
		if (cardIndex >= faces.Length){
			cardIndex = 0;
			flipper.FlipCard(faces[faces.Length - 1], cardBack, -1);
		}else{
			if (cardIndex > 0){
				flipper.FlipCard(faces[cardIndex - 1], faces[cardIndex], cardIndex);
			}else{
				flipper.FlipCard(cardBack, faces[cardIndex], cardIndex);
			}
			cardIndex++;
		}
	}

	void Awake(){
		spriteRenderer = GetComponent<SpriteRenderer> ();
		flipper = GetComponent<CardFlipper> ();
		ToggleFace (true);
	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

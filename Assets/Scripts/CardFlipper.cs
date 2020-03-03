using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlipper : MonoBehaviour {

	CardModel model;

	SpriteRenderer spriteRenderer;

	public AnimationCurve scaleCurve;
	public float duration = 0.5f;

	private void Awake(){
		spriteRenderer = GetComponent<SpriteRenderer> ();
		model = GetComponent<CardModel> ();
	}

	public void FlipCard(Sprite startImage, Sprite endImage, int cardIndex){
		StopCoroutine (Flip (startImage, endImage, cardIndex));
		StartCoroutine (Flip (startImage, endImage, cardIndex));
	}

	IEnumerator Flip(Sprite startImage, Sprite endImage, int cardIndex){

		spriteRenderer.sprite = startImage;

		float time = 0f;
		while(time <= 1f){
			float scale = scaleCurve.Evaluate (time);
			time = time + Time.deltaTime / duration;

			Vector3 localScale = transform.localScale;
			localScale.x = scale;
			transform.localScale = localScale;

			if (time >= 0.5f) {
				spriteRenderer.sprite = endImage;
			}

			yield return new WaitForFixedUpdate ();
		}

		if (cardIndex == -1) {
			model.ToggleFace (false);
		} else {
			model.cardIndex = cardIndex;
			model.ToggleFace (true);
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

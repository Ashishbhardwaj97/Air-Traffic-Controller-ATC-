using UnityEngine;
using System.Collections;

public class SpriteAndTextFunctions : MonoBehaviour {

	public static SpriteAndTextFunctions instance; 
	void Awake() {instance = this;}


	public void FadeSprite(tk2dTextMesh txt,tk2dSprite sprite,tk2dTiledSprite tiledSprite,tk2dSlicedSprite slicedSprite,float from,float to,float time,float delay = 0)
	{StartCoroutine (FadeSpriteCoroutine(txt,sprite,tiledSprite,slicedSprite,from,to,time,delay));}
	
	IEnumerator FadeSpriteCoroutine(tk2dTextMesh txt,tk2dSprite sprite,tk2dTiledSprite tiledSprite,tk2dSlicedSprite slicedSprite,float from,float to,float time,float delay)
	{
		float value = 0;
		float lerpValue = 0;
		float amount = Mathf.Abs (from - to);
		float speed = amount/time; 
		while(lerpValue < 1)
		{

			if(txt != null)         {txt.color = new Color(txt.color.r,txt.color.g,txt.color.b,Mathf.Lerp(from,to,lerpValue));}
			if(sprite != null)      {sprite.color = new Color(sprite.color.r,sprite.color.g,sprite.color.b,Mathf.Lerp(from,to,lerpValue));}
			if(tiledSprite != null) {tiledSprite.color = new Color(tiledSprite.color.r,tiledSprite.color.g,tiledSprite.color.b,Mathf.Lerp(from,to,lerpValue));}
			if(slicedSprite != null){slicedSprite.color = new Color(slicedSprite.color.r,slicedSprite.color.g,slicedSprite.color.b,Mathf.Lerp(from,to,lerpValue));}

			lerpValue += speed*Time.deltaTime;


			if(delay > 0){yield return new WaitForSeconds(delay); delay = 0;}
			yield return null;
		}
	}

	public void SetSprite(tk2dSprite sprite,string newSpriteName){sprite.SetSprite (newSpriteName);}







	public void FadeOutSprite(tk2dTextMesh txt,tk2dSprite sprite,tk2dTiledSprite tiledSprite,tk2dSlicedSprite slicedSprite,float time,float amount)
	{StartCoroutine (FadeOutSpriteCoroutine(txt,sprite,tiledSprite,slicedSprite,time,amount));}
	
	IEnumerator FadeOutSpriteCoroutine(tk2dTextMesh txt,tk2dSprite sprite,tk2dTiledSprite tiledSprite,tk2dSlicedSprite slicedSprite,float time,float amount)
	{
		float value = 0;
		if(txt != null)         {value = txt.color.a;}
		if(sprite != null)      {value = sprite.color.a;}
		if(tiledSprite != null) {value = tiledSprite.color.a;}
		if(slicedSprite != null){value = slicedSprite.color.a;}
		float speed = 1/time; 
		while(value < amount)
		{
			value += speed*Time.deltaTime;
			if(value > amount){value = amount;}

			if(txt != null)         {txt.color = new Color(txt.color.r,txt.color.g,txt.color.b,value);}
			if(sprite != null)      {sprite.color = new Color(sprite.color.r,sprite.color.g,sprite.color.b,value);}
			if(tiledSprite != null) {tiledSprite.color = new Color(tiledSprite.color.r,tiledSprite.color.g,tiledSprite.color.b,value);}
			if(slicedSprite != null){slicedSprite.color = new Color(slicedSprite.color.r,slicedSprite.color.g,slicedSprite.color.b,value);}

			sprite.color = new Color(sprite.color.r,sprite.color.g,sprite.color.b,value);
			yield return null;
		}
	}
	
	public void FadeInSprite(tk2dTextMesh txt,tk2dSprite sprite,tk2dTiledSprite tiledSprite,tk2dSlicedSprite slicedSprite,float time,float amount)
	{StartCoroutine (FadeInSpriteCoroutine(txt,sprite,tiledSprite,slicedSprite,time,amount));}
	
	IEnumerator FadeInSpriteCoroutine(tk2dTextMesh txt,tk2dSprite sprite,tk2dTiledSprite tiledSprite,tk2dSlicedSprite slicedSprite,float time,float amount)
	{
		float value = 0;
		if(txt != null)         {value = txt.color.a;}
		if(sprite != null)      {value = sprite.color.a;}
		if(tiledSprite != null) {value = tiledSprite.color.a;}
		if(slicedSprite != null){value = slicedSprite.color.a;}

		float speed = 1/time; 
		while(value > amount)
		{
			value -= speed*Time.deltaTime;
			if(value < amount){value = amount;}

			if(txt != null)         {txt.color = new Color(txt.color.r,txt.color.g,txt.color.b,value);}
			if(sprite != null)      {sprite.color = new Color(sprite.color.r,sprite.color.g,sprite.color.b,value);}
			if(tiledSprite != null) {tiledSprite.color = new Color(tiledSprite.color.r,tiledSprite.color.g,tiledSprite.color.b,value);}
			if(slicedSprite != null){slicedSprite.color = new Color(slicedSprite.color.r,slicedSprite.color.g,slicedSprite.color.b,value);}
			yield return null;
		}
	}

	public void SetTxtFromTxtWithPrefixSuffix (tk2dTextMesh txtToSet,tk2dTextMesh txtToSetFromTxt,string prefix,string suffix) {txtToSet.text = prefix + txtToSetFromTxt.text + suffix;}

	public void SetTxtFromTxt (tk2dTextMesh txtToSet,tk2dTextMesh txtToSetFromTxt) {txtToSet.text = txtToSetFromTxt.text;}

	public void SetTxtString (tk2dTextMesh txtToSet,string txtString) {txtToSet.text = txtString;}

	public void ChangeTxtScore (tk2dTextMesh txtToChange,int amount) 
	{
		int intTxt = int.Parse (txtToChange.text) + amount;
		txtToChange.text = intTxt.ToString();
	}

	public void ChangeTxtScoreWithRange (tk2dTextMesh txtToChange,int amount,int lessThanRange,int greaterThanRange) 
	{
		int intTxt = int.Parse (txtToChange.text) + amount;
		if(intTxt < lessThanRange){intTxt = lessThanRange;}
		if(intTxt > greaterThanRange){intTxt = greaterThanRange;}
		txtToChange.text = intTxt.ToString();
	}

	public void ChangeTxtScoreFromTextMesh (tk2dTextMesh txtToChange,tk2dTextMesh takeTxtFrom) 
	{
		int intTxt = int.Parse (txtToChange.text) + int.Parse (takeTxtFrom.text);
		txtToChange.text = intTxt.ToString();
	}



























}

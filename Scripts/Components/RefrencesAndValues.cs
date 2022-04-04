using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RefrencesAndValues : MonoBehaviour 
{
	public string[] labels;

	[Space]
	[InspectorButton("UpdateFunctionNames")]
	public bool updateFunctionNames;

	public List<UiEvent> UiEvents = new List<UiEvent>();
	public List<CoroutineWithName> coroutines = new List<CoroutineWithName>();
	public List<ColorValue> colorValues = new List<ColorValue>();
	public List<GuiRayRecieverReference> guiRayRecieverReferences = new List<GuiRayRecieverReference>();
	public List<TransformReference> transformReferences = new List<TransformReference>();
	public List<GameObjectReference> gameObjectReferences = new List<GameObjectReference>();
	public List<StringValue> stringValues = new List<StringValue>();
	public List<FloatValue> floatValues = new List<FloatValue>();
	public List<IntValue> intValues = new List<IntValue>();
	public List<BoolValue> boolValues = new List<BoolValue>();
	public List<TextMeshReference> textMeshReferences = new List<TextMeshReference>();
	public List<SpriteReference> spriteReferences = new List<SpriteReference>();
	public List<TiledSpriteReference> tiledSpriteReferences = new List<TiledSpriteReference>();
	public List<SlicedSpriteReference> slicedSpriteReferences = new List<SlicedSpriteReference>();

	[Serializable]
	public class CoroutineWithName
	{
		public string coroutineName;
		public Coroutine coroutine;
	}

	[Serializable]
	public class UiEvent
	{
		public string label;
		public UIEvents events;
	}

	[Serializable]
	public class ColorValue
	{
		public string valueName;
		public Color value;
	}

	[Serializable]
	public class GuiRayRecieverReference
	{
		public string referenceName;
		public GuiRayReceiver reference;
	}

	[Serializable]
	public class TransformReference
	{
		public string referenceName;
		public Transform reference;
	}


	[Serializable]
	public class GameObjectReference
	{
		public string referenceName;
		public GameObject reference;
	}


	[Serializable]
	public class StringValue
	{
		public string valueName;
		public string value;
	}

	[Serializable]
	public class FloatValue
	{
		public string valueName;
		public float value;
	}

	[Serializable]
	public class IntValue
	{
		public string valueName;
		public int value;
	}

	[Serializable]
	public class BoolValue
	{
		public string valueName;
		public bool value;
	}

	[Serializable]
	public class TextMeshReference
	{
		public string referenceName;
		public tk2dTextMesh reference;
	}

	[Serializable]
	public class SpriteReference
	{
		public string referenceName;
		public tk2dSprite reference;
	}

	[Serializable]
	public class TiledSpriteReference
	{
		public string referenceName;
		public tk2dTiledSprite reference;
	}

	[Serializable]
	public class SlicedSpriteReference
	{
		public string referenceName;
		public tk2dSlicedSprite reference;
	}



	public UIEvents GetUiEvents(String label)
	{
		for (int i = 0; i < UiEvents.Count; i++) 
		{
			if(UiEvents[i].label == label){return UiEvents[i].events;}
		}
		print ("The UiEvents With The Label " + label + " Not Found");
		return null;
	}
	
	public void SetUiEvents(string label,UIEvents uiEvents)
	{
		for (int i = 0; i < UiEvents.Count; i++) 
		{
			if(UiEvents[i].label == label){UiEvents[i].events = uiEvents; return;}
		}
		UiEvent uiEvent = new UiEvent ();
		uiEvent.label = label;
		uiEvent.events = uiEvents;
		UiEvents.Add (uiEvent);
	}

	public void InvokeUiEvents(string label,GameObject reqActiveGameObject = null)
	{
		if(reqActiveGameObject == null){reqActiveGameObject = gameObject;}
		for (int i = 0; i < UiEvents.Count; i++) 
		{
			if(UiEvents[i].label == label){UiEvents[i].events.Invoke(reqActiveGameObject); return;}
		}
	}



	public Coroutine GetCoroutine(String coroutineName)
	{
		for (int i = 0; i < coroutines.Count; i++) 
		{
			if(coroutines[i].coroutineName == coroutineName){return coroutines[i].coroutine;}
		}
		print ("The Coroutine With The Name " + coroutineName + " Not Found");
		return null;
	}
	
	public void SetCoroutine(string coroutineName,Coroutine coroutine)
	{
		for (int i = 0; i < coroutines.Count; i++) 
		{
			if(coroutines[i].coroutineName == coroutineName){coroutines[i].coroutine = coroutine; return;}
		}
		CoroutineWithName newCoroutine = new CoroutineWithName ();
		newCoroutine.coroutineName = coroutineName;
		newCoroutine.coroutine = coroutine;
		coroutines.Add (newCoroutine);
	}



	public Color GetColor(String name)
	{
		for (int i = 0; i < colorValues.Count; i++) 
		{
			if(colorValues[i].valueName == name){return colorValues[i].value;}
		}
		print ("The Color Value With The Name " + name + " Not Found");
		return new Color();
	}
	
	public void SetColor(string name,Color value)
	{
		for (int i = 0; i < colorValues.Count; i++) 
		{
			if(colorValues[i].valueName == name){colorValues[i].value = value; return;}
		}
		ColorValue colorValue = new ColorValue ();
		colorValue.valueName = name;
		colorValue.value = value;
		colorValues.Add (colorValue);
	}


	public GuiRayReceiver GetGuiRayReceiver(String name)
	{
		for (int i = 0; i < guiRayRecieverReferences.Count; i++) 
		{
			if(guiRayRecieverReferences[i].referenceName == name){return guiRayRecieverReferences[i].reference;}
		}
		return null;
	}
	
	public void SetGuiRayReceiver(string name,GuiRayReceiver reference)
	{
		for (int i = 0; i < guiRayRecieverReferences.Count; i++) 
		{
			if(guiRayRecieverReferences[i].referenceName == name){guiRayRecieverReferences[i].reference = reference; return;}
		}
		GuiRayRecieverReference guiRayReceiverReference = new GuiRayRecieverReference ();
		guiRayReceiverReference.referenceName = name;
		guiRayReceiverReference.reference = reference;
		guiRayRecieverReferences.Add (guiRayReceiverReference);
	}
	
	

	public Transform GetTransform(String name)
	{
		for (int i = 0; i < transformReferences.Count; i++) 
		{
			if(transformReferences[i].referenceName == name){return transformReferences[i].reference;}
		}
		return null;
	}

	public void SetTransform(String name,Transform reference)
	{
		for (int i = 0; i < transformReferences.Count; i++) 
		{
			if(transformReferences[i].referenceName == name){transformReferences[i].reference = reference; return;}
		}
		TransformReference transformReference = new TransformReference ();
		transformReference.referenceName = name;
		transformReference.reference = reference;
		transformReferences.Add (transformReference);
	}


	public GameObject GetGameObject(String name)
	{
		for (int i = 0; i < gameObjectReferences.Count; i++) 
		{
			if(gameObjectReferences[i].referenceName == name){return gameObjectReferences[i].reference;}
		}
		return null;
	}
	
	public void SetGameObject(String name,GameObject reference)
	{
		for (int i = 0; i < gameObjectReferences.Count; i++) 
		{
			if(gameObjectReferences[i].referenceName == name){gameObjectReferences[i].reference = reference; return;}
		}
		GameObjectReference gameObjectReference = new GameObjectReference ();
		gameObjectReference.referenceName = name;
		gameObjectReference.reference = reference;
		gameObjectReferences.Add (gameObjectReference);
	}
	
	
	public string GetString(String name)
	{
		for (int i = 0; i < stringValues.Count; i++) 
		{
			if(stringValues[i].valueName == name){return stringValues[i].value;}
		}
		print ("The String Value With The Name " + name + " Not Found");
		return null;
	}
	
	public void SetString(String name,string value)
	{
		for (int i = 0; i < stringValues.Count; i++) 
		{
			if(stringValues[i].value == value){stringValues[i].value = value; return;}
		}
		StringValue stringValue = new StringValue ();
		stringValue.valueName = name;
		stringValue.value = value;
		stringValues.Add (stringValue);
	}
	
	
	public float GetFloat(String name)
	{
		for (int i = 0; i < floatValues.Count; i++) 
		{
			if(floatValues[i].valueName == name){return floatValues[i].value;}
		}
		print ("The Float Value With The Name " + name + " Not Found");
		return -.1111111f;
	}
	
	public void SetFloat(String name,float value)
	{
		for (int i = 0; i < floatValues.Count; i++) 
		{
			if(floatValues[i].valueName == name){floatValues[i].value = value; return;}
		}
		FloatValue floatValue = new FloatValue ();
		floatValue.valueName = name;
		floatValue.value = value;
		floatValues.Add (floatValue);
	}
	
	
	public int GetInt(String name)
	{
		for (int i = 0; i < intValues.Count; i++) 
		{
			if(intValues[i].valueName == name){return intValues[i].value;}
		}
		print ("The Int Value With The Name " + name + " Not Found");
		return -1111111;
	}
	
	public void SetInt(String name,int value)
	{
		for (int i = 0; i < intValues.Count; i++) 
		{
			if(intValues[i].valueName == name){intValues[i].value = value; return;}
		}
		IntValue intValue = new IntValue ();
		intValue.valueName = name;
		intValue.value = value;
		intValues.Add (intValue);
	}
	
	
	public bool GetBool(String name)
	{
		for (int i = 0; i < boolValues.Count; i++) 
		{
			if(boolValues[i].valueName == name){return boolValues[i].value;}
		}
		print ("The Bool Value With The Name " + name + " Not Found");
		return false;
	}
	
	public void SetBool(String name,bool value)
	{
		for (int i = 0; i < boolValues.Count; i++) 
		{
			if(boolValues[i].valueName == name){boolValues[i].value = value; return;}
		}
		BoolValue boolValue = new BoolValue ();
		boolValue.valueName = name;
		boolValue.value = value;
		boolValues.Add (boolValue);
	}
	
	
	public tk2dTextMesh GetTextMesh(String name)
	{
		for (int i = 0; i < textMeshReferences.Count; i++) 
		{
			if(textMeshReferences[i].referenceName == name){return textMeshReferences[i].reference;}
		}
		return null;
	}
	
	public void SetTextMesh(String name,tk2dTextMesh reference)
	{
		for (int i = 0; i < textMeshReferences.Count; i++) 
		{
			if(textMeshReferences[i].referenceName == name){textMeshReferences[i].reference = reference; return;}
		}
		TextMeshReference textMeshReference = new TextMeshReference ();
		textMeshReference.referenceName = name;
		textMeshReference.reference = reference;
		textMeshReferences.Add (textMeshReference);
	}
	
	
	public tk2dSprite GetSprite(String name)
	{
		for (int i = 0; i < spriteReferences.Count; i++) 
		{
			if(spriteReferences[i].referenceName == name){return spriteReferences[i].reference;}
		}
		return null;
	}
	
	public void SetSprite(String name,tk2dSprite reference)
	{
		for (int i = 0; i < spriteReferences.Count; i++) 
		{
			if(spriteReferences[i].referenceName == name){spriteReferences[i].reference = reference; return;}
		}
		SpriteReference spriteReference = new SpriteReference ();
		spriteReference.referenceName = name;
		spriteReference.reference = reference;
		spriteReferences.Add (spriteReference);
	}
	
	
	public tk2dTiledSprite GetTiledSprite(String name)
	{
		for (int i = 0; i < tiledSpriteReferences.Count; i++) 
		{
			if(tiledSpriteReferences[i].referenceName == name){return tiledSpriteReferences[i].reference;}
		}
		return null;
	}
	
	public void SetTiledSprite(String name,tk2dTiledSprite reference)
	{
		for (int i = 0; i < tiledSpriteReferences.Count; i++) 
		{
			if(tiledSpriteReferences[i].referenceName == name){tiledSpriteReferences[i].reference = reference; return;}
		}
		TiledSpriteReference tiledSpriteReference = new TiledSpriteReference ();
		tiledSpriteReference.referenceName = name;
		tiledSpriteReference.reference = reference;
		tiledSpriteReferences.Add (tiledSpriteReference);
	}
	
	
	public tk2dSlicedSprite GetSlicedSprite(String name)
	{
		for (int i = 0; i < slicedSpriteReferences.Count; i++) 
		{
			if(slicedSpriteReferences[i].referenceName == name){return slicedSpriteReferences[i].reference;}
		}
		return null;
	}
	
	public void SetSlicedSprite(String name,tk2dSlicedSprite reference)
	{
		for (int i = 0; i < slicedSpriteReferences.Count; i++) 
		{
			if(slicedSpriteReferences[i].referenceName == name){slicedSpriteReferences[i].reference = reference; return;}
		}
		SlicedSpriteReference slicedSpriteReference = new SlicedSpriteReference ();
		slicedSpriteReference.referenceName = name;
		slicedSpriteReference.reference = reference;
		slicedSpriteReferences.Add (slicedSpriteReference);
	}
	
	
	void UpdateFunctionNames () 
	{
		for (int i = 0; i < UiEvents.Count; i++) 
		{
			for (int j = 0; j < UiEvents[i].events.events.Length; j++) 
			{
				string finalValue = "";
				if(UiEvents[i].events.events[j].ev.parameters != null)
				{
					for (int k = 0; k < UiEvents[i].events.events[j].ev.parameters.Length; k++) 
					{
						string value = string.Empty;
						try   {value = UiEvents[i].events.events[j].ev.parameters[k].value.ToString();}
						catch {value = "Null,";}
						
						if(value.IndexOf(" (UnityEngine") > -1){value = value.Substring(0,value.IndexOf(" (UnityEngine"));}
						if(k != UiEvents[i].events.events[j].ev.parameters.Length - 1){value += ",";}
						finalValue += value;
					}
				}
				
				string evActive = string.Empty;
				string delay = string.Empty;
				string randomDelay = string.Empty;
				
				if(UiEvents[i].events.events[j].disable){evActive = "X ";}
				if(UiEvents[i].events.events[j].delay > 0){delay = UiEvents[i].events.events[j].delay.ToString() + " ";}
				if(UiEvents[i].events.events[j].randomDelay.Length > 0){randomDelay = "[" + UiEvents[i].events.events[j].randomDelay[0].ToString() + "," + UiEvents[i].events.events[j].randomDelay[1].ToString() + "] ";}
				
				string space = ". ";
				if(j > 9){space = "";}
				UiEvents[i].events.events[j].label = "" + j + space + "  " + evActive + delay + randomDelay + UiEvents[i].events.events[j].ev.methodName + " (" + finalValue + ")" + "  [" + UiEvents[i].events.events[j].ev.target.GetType() + "]";
			}
			
		}
	}
}

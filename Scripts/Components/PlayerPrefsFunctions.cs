using UnityEngine;
using System.Collections;

public class PlayerPrefsFunctions : MonoBehaviour {

	public static PlayerPrefsFunctions ins;
	void Awake(){ins = this;}

	public void InvokeGuiReicieverOnFingerUpIfPlayerPrefVarMatchesToString (GuiRayReceiver guiRayReceiver,string playerPrefsVarName,string stringToMatchTo) 
	{
		if(PlayerPrefs.GetString(playerPrefsVarName) == stringToMatchTo)
		{
			guiRayReceiver.onFingerUp.Invoke(guiRayReceiver.gameObject);
		}
	}


	public void ActivateGameObjectIfPlayerPrefVarMatchesString (GameObject GameObjectToActivate,string PlayerPrefsVarName,string StringToMatchTo) 
	{
		if(PlayerPrefs.GetString(PlayerPrefsVarName) == StringToMatchTo)
		{
			GameObjectToActivate.SetActive(true);
		}
	}

	public void ActivateGameObjectIfTxtGreaterThanPlayerPrefVar (GameObject objectToActivate,tk2dTextMesh txt,string playerPrefVar) 
	{
		if(int.Parse(txt.text) > int.Parse(PlayerPrefs.GetString(playerPrefVar)))
		{
			objectToActivate.SetActive(true);
		}
	}

	public void DeactivateGameObjectIfPlayerPrefVarMatchesString (GameObject GameObjectToActivate,string PlayerPrefsVarName,string StringToMatchTo) 
	{
		if(PlayerPrefs.GetString(PlayerPrefsVarName) == StringToMatchTo)
		{
			GameObjectToActivate.SetActive(false);
		}
	}

	public void SetPlayerPrefVar (string PlayerPrefsVarName,string PlayerPrefsVarValue) 
	{
		PlayerPrefs.SetString(PlayerPrefsVarName,PlayerPrefsVarValue);
		PlayerPrefs.Save();
	}

	public void SetPlayerPrefVarIfUnset (string PlayerPrefsVarName,string PlayerPrefsVarValue) 
	{
		if(!PlayerPrefs.HasKey(PlayerPrefsVarName))
		{
			PlayerPrefs.SetString(PlayerPrefsVarName,PlayerPrefsVarValue);
			PlayerPrefs.Save();
		}
	}
	
	public void SetPlayerPrefIfLessThanIntValue (string PlayerPrefsVarName,int value) 
	{
		int playerPrefsVar = int.Parse (PlayerPrefs.GetString(PlayerPrefsVarName));
		if(playerPrefsVar < value)
		{
			PlayerPrefs.SetString(PlayerPrefsVarName,value.ToString());
			PlayerPrefs.Save();
		}
	}
	
	public void SetPlayerPrefIfLessThanTxt (string PlayerPrefsVarName,tk2dTextMesh txt) 
	{
		int value = int.Parse (txt.text);
		int playerPrefsVar = int.Parse (PlayerPrefs.GetString(PlayerPrefsVarName));
		if(playerPrefsVar < value)
		{
			PlayerPrefs.SetString(PlayerPrefsVarName,value.ToString());
			PlayerPrefs.Save();
		}
	}
	
	public void SetTxtFromPlayerPrefs (tk2dTextMesh tk2dTextMesh,string PlayerPrefsVarName,string prefix,string suffix) 
	{
		tk2dTextMesh.text = prefix + PlayerPrefs.GetString (PlayerPrefsVarName) + suffix;
	}
}

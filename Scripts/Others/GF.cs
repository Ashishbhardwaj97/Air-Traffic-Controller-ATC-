using UnityEngine;
using System.Collections;
using PathologicalGames;
using System;

public class GF : MonoBehaviour {

	//public SR SR;
	public static GF instance;
	public Transform aaa;


	void Awake () 
	{

		instance = this;
	}


	void Start () {
	}
	//{if(SR == null){SR = GameObject.Find("Scripts_Reference").GetComponent<SR>();}}
	
	void Update () 
	{

	}

	private IEnumerator hide_splash_screen() 
	{
		yield return new WaitForSeconds(2f);
		//GSF_CP_script.build_chord_progression (GM_script.active_scale);
	}

	public void wait_and_perform(float wait_time,string subject,Transform identity) 
	{
		StartCoroutine (wait_and_perform_coroutine( wait_time, subject, identity));
	}

	private IEnumerator wait_and_perform_coroutine(float wait_time,string subject,Transform identity) 
	{
		yield return new WaitForSeconds(wait_time);
		//if(subject == "animating")
		//{identity.GetComponent<tags>().animating = false;}
	}

	public Transform instantiate (string name,Vector3 position,Transform parent = null,string pool_name = "common") 
	{
		Transform object_prefab = PoolManager.Pools[pool_name].prefabs[name];
		Transform object_instance = PoolManager.Pools[pool_name].Spawn(object_prefab);
		if(parent != null){object_instance.parent = parent;}
		//object_instance.position = position;
		object_instance.localPosition = position;
		return object_instance;
	}

	public Transform instantiate_txt (string name,Vector3 position,string content,Vector3 size,Transform parent = null,string pool_name = "common") 
	{
		Transform object_instance = instantiate (name,position,parent,pool_name);
		tk2dTextMesh object_instance_tk2dTextMesh_script = object_instance.GetComponent<tk2dTextMesh> ();
		object_instance_tk2dTextMesh_script.text = content;
		object_instance_tk2dTextMesh_script.scale = size;
		return object_instance;
	}

	public void despawn (Transform objectToDespawn,string pool_name = "common") 
	{
		objectToDespawn.parent = GM.instance.pool_manager;
		PoolManager.Pools[pool_name].Despawn(objectToDespawn);
	}

	public void despawn_by_tag (string tag_name,string pool_name = "common") 
	{
		GameObject[] temp = GameObject.FindGameObjectsWithTag(tag_name);
		for(int i = 0; i < temp.Length; i++)
		{
			if(temp[i].transform.gameObject.activeInHierarchy)
			{
				PoolManager.Pools[pool_name].Despawn(temp[i].transform);
				temp[i].transform.parent = GM.instance.pool_manager;
			}
		}
	}

	public void wait_and_despawn (Transform object_to_despawn,float wait_time,string pool_name = "common") 
	{
		StartCoroutine (wait_and_despawn_coroutine(object_to_despawn,wait_time,pool_name));
	}

	private IEnumerator wait_and_despawn_coroutine(Transform object_to_despawn,float wait_time,string pool_name) 
	{
		yield return new WaitForSeconds(wait_time);
		PoolManager.Pools[pool_name].Despawn(object_to_despawn);
		object_to_despawn.parent = GM.instance.pool_manager;
	}

	public int find_no_of_slots(string txt,string separator)
	{
		int i = 0;
		for (i = 0; txt.IndexOf(separator) > -1; i++)
		{
			txt.Remove(txt.IndexOf(separator),separator.Length);
		}
		return i;
	}


	public int ParseInt(string value)
	{
		int result = 0;
		for (int i = 0; i < value.Length; i++)
		{
			char letter = value[i];
			result = 10 * result + (letter - 48);
		}
		return result;
	}


	public Transform animate_position(Transform transform_to_animate,Vector3 from,Vector3 destination,float time,float wait_before_animating,string easing ,string which_transform,string function_to_run_on_animation_complete = null ,string from_mode = null,string destination_mode = null,bool check_for_animating = false) 
	{
		Transform script_anims_helper = instantiate ("script_anims_helper",new Vector3(0,0,0));
		script_anims_helper.GetComponent<script_anims> ().animate_position (transform_to_animate,from,destination,time,wait_before_animating,easing,which_transform,function_to_run_on_animation_complete,from_mode,destination_mode,check_for_animating);
		return script_anims_helper;
	}


	public ScriptAnims AnimateTransform(Transform transformToAnimate,Vector3 from,Vector3 destination,float time,string whichTransform = "Position",bool snapAllAxis = true,string easing = "Linear",float waitBeforeAnimating = 0,Action functionToRunOnAnimationComplete = null,string fromMode = null,string destinationMode = null) 
	{
		ScriptAnims scriptAnims = instantiate ("ScriptAnims",new Vector3(0,0,0)).GetComponent<ScriptAnims>();
		scriptAnims.AnimateTransform (transformToAnimate,from,destination,time,whichTransform,snapAllAxis,easing,waitBeforeAnimating,functionToRunOnAnimationComplete,fromMode,destinationMode);
		return scriptAnims;
	}

	public bool HasConnection()
	{
		#if UNITY_WP8
		return true;
		#endif
		#if UNITY_ANDROID
		//return true;
		try
		{
			System.Net.IPHostEntry i = System.Net.Dns.GetHostEntry("www.google.com");
			return true;
		}
		catch
		{
			return false;
		}
		#endif
		return true;
	}


}






















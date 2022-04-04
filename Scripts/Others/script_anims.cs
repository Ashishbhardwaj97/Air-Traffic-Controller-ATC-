using UnityEngine;
using System.Collections;

public class script_anims : MonoBehaviour {


	public static script_anims instance;
	public float anim_value;
	private Transform self_transform;
	private bool execute = true;
	//private tags tags_script = null;
	private float recorded_x;
	private float recorded_y;
	private float recorded_z;
	
	private float amount_x;
	private float amount_y;
	private float amount_z;
	private Vector3 temp_vector_3;
	private int i;




	void Awake () 
	{

		instance = this;
	}

	void Start () 
	{
		self_transform = transform;
		//if(SR == null){SR = GameObject.Find("Scripts_Reference").GetComponent<SR>();}
	}
	
	void Update ()
	{
	
	}

	public void animate_position(Transform transform_to_animate,Vector3 from,Vector3 destination,float time,float wait_before_animating,string easing ,string which_transform,string function_to_run_on_animation_complete = null ,string from_mode = null,string destination_mode = null,bool check_for_animating = false) 
	{
		StartCoroutine (animate_position_coroutine(transform_to_animate,from,destination,time,wait_before_animating,easing,which_transform,function_to_run_on_animation_complete,from_mode,destination_mode,check_for_animating));
	}
	
	
	private IEnumerator animate_position_coroutine(Transform transform_to_animate,Vector3 from ,Vector3 destination ,float time,float wait_before_animating,string easing ,string which_transform,string function_to_run_on_animation_complete = null ,string from_mode = null,string destination_mode = null,bool check_for_animating = false) 
	{
		execute = true;
		//tags_script = null;
		if(check_for_animating)
		{
			//tags_script = transform_to_animate.GetComponent<tags> ();
			//if(tags_script != null)
			//{
				//if(tags_script.animating){execute = false;}
				//else{tags_script.animating = true;}
			//}
		}
		if(execute)
		{
			yield return new WaitForSeconds(wait_before_animating);
			if(which_transform == "position")
			{
				if(from_mode == "w")
				{
					self_transform.parent = transform_to_animate.parent;
					self_transform.position = from;
					from = self_transform.localPosition;
				}
				
				if(destination_mode == "w")
				{
					self_transform.parent = transform_to_animate.parent;
					self_transform.position = destination;
					destination = self_transform.localPosition;
				}
			}
			
			temp_vector_3 = new Vector3 (0,0,0);
			if(which_transform == "position") {transform_to_animate.localPosition = from;    temp_vector_3 = transform_to_animate.localPosition;}
			if(which_transform == "rotation") {transform_to_animate.localEulerAngles = from; temp_vector_3 = transform_to_animate.localEulerAngles;}
			if(which_transform == "scale")    {transform_to_animate.localScale = from;       temp_vector_3 = transform_to_animate.localScale;}
			
			recorded_x = temp_vector_3.x;
			recorded_y = temp_vector_3.y;
			recorded_z = temp_vector_3.z;
			
			amount_x = destination.x - recorded_x;
			amount_y = destination.y - recorded_y;
			amount_z = destination.z - recorded_z;
			
			
			GetComponent<Animation>() [easing].speed = 1/time;
			GetComponent<Animation>().Play (easing);
			//if(tags_script != null){tags_script.animating = true;}
			anim_value = 0;
			
			for(i = 0; GetComponent<Animation>().IsPlaying(easing) && GM.instance.script_anims_active; i++)
			{  //print (anim_value);
				if(which_transform == "position") {temp_vector_3 = transform_to_animate.localPosition;}
				if(which_transform == "rotation") {temp_vector_3 = transform_to_animate.localEulerAngles;}
				if(which_transform == "scale")    {temp_vector_3 = transform_to_animate.localScale;}
				
				if(amount_x == 0){recorded_x = temp_vector_3.x;}
				if(amount_y == 0){recorded_y = temp_vector_3.y;}
				if(amount_z == 0){recorded_z = temp_vector_3.z;}
				
				if(which_transform == "position") {transform_to_animate.localPosition = new Vector3(recorded_x + amount_x*anim_value,recorded_y + amount_y*anim_value,recorded_z + amount_z*anim_value);}
				if(which_transform == "rotation") {transform_to_animate.localEulerAngles = new Vector3(recorded_x + amount_x*anim_value,recorded_y + amount_y*anim_value,recorded_z + amount_z*anim_value);}
				if(which_transform == "scale") {transform_to_animate.localScale = new Vector3(recorded_x + amount_x*anim_value,recorded_y + amount_y*anim_value,recorded_z + amount_z*anim_value);}
				yield return null;
			}
			
			GetComponent<Animation>().Stop (easing);
			anim_value = 1;
			if(which_transform == "position") {transform_to_animate.localPosition = new Vector3(recorded_x + amount_x*anim_value,recorded_y + amount_y*anim_value,recorded_z + amount_z*anim_value);}
			if(which_transform == "rotation") {transform_to_animate.localEulerAngles = new Vector3(recorded_x + amount_x*anim_value,recorded_y + amount_y*anim_value,recorded_z + amount_z*anim_value);}
			if(which_transform == "scale") {transform_to_animate.localScale = new Vector3(recorded_x + amount_x*anim_value,recorded_y + amount_y*anim_value,recorded_z + amount_z*anim_value);}
			//if(check_for_animating){if(tags_script != null){tags_script.animating = false;}}
			GF.instance.despawn(self_transform);
			
			if (function_to_run_on_animation_complete == "despawn") {GF.instance.despawn(transform_to_animate);}
			if (function_to_run_on_animation_complete == "hide") {transform_to_animate.gameObject.SetActive(false);}
			if (function_to_run_on_animation_complete == "despawn_chords") 
			{
				for(i = 0; transform_to_animate.GetChild(3).GetChild(0).GetChild(0).childCount > 0 ; )
				{GF.instance.despawn(transform_to_animate.GetChild(3).GetChild(0).GetChild(0).GetChild(0));}
				 GF.instance.despawn(transform_to_animate);
			}
			
		}
	}

}

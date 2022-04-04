using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PathologicalGames;

public class CommonFunctions : MonoBehaviour 
{
	public static CommonFunctions instance; 
	void Awake() {instance = this;}

	void Start()
	{
		//PlayerPrefs.DeleteAll ();
	}

	void Update()
	{
	}


	public void print_(string value){print (value);}




	public void SetTimeScale(float value){Time.timeScale = value;}


	public void GameExit()
	{
		Application.Quit ();
	}

	public void NeverSleep()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}


	public void SetTxt (tk2dTextMesh tk2dTextMesh,string value_1,string value_2) 
	{
		tk2dTextMesh.text = value_1 + value_2;
	}

	public void SetTxtFromTxt (tk2dTextMesh txtToSet,tk2dTextMesh setFrom) 
	{
		txtToSet.text = setFrom.text;
	}

	public void IncrementTxtAndSetPlayerPrefVarIfTxtActive (tk2dTextMesh txt,int incrementAmount,string playerPrefVar) 
	{
		if(txt.gameObject.activeInHierarchy)
		{
			int txtConvertedToInt = int.Parse(txt.text);
			txtConvertedToInt += incrementAmount;
			txt.text = txtConvertedToInt.ToString();
			if(!string.IsNullOrEmpty(playerPrefVar))
			{
				int playerPrefVarConvertedToInt = int.Parse(PlayerPrefs.GetString(playerPrefVar));
				if(txtConvertedToInt > playerPrefVarConvertedToInt)
				{
					PlayerPrefs.SetString(playerPrefVar,txtConvertedToInt.ToString());
					PlayerPrefs.Save();
				}
			}
		}
	}



	public void SetTimScale (float from,float to,float time) 
	{
		StartCoroutine (SetTimScaleCoroutine(from,to,time));
	}

	IEnumerator SetTimScaleCoroutine (float from,float to,float time) 
	{
		if(time > 0)
		{
			float lerpValue = 0;
			while (lerpValue < 1) 
			{
				lerpValue += (1/time)*Time.deltaTime;
				Time.timeScale = Mathf.Lerp(from,to,lerpValue);
				yield return null;
			}
		}
		else{Time.timeScale = to;}
	}



	public void Spawn (string poolName,string objectName,Vector3 spawnPosition,Vector3 spawnAngle) 
	{
		Transform objectPrefab = PoolManager.Pools[poolName].prefabs[objectName];
		Transform objectInstance = PoolManager.Pools[poolName].Spawn(objectPrefab);
		objectInstance.position = spawnPosition;
		objectInstance.eulerAngles = spawnAngle;
	}

	public void DespawnByTag (string tag,string poolName) 
	{
		GameObject[] temp = GameObject.FindGameObjectsWithTag(tag);
		for(int i = 0; i < temp.Length; i++)
		{
			if(temp[i].transform.gameObject.activeInHierarchy)
			{
				PoolManager.Pools[poolName].Despawn(temp[i].transform);
			}
		}
	}

	public void DespawnCollisionDetector (CollisionDetector collisionDetector,string poolName) 
	{
		PoolManager.Pools[poolName].Despawn(collisionDetector.transform);
	}



	public void SetVelocityZero (Rigidbody rigidbody) 
	{
		rigidbody.velocity = Vector3.zero;
	}

	public void ApplyForce (Rigidbody rigidbody,Vector3 amountRange_0,Vector3 amountRange_1) 
	{
		rigidbody.AddForce (new Vector3(Random.Range(amountRange_0.x,amountRange_1.x),Random.Range(amountRange_0.y,amountRange_1.y),Random.Range(amountRange_0.z,amountRange_1.z)));
	}


	public void ApplyRelativeForce (Rigidbody rigidbody,Vector3 amountRange_0,Vector3 amountRange_1) 
	{
		rigidbody.AddRelativeForce (new Vector3(Random.Range(amountRange_0.x,amountRange_1.x),Random.Range(amountRange_0.y,amountRange_1.y),Random.Range(amountRange_0.z,amountRange_1.z)));
	}

	public void ApplyAngularForce (Rigidbody rigidbody,Vector3 amountRange_0,Vector3 amountRange_1) 
	{
		rigidbody.angularVelocity = new Vector3(Random.Range(amountRange_0.x,amountRange_1.x),Random.Range(amountRange_0.y,amountRange_1.y),Random.Range(amountRange_0.z,amountRange_1.z));
	}

	public void SetEulerAngles (Transform subject,Vector3 eulerAngles) 
	{
		subject.eulerAngles = eulerAngles;
	}


	public static void SnapTransform (Transform snapObject,Transform snapTo,bool matchRotation = false) 
	{
		snapObject.position = snapTo.position;
		if(matchRotation){snapObject.eulerAngles = snapTo.eulerAngles;}
	}

	public void FadeOutSprite(tk2dSprite sprite,float time,float amount){instance.StartCoroutine (FadeOutSpriteCoroutine(sprite,time,amount));}
	
	private IEnumerator FadeOutSpriteCoroutine(tk2dSprite sprite,float time,float amount)
	{
		float value = sprite.color.a; 
		float speed = 1/time; 
		//GM.instance.transitionPlane.gameObject.SetActive (true);
		while(value < amount)
		{
			value += speed*Time.deltaTime;
			if(value > amount){value = amount;}
			sprite.color = new Color(sprite.color.r,sprite.color.g,sprite.color.b,value);
			yield return null;
		}
	}

	public void FadeInSprite(tk2dSprite sprite,float time,float amount){instance.StartCoroutine (FadeInSpriteCoroutine(sprite,time,amount));}
	
	private IEnumerator FadeInSpriteCoroutine(tk2dSprite sprite,float time,float amount)
	{
		float value = sprite.color.a; 
		float speed = 1/time; 
		//GM.instance.transitionPlane.gameObject.SetActive (true);
		while(value > amount)
		{
			value -= speed*Time.deltaTime;
			if(value < amount){value = amount;}
			sprite.color = new Color(sprite.color.r,sprite.color.g,sprite.color.b,value);
			yield return null;
		}
	}




	public void FadeOutRenderer(Renderer renderer,float time,float amount){instance.StartCoroutine (FadeOutRendererCoroutine(renderer,time,amount));}
	
	private IEnumerator FadeOutRendererCoroutine(Renderer renderer,float time,float amount)
	{
		float value = renderer.material.color.a; 
		float speed = 1/time; 
		//GM.instance.transitionPlane.gameObject.SetActive (true);
		while(value < amount)
		{
			value += speed*Time.deltaTime;
			if(value > amount){value = amount;}
			renderer.material.color = new Color(renderer.material.color.r,renderer.material.color.g,renderer.material.color.b,value);
			yield return null;
		}
	}
	
	public void FadeInRenderer(Renderer renderer,float time,float amount){instance.StartCoroutine (FadeInRendererCoroutine(renderer,time,amount));}
	
	private IEnumerator FadeInRendererCoroutine(Renderer renderer,float time,float amount)
	{
		float value = renderer.material.color.a; 
		float speed = 1/time; 
		//GM.instance.transitionPlane.gameObject.SetActive (true);
		while(value > amount)
		{
			value -= speed*Time.deltaTime;
			if(value < amount){value = amount;}
			renderer.material.color = new Color(renderer.material.color.r,renderer.material.color.g,renderer.material.color.b,value);
			yield return null;
		}
	}
	
	
	





	public void QuitApp(){Application.Quit ();}

	public void RotateZ(Transform subject,float amount)
	{
		subject.Rotate (0,0,amount);
	}

	public void SetLocalPosXIfDeceedLocalPosX_(Transform subject,Transform subject_,float setTo,float limit){if(subject_.localPosition.x < limit){subject.localPosition = new Vector3(setTo,subject.localPosition.y,subject.localPosition.z);}}
	public void SetLocalPosition(Transform subject,Vector3 localPos){subject.localPosition = localPos;}
	public void SetLocalScale(Transform subject,Vector3 localScale){subject.localScale = localScale;}



	public void ActivateChilds(Transform parent){for (int i = 0; i < parent.childCount; i++) {parent.GetChild(i).gameObject.SetActive(true);}}
	public void ActivateChildIndex(Transform parent,int index){parent.GetChild(index).gameObject.SetActive(true);}


	public void ChildsMeshRendererActiveState(Transform parent,bool activeState){for (int i = 0; i < parent.childCount; i++) {parent.GetChild(i).GetComponent<MeshRenderer>().enabled = activeState;}}




	public class CoroutineBasedOnAudioSource
	{ 
		public AudioSource audioSource;
		public Coroutine coroutine;
	}
	
	void StopAdjustAudioVolumeBasedOnAnimationSpeed(AudioSource audioSource)
	{
		for (int i = 0; i < coroutinesBasedOnAudioSource.Count; i++) 
		{
			if(coroutinesBasedOnAudioSource[i].audioSource == audioSource)
			{
				StopCoroutine(coroutinesBasedOnAudioSource[i].coroutine);
				coroutinesBasedOnAudioSource.Remove(coroutinesBasedOnAudioSource[i]);
				break;
			}
		}
	}
	
	List<CoroutineBasedOnAudioSource> coroutinesBasedOnAudioSource = new List<CoroutineBasedOnAudioSource>();
	public void AdjustAudioVolumeBasedOnAnimationSpeed(AudioSource audio,Animation animComp,string animName,float percentage)
	{
		StopAdjustAudioVolumeBasedOnAnimationSpeed (audio);
		CoroutineBasedOnAudioSource coroutineBasedOnAudioSource = new CoroutineBasedOnAudioSource();
		coroutineBasedOnAudioSource.audioSource = audio;
		coroutineBasedOnAudioSource.coroutine = StartCoroutine (AdjustAudioVolumeBasedOnAnimationSpeedCoroutine(audio,animComp,animName,percentage));
		coroutinesBasedOnAudioSource.Add(coroutineBasedOnAudioSource);
	}
	
	IEnumerator AdjustAudioVolumeBasedOnAnimationSpeedCoroutine(AudioSource audio,Animation animComp,string animName,float percentage)
	{
		while (true) 
		{
			audio.volume = (animComp[animName].speed * percentage)/100;
			yield return null;
		}
	}

	public void StopSoundBasedOnAnimationSpeed()
	{
		if(playSoundContinuoslyBasedOnAnimationSpeedCoroutine != null){StopCoroutine (playSoundContinuoslyBasedOnAnimationSpeedCoroutine);}
	}

	private Coroutine playSoundContinuoslyBasedOnAnimationSpeedCoroutine;
	public void PlaySoundContinuoslyBasedOnAnimationSpeed(AudioClip sound,Animation animComp,string animName,float speed)
	{
		StopSoundBasedOnAnimationSpeed ();
		playSoundContinuoslyBasedOnAnimationSpeedCoroutine = StartCoroutine (PlaySoundContinuoslyBasedOnAnimationSpeedCoroutine(sound,animComp,animName,speed));
	}

	IEnumerator PlaySoundContinuoslyBasedOnAnimationSpeedCoroutine(AudioClip sound,Animation animComp,string animName,float speed)
	{
		while (true) 
		{
			if(animComp[animName].speed < 1f){SoundManager.instance.PlaySound(sound,1);}
			float amountIncreased = 0;
			while (amountIncreased < 1/speed) {amountIncreased += animComp[animName].speed * Time.deltaTime; yield return null; }
		}
	}

	public void SetGameObjectActiveState(GameObject subject,bool isActive)
	{
        if (subject != null)
        {
            subject.SetActive(isActive);
        }
	}

	public void SetGameObjectColliderActiveState(Transform subject,bool isActive)
	{
		subject.GetComponent<BoxCollider> ().enabled = isActive;
	}





	public void SetAnimationTime(Animation animationComp,string animationName,float time)
	{
		animationComp [animationName].time = time;
	}


	public class ChangeAnimationSpeedCoroutineNC
	{ 
		public Animation animComp;
		public Coroutine coroutine;
	}

	public void StopChangeAnimationSpeed(Animation animationComp)
	{
		for (int i = 0; i < changeAnimationSpeedCoroutines.Count; i++) 
		{
			if(changeAnimationSpeedCoroutines[i].animComp == animationComp)
			{
				StopCoroutine(changeAnimationSpeedCoroutines[i].coroutine);
				changeAnimationSpeedCoroutines.Remove(changeAnimationSpeedCoroutines[i]);
				break;
			}
		}
	}

	List<ChangeAnimationSpeedCoroutineNC> changeAnimationSpeedCoroutines = new List<ChangeAnimationSpeedCoroutineNC>();
	public void ChangeAnimationSpeed(Animation animationComp,string animationName,float finalSpeed,float distanceToAchieveFinalSpeed)
	{
		if(distanceToAchieveFinalSpeed > 0)
		{
			StopChangeAnimationSpeed(animationComp);
			ChangeAnimationSpeedCoroutineNC changeAnimationSpeedCoroutine = new ChangeAnimationSpeedCoroutineNC();
			changeAnimationSpeedCoroutine.animComp = animationComp;
			changeAnimationSpeedCoroutine.coroutine = StartCoroutine (ChangeAnimationSpeedCoroutine(animationComp,animationName,finalSpeed,distanceToAchieveFinalSpeed));
			changeAnimationSpeedCoroutines.Add(changeAnimationSpeedCoroutine);

		}
		else{animationComp [animationName].speed = finalSpeed;}
	}

	IEnumerator ChangeAnimationSpeedCoroutine(Animation animationComp,string animationName,float finalSpeed,float distanceToAchieveFinalSpeed)
	{
		float initialSpeed = animationComp [animationName].speed;
		float timeToAchieveFinalSpeed = distanceToAchieveFinalSpeed/(4*animationComp [animationName].speed);
		float amountIncreased = 0;
		while (amountIncreased < distanceToAchieveFinalSpeed) 
		{
			amountIncreased += animationComp [animationName].speed * 4 * Time.deltaTime;
			animationComp [animationName].speed = Mathf.Lerp(initialSpeed,finalSpeed,amountIncreased/distanceToAchieveFinalSpeed);
			yield return null; 
		}
	}

}

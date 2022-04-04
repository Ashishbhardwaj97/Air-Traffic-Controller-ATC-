using UnityEngine;
using System.Collections;
using PathologicalGames;


public class GM : MonoBehaviour {

	//GM stands for game manager
	public static GM instance;
	public Transform pool_manager;
	public Transform gui_manager;
	public Transform player;
	public Transform environments;
	public Camera gui_cam;
	public Camera game_cam;
	public Transform SkyBoxCam;
	public Transform notifications;
	public bool script_anims_active;

	public Transform active_coach;
	public bool player_spotted;

	void Awake () {

		instance = this;
	}

	void Start () 
	{
		
	}


	void Update () 
	{

	}

	public void CoinAnimation ( Vector3 instantiatePoint ){

		Transform coinAnimationPrefab = PoolManager.Pools["common"].prefabs["CoinsAnim"];
		Transform coinAnimationPrefabInstance = PoolManager.Pools ["common"].Spawn (coinAnimationPrefab);
		coinAnimationPrefabInstance.position = instantiatePoint;
		tk2dSpriteAnimator coinsAnim = coinAnimationPrefabInstance.GetChild (0).GetComponent<tk2dSpriteAnimator> ();
		coinsAnim.Stop ();
		coinsAnim.Play ("CoinsAnim");
		StartCoroutine (CoinAnimationCoroutine (coinAnimationPrefabInstance));
	

	}

	public void LevelBarFillingAnimation ( Vector3 instantiatePoint , Vector3 roatationMod) {

		Transform levelEffectPrefab = PoolManager.Pools["common"].prefabs["LevelBarFillingAnim"];
		Transform levelEffectPrefabInstance = PoolManager.Pools ["common"].Spawn (levelEffectPrefab);
		levelEffectPrefabInstance.position = instantiatePoint;
		levelEffectPrefabInstance.transform.eulerAngles = roatationMod;
		tk2dSpriteAnimator LevelBarFillingAnim = levelEffectPrefabInstance.GetChild (0).GetComponent<tk2dSpriteAnimator> ();
		LevelBarFillingAnim.Stop ();
		LevelBarFillingAnim.Play ("LevelIncreaseEffectAnimation");
		StartCoroutine (LevelBarFillingAnimationCoroutine (levelEffectPrefabInstance));
	} 

	public IEnumerator CoinAnimationCoroutine (Transform coinAnimationPrefabInstance){

		yield return new WaitForSeconds (1f);
		PoolManager.Pools ["common"].Despawn (coinAnimationPrefabInstance);
	}

	public IEnumerator LevelBarFillingAnimationCoroutine (Transform levelEffectPrefabInstance){

		yield return new WaitForSeconds (1f);
		PoolManager.Pools ["common"].Despawn (levelEffectPrefabInstance);
	}

}




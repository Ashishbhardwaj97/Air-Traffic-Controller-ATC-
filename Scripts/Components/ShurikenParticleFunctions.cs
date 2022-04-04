using UnityEngine;
using System.Collections;

public class ShurikenParticleFunctions : MonoBehaviour 
{
	public static ShurikenParticleFunctions instance; 
	void Awake() {instance = this;}

	public void SetAllChildsParticleStartColor(Transform parent,Color startColor)
	{
		for (int i = 0; i < parent.childCount; i++) 
		{
			SetAllChildsParticleStartColor(parent.GetChild(i),startColor);
			ParticleSystem particleSystem = parent.GetChild(i).GetComponent<ParticleSystem>();
			if(particleSystem != null){particleSystem.startColor = startColor;}
		}
	}



	void Start () 
	{
	
	}
	
	void Update () 
	{
	
	}
}

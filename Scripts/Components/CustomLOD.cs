using UnityEngine;
using System.Collections;

public class CustomLOD : MonoBehaviour {

	public Transform calculateDistanceFrom;
	public Transform selfTransform;
	public MeshFilter meshFilter;
	public SkinnedMeshRenderer skinnedMeshRenderer;
	public GameObject[] LOD_Objects;
	public Mesh[] LOD_Meshes;

	public float[] LOD_Distances;

	void Awake () 
	{
		if(selfTransform == null){selfTransform = transform;}
	}

	void OnEnable () 
	{
		StartCoroutine ("Initiate");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float distanceFromCamera;
	IEnumerator Initiate()
	{
		yield return new WaitForEndOfFrame ();
		if(LOD_Objects.Length > 0)
		{
			while (true) 
			{
				for (int i = 0; i < LOD_Objects.Length; i++) {if(LOD_Objects[i] != null){LOD_Objects[i].SetActive(false);}}
				
				for (int i = 0; i < LOD_Objects.Length; i++) 
				{
					if(i == LOD_Objects.Length - 1){if(LOD_Objects[i] != null){LOD_Objects[i].SetActive(true);} break;}
					distanceFromCamera = Vector3.Distance(calculateDistanceFrom.position,selfTransform.position);
					if(distanceFromCamera < LOD_Distances[i])
					{
						if(LOD_Objects[i] != null){LOD_Objects[i].SetActive(true);}
						break;
					}
				}
				
				yield return new WaitForSeconds(Random.Range(.45f,.95f));
			}

		}

		if(LOD_Meshes.Length > 0)
		{
			while (true) 
			{
				for (int i = 0; i < LOD_Meshes.Length; i++) 
				{
					if(i == LOD_Meshes.Length - 1)
					{
						if(LOD_Meshes[i] != null)
						{
							if(meshFilter != null){meshFilter.mesh = LOD_Meshes[i];}
							if(skinnedMeshRenderer != null){skinnedMeshRenderer.sharedMesh = LOD_Meshes[i];}
						} 
						break;}
					distanceFromCamera = Vector3.Distance(calculateDistanceFrom.position,selfTransform.position);
					if(distanceFromCamera < LOD_Distances[i])
					{
						if(LOD_Meshes[i] != null)
						{
							if(meshFilter != null){meshFilter.mesh = LOD_Meshes[i];}
							if(skinnedMeshRenderer != null){skinnedMeshRenderer.sharedMesh = LOD_Meshes[i];}
						}
						break;
					}
				}
				
				yield return new WaitForSeconds(Random.Range(.45f,.95f));
			}
			
		}

	}
}

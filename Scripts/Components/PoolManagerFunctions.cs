using UnityEngine;
using System.Collections;
using PathologicalGames;

public class PoolManagerFunctions : MonoBehaviour
{
	public static PoolManagerFunctions instance; 
	void Awake() {instance = this;}


	public void SpawnAndSetVelocity (string poolName,string objectName,Vector3 spawnPosition,Vector3 spawnAngle,Rigidbody velocityObject,Rigidbody angularVelocityObject,Transform objectParent = null) 
	{
		Rigidbody spawnedObject = Spawn (poolName,objectName,spawnPosition,spawnAngle).GetComponent<Rigidbody>();
		if(velocityObject != null){spawnedObject.velocity = velocityObject.velocity;}
		if(angularVelocityObject != null){spawnedObject.angularVelocity = angularVelocityObject.angularVelocity;}
	}

	[HideInInspector] public Rigidbody justSpawnedRigidbody;
	public void SpawnRigidbody (string poolName,string objectName,Vector3 spawnPosition,Vector3 spawnAngle,Transform objectParent = null) 
	{
		justSpawnedRigidbody = Spawn (poolName,objectName,spawnPosition,spawnAngle,objectParent).GetComponent<Rigidbody>();
	}


	[HideInInspector] public Transform justSpawnedTransform;
	[HideInInspector] public Vector3 justSpawnedTransformLocalPosition;
	public Transform Spawn (string poolName,string objectName,Vector3 spawnPosition,Vector3 spawnAngle,Transform objectParent = null) 
	{
		Transform objectPrefab = PoolManager.Pools[poolName].prefabs[objectName];
		justSpawnedTransform = PoolManager.Pools[poolName].Spawn(objectPrefab);
		justSpawnedTransform.position = spawnPosition;
		justSpawnedTransform.eulerAngles = spawnAngle;
		if(objectParent != null){justSpawnedTransform.parent = objectParent;}
		justSpawnedTransformLocalPosition = justSpawnedTransform.localPosition;
		return justSpawnedTransform;
	}

	public void Despawn (string poolName,Transform transformToDespawn) 
	{
		PoolManager.Pools[poolName].Despawn(transformToDespawn);
	}

	public void SpawnParticleAndSetAllChildsStartColor (string objectName,Color startColor,Vector3 spawnPosition,Vector3 spawnAngle) 
	{
		Transform objectPrefab = PoolManager.Pools["Particles"].prefabs[objectName];
		Transform objectInstance = PoolManager.Pools["Particles"].Spawn(objectPrefab);
		objectInstance.position = spawnPosition;
		objectInstance.eulerAngles = spawnAngle;
		ShurikenParticleFunctions.instance.SetAllChildsParticleStartColor (objectInstance,startColor);
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


}

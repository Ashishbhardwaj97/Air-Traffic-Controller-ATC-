using UnityEngine;
using System.Collections;

class AnimateTiledTexture : MonoBehaviour
{
	public int columns = 2;
	public int rows = 2;
	public float framesPerSecond = 10f;
	
	//the current frame to display
	private int index = 0;
	public float uSpeed = 2;
	public float vSpeed = 2;
	void OnEnable()
	{
		StartCoroutine(updateTiling());
		
		//set the tile size of the texture (in UV units), based on the rows and columns
		Vector2 size = new Vector2(1f / columns, 1f / rows);
		//GetComponent<Renderer>().sharedMaterial.SetTextureScale("_MainTex", size);
	}
	
	private IEnumerator updateTiling()
	{
		float xAmount = 0;
		float yAmount = 0;
		while (true)
		{
			//move to the next index
			index++;
			if (index >= rows * columns)
				index = 0;
			
			//split into x and y indexes
			Vector2 offset = new Vector2((float)index / columns - (index / columns), //x index
			                             (index / columns) / (float)rows);          //y index


			xAmount += uSpeed*Time.deltaTime;
			yAmount += vSpeed*Time.deltaTime;


			GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", new Vector2(xAmount,yAmount));
			
			yield return null;
		}
		
	}
}
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public string sceneName;

	public Transform loadingBar;

	void Start () 
	{
		//SceneManager.LoadScene (sceneName);
		StartCoroutine (loadAsync(sceneName));
	}

	private IEnumerator loadAsync(string levelName)
	{
		AsyncOperation operation = Application.LoadLevelAdditiveAsync(levelName);
		while(!operation.isDone) {
			yield return operation.isDone;

			loadingBar.localScale = new Vector3(operation.progress,1,1);
		}
		loadingBar.localScale = new Vector3(1,1,1);

		yield return new WaitForSeconds (.5f);

		Destroy (gameObject);
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[ExecuteInEditMode]
public class WaypointSystem : MonoBehaviour {

#if UNITY_EDITOR
	public List<Transform> waypoints = new List<Transform> ();
	public Color routeColor;
	int index = 0;

	void Update () {
		if (!Application.isPlaying) {
			Transform[] tem = GetComponentsInChildren<Transform> ();

			if (tem.Length > 0) {
				waypoints.Clear ();

				index = 0;

				foreach (Transform t in tem) {
					if (t != transform) {

						waypoints.Add (t);

						index++;
					}
				}

			}
		}
	}


	void OnDrawGizmos()
	{

		if (waypoints.Count > 0) {
			foreach(Transform point in waypoints) {
			Handles.Label(point.position+new Vector3(0,1.5f,0), point.name);
			}
			Gizmos.color = routeColor;

			foreach (Transform t in waypoints)
				Gizmos.DrawSphere (t.position, 0.5f);

			Gizmos.color = routeColor;

			for (int a = 0; a < waypoints.Count - 1; a++)
				Gizmos.DrawLine (waypoints [a].position, waypoints [a + 1].position);
		}
	}
#endif
}

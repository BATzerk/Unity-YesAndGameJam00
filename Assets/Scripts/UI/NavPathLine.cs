using UnityEngine;
using System.Collections;

public class NavPathLine : MonoBehaviour {
	// Constants
	private Color lineColorCompletePath = new Color (70/255f, 220/255f, 255/255f, 0.8f);
	private Color lineColorIncompletePath = new Color (255/255f, 50/255f, 130/255f, 0.6f);
	// Components
	[SerializeField] private LineRenderer lineRenderer;
	[SerializeField] private MeshRenderer destinationMeshRenderer; // the thing we put exactly where the destination point is.


	// ----------------------------------------------------------------
	//  Doers
	// ----------------------------------------------------------------
	public void UpdateLinesFromPath (NavMeshPath path) {
		lineRenderer.SetVertexCount (path.corners.Length);
		lineRenderer.SetPositions (path.corners);
		// Set the color based on if it's possible or not.
		Color lineColor = path.status == NavMeshPathStatus.PathComplete ? lineColorCompletePath : lineColorIncompletePath;
		lineRenderer.material.color = lineColor;

		// destinationMeshRenderer!
		if (path.corners.Length > 0) {
			destinationMeshRenderer.enabled = true;
			destinationMeshRenderer.transform.localPosition = path.corners [path.corners.Length-1];
		}
		else {
			destinationMeshRenderer.enabled = false;
		}
	}



}

using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {
	// Constants
	private Color fillColor0 = new HSBColor (5/360f, 0.92f, 0.68f).ToColor ();
	private Color fillColor1 = new HSBColor (46/360f, 0.98f, 0.84f).ToColor ();
	private Color fillColor2 = new HSBColor (79/360f, 1f, 0.75f).ToColor ();
	private Color fillColor3 = new HSBColor (108/360f, 1f, 0.78f).ToColor ();
	private Color fillColor4 = new HSBColor (108/360f, 0, 1).ToColor ();
	// Components
//	[SerializeField] private GameObject bodyGO; // we enable/disable this
	[SerializeField] private Renderer fillCoverRenderer; // we use this to create that ol' pie-charty feel!
	[SerializeField] private SpriteRenderer backingSprite;
	[SerializeField] private SpriteRenderer fillSprite; // this is always a circle, but gets colored
//	[SerializeField] private SpriteRenderer barFill;
	// Properties
//	private bool isOpen;
	private float percentFilled;
	private float barRadius = 0.4f; // in Unity units!

	// Getters
	private Color GetFillColorFromPercent (float percent) {
		// Lerp between multiple colors!
		if (percent < 0.42f) {
			return Color.Lerp (fillColor0, fillColor1, Mathf.InverseLerp (0.08f, 0.42f, percent));
		}
		if (percent < 0.64f) {
			return Color.Lerp (fillColor1, fillColor2, Mathf.InverseLerp (0.42f, 0.64f, percent));
		}
		if (percent < 0.93f) {
			return Color.Lerp (fillColor2, fillColor3, Mathf.InverseLerp (0.64f, 0.93f, percent));
		}
		else {
			return Color.Lerp (fillColor3, fillColor4, Mathf.InverseLerp (0.93f, 1f, percent));
		}
	}


	// ----------------------------------------------------------------
	//  Initialize
	// ----------------------------------------------------------------
	private void Awake () {
		SetBodyVisibility (false);

		// Size me good!
		GameUtils.SizeSprite (backingSprite, barRadius+0.07f,barRadius+0.07f); // add bloat for a stroke
		GameUtils.SizeSprite (fillSprite, barRadius,barRadius);
//		GameUtils.SizeSprite (fillRenderer., barRadius,barRadius);
		fillCoverRenderer.gameObject.transform.localScale = fillSprite.transform.localScale / 1.45f; // HACKY
		UpdateBarVisuals ();
	}
	public void Initialize (Transform _parentTransform) {
		// Parent me and all that jazz!
		this.transform.SetParent (_parentTransform);
		this.transform.localPosition = Vector3.zero;
		this.transform.localScale = Vector3.one;
	}
//	public void Initialize () {
//		percentFilled = 0;
//
//	}



	// ----------------------------------------------------------------
	//  Doers
	// ----------------------------------------------------------------
	public void Open (Vector3 _pos) {
		this.transform.localPosition = _pos;
//		isOpen = true;
		SetBodyVisibility (true);
		percentFilled = 0; // default this to 0.
	}
	public void Close () {
//		isOpen = false;
		SetBodyVisibility (false);
	}
	private void SetBodyVisibility (bool _visible) {
		this.gameObject.SetActive (_visible);
//		fillCoverRenderer.enabled = _visible;
//		backingSprite.enabled = _visible;
	}
	private void UpdateBarVisuals () {
		// If I'm 0% filled, DON'T show me! :)
		if (percentFilled <= 0) {
			SetBodyVisibility (false);
		}
		// I'm MORE than 0% filled! Show me and update my color/pie!
		else {
			SetBodyVisibility (true);
			// Color!
			fillSprite.color = GetFillColorFromPercent (percentFilled);
			// Fill amounttt!
			fillCoverRenderer.material.SetFloat ("_Cutoff", percentFilled); 
		}
	}

	public void UpdateProgress (float _percentFilled) {
		percentFilled = _percentFilled;
		UpdateBarVisuals ();
	}

	

	// ----------------------------------------------------------------
	//  Update
	// ----------------------------------------------------------------
	private void Update () {
		FaceCamera ();
	}
	private void FaceCamera () {
		this.transform.LookAt (this.transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
	}


}


/*using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {
	// Constants
	private Color fillColor0 = new HSBColor (5/360f, 0.92f, 0.68f).ToColor ();
	private Color fillColor1 = new HSBColor (46/360f, 0.98f, 0.84f).ToColor ();
	private Color fillColor2 = new HSBColor (79/360f, 1f, 0.75f).ToColor ();
	private Color fillColor3 = new HSBColor (108/360f, 1f, 0.78f).ToColor ();
	private Color fillColor4 = new HSBColor (108/360f, 0, 1).ToColor ();
	// Components
	[SerializeField] private SpriteRenderer barBacking;
	[SerializeField] private SpriteRenderer barFill;
	// Properties
	private bool isOpen;
	private float percentFilled;
	private float barWidthFull = 0.75f; // in Unity units!
	private float barHeight = 0.08f; // in Unity units!

	// Getters
	private Color GetFillColorFromPercent (float percent) {
		// Lerp between multiple colors!
		if (percent < 0.42f) {
			return Color.Lerp (fillColor0, fillColor1, Mathf.InverseLerp (0.08f, 0.42f, percent));
		}
		if (percent < 0.64f) {
			return Color.Lerp (fillColor1, fillColor2, Mathf.InverseLerp (0.42f, 0.64f, percent));
		}
		if (percent < 0.93f) {
			return Color.Lerp (fillColor2, fillColor3, Mathf.InverseLerp (0.64f, 0.93f, percent));
		}
		else {
			return Color.Lerp (fillColor3, fillColor4, Mathf.InverseLerp (0.93f, 1f, percent));
		}
	}


	// ----------------------------------------------------------------
	//  Initialize
	// ----------------------------------------------------------------
	private void Awake () {
		SetBodyVisibility (false);

		// Size me good!
		GameUtils.SizeSprite (barBacking, barWidthFull,barHeight);
		UpdateBarVisuals ();
	}
//	public void Initialize () {
//		percentFilled = 0;
//
//	}



	// ----------------------------------------------------------------
	//  Doers
	// ----------------------------------------------------------------
	public void Open (Vector3 _pos) {
		this.transform.localPosition = _pos;
		isOpen = true;
		SetBodyVisibility (true);
		percentFilled = 0; // default this to 0.
	}
	public void Close () {
		isOpen = false;
		SetBodyVisibility (false);
	}
	private void SetBodyVisibility (bool _visible) {
		barFill.enabled = _visible;
		barBacking.enabled = _visible;
	}
	private void UpdateBarVisuals () {
		// Color!
		barFill.color = GetFillColorFromPercent (percentFilled);
		// Size!
		float fillWidth = percentFilled * barWidthFull;
		GameUtils.SizeSprite (barFill, fillWidth,barHeight);
	}

	public void UpdateProgress (float _percentFilled) {
		percentFilled = _percentFilled;
		UpdateBarVisuals ();
	}

	

	// ----------------------------------------------------------------
	//  Update
	// ----------------------------------------------------------------
	private void Update () {
	
	}


}



*/
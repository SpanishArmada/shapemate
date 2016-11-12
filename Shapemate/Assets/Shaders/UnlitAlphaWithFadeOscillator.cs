using UnityEngine;
using System.Collections;

public class UnlitAlphaWithFadeOscillator : MonoBehaviour {

	public float startAlpha, endAlpha;
	public float duration;
 
	private float prevAlpha;
	private float targetAlpha; 

	private Renderer rend;

	 
	void Start () {
		rend = GetComponent<Renderer>();
		SetAlpha(startAlpha);  
		StartCoroutine( Oscillate() ); 
	
	}  
	
	void SetAlpha(float alpha){   
		Color col = rend.material.GetColor("_Color");
		col.a = alpha;
		rend.material.SetColor("_Color", col);
	}
	
	float GetAlpha(){  
		Color col = rend.material.color;
		return col.a; 
	}
	
	IEnumerator Oscillate(){
		//StopAllCoroutines ();
		prevAlpha = startAlpha;
		targetAlpha = endAlpha; 
		yield return StartCoroutine("Fade",duration);
		
		prevAlpha = endAlpha;
		targetAlpha = startAlpha; 
		yield return StartCoroutine("Fade",duration);

		StartCoroutine(Oscillate());
	}
	
	IEnumerator Fade(float duration) {
		//StopAllCoroutines ();
		for (float t = 0f; t <= duration; t += 0.01f) {  
			
			float newAlpha = prevAlpha + ( ( (targetAlpha - prevAlpha) * (t) ) / duration );
			SetAlpha(newAlpha);
			
			yield return new WaitForSeconds(0.01f);
			
		}
	} 
}

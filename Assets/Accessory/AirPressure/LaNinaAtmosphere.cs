using UnityEngine;
using System.Collections;

public class LaNinaAtmosphere : MonoBehaviour 
{
	public Alpha low;
	public Alpha highlightLow;
	public Alpha hi;
	public Alpha highlightHi;
	public AlphaHub walkerWind;
	public Alpha[] rainClouds;
	public AlphaHub[] rainDrops;

	public void startAnim()
	{
		StopCoroutine("startCoroutine");
		StartCoroutine("startCoroutine");
	}

	IEnumerator startCoroutine()
	{
		low.on = true;
		highlightLow.on = true;
		yield return new WaitForSeconds(0.2f);
		hi.on = true;
		highlightHi.on = true;
		yield return new WaitForSeconds(0.2f);
		walkerWind.gameObject.SetActive(true);
		walkerWind.startAnim();
		yield return new WaitForSeconds(1.0f);

		for (int i = 0; i < rainClouds.Length; i++) {
			rainDrops [i].gameObject.SetActive(true);
			rainDrops [i].startAnim();
			rainClouds [i].on = true;
			yield return new WaitForSeconds(0.6f);
		}
	}

	public void endAnim()
	{
		StopCoroutine("endCoroutine");
		StartCoroutine("endCoroutine");
	}

	IEnumerator endCoroutine()
	{
		walkerWind.endAnim();
		for (int i = 0; i < rainClouds.Length; i++) {
			rainClouds [i].on = false;
			rainDrops [i].endAnim();
		}
		yield return new WaitForSeconds(1.1f);

		low.on = false;
		highlightLow.on = false;
		hi.on = false;
		highlightHi.on = false;
		yield return new WaitForSeconds(0.6f);

		gameObject.SetActive(false);
	}
}

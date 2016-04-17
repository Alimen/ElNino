using UnityEngine;
using System.Collections;

public class LaNinaAtmosphere : MonoBehaviour 
{
	public Alpha low;
	public Alpha hi;
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
		yield return new WaitForSeconds(0.2f);
		hi.on = true;
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
		hi.on = false;
		yield return new WaitForSeconds(0.6f);

		gameObject.SetActive(false);
	}
}

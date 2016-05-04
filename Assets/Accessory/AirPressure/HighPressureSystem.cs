using UnityEngine;
using System.Collections;

public class HighPressureSystem : MonoBehaviour
{
	public Alpha high;
	public Alpha highlight;
	public AlphaHub coldWinds;
	public Alpha sun;
	public Alpha sunLight;

	public void startAnim()
	{
		StopCoroutine("startCoroutine");
		StartCoroutine("startCoroutine");
	}

	IEnumerator startCoroutine()
	{
		coldWinds.gameObject.SetActive(true);
		coldWinds.startAnim();
		yield return new WaitForSeconds(2.0f);
		high.on = true;
		highlight.on = true;
		yield return new WaitForSeconds(1.0f);
		sun.on = true;
		sunLight.on = true;
	}

	public void endWindAnim()
	{
		coldWinds.endAnim();
	}

	public void endAnim()
	{
		StopCoroutine("endCoroutine");
		StartCoroutine("endCoroutine");
	}

	IEnumerator endCoroutine()
	{
		sun.on = false;
		sunLight.on = false;
		if (coldWinds.isOn) {
			coldWinds.endAnim();
		}
		yield return new WaitForSeconds(0.5f);
		high.on = false;
		highlight.on = false;
		yield return new WaitForSeconds(0.6f);
		gameObject.SetActive(false);
	}
}

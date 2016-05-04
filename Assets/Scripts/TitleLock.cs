using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleLock : MonoBehaviour
{
	public Text newLbl;
	public Button nxtBtn;
	public Image lockIcon;
	public int i;

	void Start()
	{
		int progress = GameData.getRuntime().titleProgress;
		newLbl.gameObject.SetActive(progress == i);
		nxtBtn.gameObject.SetActive(progress >= i);
		lockIcon.gameObject.SetActive(progress < i);
	}
}

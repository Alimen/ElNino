using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class GameManagerBase : MonoBehaviour
{
	protected Animator anim;
	public GameData data;

	public virtual void Start()
	{
		anim = GetComponent<Animator>();
		data = GameData.getRuntime();
	}

	public void pause()
	{
		anim.speed = 0;
	}

	public void unpause()
	{
		anim.speed = 1;
	}

	public void loadScene(int id)
	{
		string level = "";
		switch (id) {
			case 0:
				level = "00 - Title";
				break;
			case 1:
				break;
			case 2:
				level = "02 - NormalYear";
				break;
			case 3:
				level = "03 - ElNino";
				break;
			case 4:
				break;
		}

		if (!string.IsNullOrEmpty(level)) {
			UnityEngine.SceneManagement.SceneManager.LoadScene(level);
		}
	}
}

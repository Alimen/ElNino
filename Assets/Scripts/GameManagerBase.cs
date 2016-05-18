using UnityEngine;
using UnityEngine.SceneManagement;
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
		if (anim.speed < 1) {
			anim.speed = 1;
		}
	}

	public void loadScene(int id)
	{
		string level = "";
		switch (id) {
			case 0:
				level = "00 - Title";
				break;
			case 1:
				level = "01 - Glossary";
				break;
			case 2:
				level = "02 - NormalYear";
				break;
			case 3:
				level = "03 - ElNino";
				break;
			case 4:
				level = "04 - LaNina";
				break;
		}

		if (!string.IsNullOrEmpty(level)) {
			SceneManager.LoadScene(level);
		}
	}

	protected void reloadScene()
	{
		string scene = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene(scene);
	}
}

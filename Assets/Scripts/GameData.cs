using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour
{
	static GameData _runtime;
	public static GameData getRuntime()
	{
		if (_runtime == null) {
			GameObject go = GameObject.Find("GameData");
			if (go == null) {
				go = Instantiate(Resources.Load<GameObject>("GameData"));
				go.name = "GameData";
			}
			_runtime = go.GetComponent<GameData>();
		}
		return _runtime;
	}

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	public int titleProgress;
	public int glossaryGameProgress;
	public int normalYearGameProgress;
	public int elNinoYearGameProgress;
	public int laNinaYearGameProgress;
}

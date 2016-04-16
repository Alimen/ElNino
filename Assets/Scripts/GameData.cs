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
				go = new GameObject();
				go.name = "GameData";
				_runtime = go.AddComponent<GameData>();
			} else {
				_runtime = go.GetComponent<GameData>();
			}
		}
		return _runtime;
	}

	void Awake()
	{
		if (GameData.getRuntime() != this) {
			Destroy(gameObject);
		} else {
			DontDestroyOnLoad(gameObject);
		}
	}

	public int normalYearGameProgress;
	public int elNinoYearGameProgress;
}

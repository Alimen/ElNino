using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour
{
	void Start()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
	}
}

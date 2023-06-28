using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{

	private void OnTriggerEnter2D(Collider2D collision)
	{
		for (int i = 0; i < collision.gameObject.transform.childCount; i++)
		{
			GameObject child = collision.gameObject.transform.GetChild(i).gameObject;
			Debug.LogWarning("name" + child.name + " active" + child.activeSelf + " " + transform.gameObject.name);
			if (child.activeSelf)
			{
				if (child.name == transform.gameObject.name)
				{
					Debug.Log("Add score");
					Score.score++;
				}
				else
				{
					Debug.Log("End");
					GameManager.Instance.GameOver();
				}
			}
		}
	//Score.score++;
	}
}

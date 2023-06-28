using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyBird : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public GameManager gameManager;
    public float veclotity = 1;
    private Rigidbody2D rb;
    private Collider2D cl;
    private float score = 0f;
    private bool IsStart = false;
    public Text uiText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cl = GetComponent<Collider2D>();
        GetChildGameObj();
      
        StartCoroutine(InvokeRepeatedly(0.59f));

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Jump
            rb.velocity = Vector2.up * veclotity;
        }

        if (gameManager.IsGameStart)
        {
            this.IsStart = true;
        }


        int currentScore = Score.score;
        if (this.score < currentScore)
        {
            GetRandomGrabage();
            this.score = currentScore;
        }
    }

    IEnumerator InvokeRepeatedly(float interval)
    {
        while (true)
        {
            AutoJump();
            yield return new WaitForSeconds(interval);
        }
    }

    void AutoJump()
    {
        if (IsStart) return;
        rb.velocity = Vector2.up * veclotity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
	{
        gameManager.GameOver();
	}

    public void GetChildGameObj()
    {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            GameObject childObject = transform.GetChild(i).gameObject;
            gameObjects.Add(childObject);
            //Debug.Log(childObject.name);
        }
        GetRandomGrabage();
    }
    public void GetRandomGrabage()
    {
		foreach (GameObject obj in gameObjects)
		{
            obj.SetActive(false);
        }

        int ran = Random.Range(0, gameObjects.Count);
        GameObject ranObj = gameObjects[ran];
        ranObj.SetActive(true);
        if (ran == 0)
        {
            SetText("Bún đậu");
        }
        else if (ran == 1)
        {
            SetText("Trà sữa");
        }
        else if (ran == 2)
        {
            SetText("Bánh tráng");
        }
        else if (ran == 3)
        {
            SetText("Xiên bẩn");
        }

        //Debug.Log("Random: " + ranObj);
    }

    private void SetText(string text)
    {
        uiText.text = text;
    }
}

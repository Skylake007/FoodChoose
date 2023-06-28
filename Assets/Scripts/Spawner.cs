using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public float maxTime = 1.2f;
	private float timer = 0;
	public GameObject pipe;
	public GameManager gameManager;
	//public float height;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (timer > maxTime && gameManager.IsGameStart)
		{
			GameObject newPipe = Instantiate(pipe);
            newPipe.transform.position = transform.position;/* + new Vector3(0, Random.Range(-height, height), 0);*/
			Destroy(newPipe, 5);
			timer = 0;
		}

		timer += Time.deltaTime;
	}
}

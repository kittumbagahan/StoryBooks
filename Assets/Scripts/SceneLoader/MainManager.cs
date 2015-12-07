using UnityEngine;
using System.Collections;

public class MainManager : MonoBehaviour {

	public GameObject sceneLoader;
	void Start () {
		Instantiate(sceneLoader);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

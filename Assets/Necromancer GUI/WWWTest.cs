using UnityEngine;
using System.Collections;

public class WWWTest : MonoBehaviour {

	// Use this for initialization
	//中文显示
	WWW wwwTest;
	void Start(){
		
		Test();
		Debug.Log("jll");
	}
	IEnumerable Test() {
	Debug.Log("jll");
	wwwTest=new WWW("http://mk.cghope.com/get_person_info.php?userid=xxx");
	yield return wwwTest;
	Debug.Log(wwwTest.text);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

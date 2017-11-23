using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class s1_comtroller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void lang_hindi(){
        SceneManager.LoadScene("ar_scene");
        appManage.instance.set_lang(1);
    }

    public void lang_english(){
        SceneManager.LoadScene("ar_scene");
        appManage.instance.set_lang(0);
    }

}

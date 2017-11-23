using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appManage : MonoBehaviour {

    public static appManage instance = null;

    public int lang_flag = 0;    //1 is for hindi and 0 is for english

	// Use this for initialization
	void Awake () {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
	}

    public void set_lang(int tmp) {
        lang_flag = tmp;
    }

    public int get_lang() {
        return lang_flag;
    }
    void MakeSiglenton() { 
    
    }

}

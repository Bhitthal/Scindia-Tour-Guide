using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJson;
public class App_controller : MonoBehaviour {

    public Text text_box;

    public static App_controller instance;

    public Text main_info;

    public Text debug_info;

    public TextAsset language_file;

    List<Dictionary<string, string>> levels = new List<Dictionary<string, string>>();
    Dictionary<string, string> obj;
    //Dictionary<string, string> temp_dic;

    public int lang_flag = 0;

    [System.Serializable]
    public class SimpleTest
    {
        public string name;
        public int id;
    }

	// Use this for initialization
	void Awake () {
        MakeInstance();
        load_xml();
        lang_flag = appManage.instance.get_lang();
	}

    void Start() {
        //TextAsset jsonObj = Resources.Load(Path.Combine("JSON", "simple")) as TextAsset;
        //SimpleTest glyphMap = JsonUtility.FromJson<SimpleTest>(jsonObj.text);
        //print(glyphMap.name);
    }
	
	// Update is called once per frame
	void MakeInstance () {
        if (instance == null)
            instance = this;
	}


    public string show_text(string tag) {
        Debug.Log(":P " + levels[lang_flag]["1"]);
        return levels[lang_flag][tag];
    }

    public void debug_text(string log_s) {
        debug_info.text = log_s;

    }

    public void pay_audio() {
        //StartCoroutine(GetAudioClip());
        //show_text("1");
    }

    public void try_text() {

        text_box.text = App_controller.instance.show_text("7");
        sound_controller.instance.play_clip("7");
    }

    IEnumerator GetAudioClip()
    {
        Debug.Log("clicked");
        using (UnityWebRequest www = UnityWebRequest.GetAudioClip("https://vw123.000webhostapp.com/sounds/0954.ogg", AudioType.OGGVORBIS))
        {
            Debug.Log("clicked_inside");
            yield return www.Send();

            if (www.isError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("download clip");
                AudioClip myClip = DownloadHandlerAudioClip.GetContent(www);
            }
        }
    }

    void load_xml() {

        XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
        xmlDoc.LoadXml(language_file.text); // load the file.
        XmlNodeList levelsList = xmlDoc.GetElementsByTagName("level"); // array of the level nodes.

        foreach (XmlNode levelInfo in levelsList)
        {
            XmlNodeList levelcontent = levelInfo.ChildNodes;
            obj = new Dictionary<string, string>(); // Create a object(Dictionary) to colect the both nodes inside the level node and then put into levels[] array.

            foreach (XmlNode levelsItens in levelcontent) // levels itens nodes.
            {
                if (levelsItens.Name == "name")
                {
                    obj.Add("name", levelsItens.InnerText); // put this in the dictionary.
                    Debug.Log("name" + levelsItens.InnerText);
                }
                if (levelsItens.Name == "object")
                {
                    obj.Add(levelsItens.Attributes["name"].Value, levelsItens.InnerText); // put this in the dictionary.
                    Debug.Log(levelsItens.Attributes["name"].Value + ": " + levelsItens.InnerText);
                }
            }
            Debug.Log("obj added");
            levels.Add(obj); // add whole obj dictionary in the levels[].
        }
    }


}

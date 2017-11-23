using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

public class LoadXmlData : MonoBehaviour {

    public TextAsset GameAsset;

    static string Cube_Character = "";
    static string Cylinder_Character = "";
    static string Capsule_Character = "";
    static string Sphere_Character = "";

    List<Dictionary<string, string>> levels = new List<Dictionary<string, string>>();
    Dictionary<string, string> obj;


	// Use this for initialization
	void Start () {
        GetLevel();
	}

    public void GetLevel()
    {
        XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
        xmlDoc.LoadXml(GameAsset.text); // load the file.
        XmlNodeList levelsList = xmlDoc.GetElementsByTagName("level"); // array of the level nodes.
        

        foreach (XmlNode levelInfo in levelsList)
        {
            XmlNodeList levelcontent = levelInfo.ChildNodes;
            obj = new Dictionary<string, string>(); 

            foreach (XmlNode levelsItens in levelcontent) // levels itens nodes.
            {
                if (levelsItens.Name == "name")
                {
                    obj.Add("name", levelsItens.InnerText); // put this in the dictionary.
                    Debug.Log("name" + levelsItens.InnerText);
                }

                if (levelsItens.Name == "tutorial")
                {
                    obj.Add("tutorial", levelsItens.InnerText); // put this in the dictionary.
                    Debug.Log("tutorial" + levelsItens.InnerText);
                }

                if (levelsItens.Name == "object")
                {
                    switch (levelsItens.Attributes["name"].Value)
                    {
                        case "Cube": obj.Add("Cube", levelsItens.InnerText); Debug.Log("cube" + levelsItens.InnerText); break; // put this in the dictionary.
                        case "Cylinder": obj.Add("Cylinder", levelsItens.InnerText); break; // put this in the dictionary.
                        case "Capsule": obj.Add("Capsule", levelsItens.InnerText); break; // put this in the dictionary.
                        case "Sphere": obj.Add("Sphere", levelsItens.InnerText); break; // put this in the dictionary.
                    }
                }

                if (levelsItens.Name == "finaltext")
                {
                    obj.Add("finaltext", levelsItens.InnerText); // put this in the dictionary.
                }
            }
            levels.Add(obj); // add whole obj dictionary in the levels[].
        }
    }


	// Update is called once per frame
	void Update () {
		
	}
}

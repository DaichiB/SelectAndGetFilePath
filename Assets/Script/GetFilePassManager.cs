using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GetFilePassManager
{
    const string PATH_POPUP = "PopupSelectFile";

    static public void OpenPopupSelectFile(PopupSelectFile.StringParameterDel callbackOnClose, Transform parent,
        string path = "")
    {
        var obj = LoadObject(PATH_POPUP, parent);
        string firstPath = path;
        if (firstPath == "")
            firstPath = Directory.GetCurrentDirectory();
        obj.gameObject.GetComponent<PopupSelectFile>().Init(firstPath, callbackOnClose);
    }

    static public GameObject LoadObject(string pass, Transform parent)
    {
        GameObject obj = GameObject.Instantiate(Resources.Load(pass), parent) as GameObject;
        return obj;
    }

}

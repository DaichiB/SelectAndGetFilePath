using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetFilePassManager
{
    const string PATH_POPUP = "PopupSelectFile";

    static public void OpenPopupSelectFile(PopupSelectFile.StringParameterDel callbackOnClose, Transform parent)
    {
        var obj = LoadObject(PATH_POPUP, parent);
        obj.gameObject.GetComponent<PopupSelectFile>().Init(callbackOnClose);
    }

    static public GameObject LoadObject(string pass, Transform parent)
    {
        GameObject obj = GameObject.Instantiate(Resources.Load(pass), parent) as GameObject;
        return obj;
    }

}

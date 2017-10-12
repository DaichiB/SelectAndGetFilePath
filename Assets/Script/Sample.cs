using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sample : MonoBehaviour
{
    [SerializeField]
    Transform parent;
    [SerializeField]
    Text txtSelectFile;

    public void OnClick_OpenSelect()
    {
        GetFilePassManager.OpenPopupSelectFile(delegate (string str)
        {
            txtSelectFile.text = str;
        }, parent);
    }

    public void OnClick_OpenSave()
    {
        GetFilePassManager.OpenPopupSaveFile(delegate (string str)
        {
            txtSelectFile.text = str;
        }, parent);
    }
}

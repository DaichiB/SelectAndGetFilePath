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

    public void OnClick_Open()
    {
        GetFilePassManager.OpenPopupSelectFile(delegate (string str)
        {
            txtSelectFile.text = str;
        }, parent);
    }
}

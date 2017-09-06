using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class FilesListItem : MonoBehaviour {
    [SerializeField]
    Text txtFileName;
    [SerializeField]
    GameObject iconFolder;

    public delegate void ClickItem(FilesListItem item);

    public string FilePath { get { return m_FilePath; } }
    protected string m_FilePath;
    protected ClickItem m_OnClickIte=null;

    public void Setup(string path, ClickItem onClickItem)
    {
        m_FilePath = path;
        m_OnClickIte = onClickItem;
        string fileName = Path.GetFileName(path);
        txtFileName.text = fileName;
        iconFolder.SetActive(Path.GetExtension(fileName)=="");
    }

    public void OnClick_item()
    {
        Debug.Log("Select: "+m_FilePath);
        if (m_OnClickIte != null)
            m_OnClickIte(this);
    }
}

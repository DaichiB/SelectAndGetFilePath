using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PopupSelectFile : MonoBehaviour
{
    [SerializeField]
    InputField txtCurrentFile;
    [SerializeField]
    Text txtSelectedFile;
    [SerializeField]
    Transform content;

    public delegate void StringParameterDel(string str);

    const string PATH_ITEM = "FilesListItem";

    protected FilesListItem m_SelectedItem = null;
    protected string m_CurrentPath;
    protected StringParameterDel m_CallbackOnClose;

    public void Init(string path,StringParameterDel callbackOnClose)
    {
        m_CallbackOnClose = callbackOnClose;
        SetupUI(path);
    }

    void SetupUI(string path)
    {
        txtCurrentFile.text = path;
        txtSelectedFile.text = Path.GetFileName(path);
        m_CurrentPath = path;
        Vector2 size = new Vector2(this.GetComponent<RectTransform>().rect.width, 40.0f);
        content.GetComponent<GridLayoutGroup>().cellSize = size;
        string[] pathList = Directory.GetFileSystemEntries(path);
        m_SelectedItem = null;
        for (int i = content.childCount - 1; i >= 0; i--)
            Destroy(content.GetChild(i).gameObject);
        if (pathList == null)
        {
            Debug.LogError("Miss Getting Paths!");
            return;
        }
        for (int j = 0; j < pathList.Length; j++)
            AddListItem(pathList[j]);
    }

    void AddListItem(string filePath)
    {
        var item = GetFilePassManager.LoadObject(PATH_ITEM, content);
        item.transform.localScale = Vector3.one;
        item.GetComponent<Image>().color = Color.white;
        item.GetComponent<FilesListItem>().Setup(filePath, OnClickItem);
    }

    void OnClickItem(FilesListItem item)
    {
        string fileType = Path.GetExtension(item.FilePath);
        if (fileType != "")
        {
            if (m_SelectedItem != null)
                m_SelectedItem.GetComponent<Image>().color = Color.white;
            item.GetComponent<Image>().color = Color.gray;
            m_SelectedItem = item;
            txtSelectedFile.text = Path.GetFileName(item.FilePath);
        }
        else
            SetupUI(item.FilePath);
    }

    public void OnClick_Open()
    {
        OnClose(m_CallbackOnClose);
    }

    public void OnClick_Back()
    {
        string parentPath = Path.GetDirectoryName(m_CurrentPath);
        if (parentPath != null && parentPath != "")
            SetupUI(parentPath);
    }

    public void OnClick_Close()
    {
        OnClose();
    }

    void OnClose(StringParameterDel callback = null)
    {
        this.gameObject.SetActive(false);
        if (callback != null)
        {
            if (m_SelectedItem != null)
                callback(m_SelectedItem.FilePath);
            else
                callback(m_CurrentPath);
        }

        Destroy(this.gameObject);
    }

    public void OnClick_Update()
    {
        SetupUI(txtCurrentFile.text);
    }
}

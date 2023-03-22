using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI组件")] 
    public TMP_Text textLabel;
    public Image factImage;

    [Header("文本文件")] 
    public TextAsset textFile;

    public int index;
    private List<string> textList = new List<string>();
    void Awake()
    {
        GetTextFormFile(textFile);
    }

    private void OnEnable()
    {
        textLabel.text = textList[index];
        index++;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            textLabel.text = textList[index];
            index++;
        }
    }

    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

       string[] lineDate= file.text.Split('\n');
       foreach (var line in lineDate)
       {
           textList.Add(line);
           print(line);
       }
    }
}

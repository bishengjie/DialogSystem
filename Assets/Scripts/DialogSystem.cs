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

    [Header("文本文件")] public TextAsset textFile;

    public int index;
    public float textSpeed;

    [Header("头像")] 
    public Sprite face01, face02;
    
    private bool textFinished;

    private List<string> textList = new List<string>();

    void Awake()
    {
        GetTextFormFile(textFile);
    }

    private void OnEnable()
    {
        // textLabel.text = textList[index];
        // index++;
        textFinished = true;
        StartCoroutine(SetTextUI());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }

        if (Input.GetKeyDown(KeyCode.R) && textFinished)
        {
            // textLabel.text = textList[index];
            // index++;
            StartCoroutine(SetTextUI());
        }
    }

    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        string[] lineDate = file.text.Split('\n');
        foreach (var line in lineDate)
        {
            textList.Add(line);
            print(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";

        switch (textList[index])
        {
            case "A":
                factImage.sprite = face01;
                index++;
                break;
            case "B":
                factImage.sprite = face02;
                index++;
                break;
        }
        
        for (int i = 0; i < textList[index].Length; i++)
        {
            textLabel.text += textList[index][i];
            yield return new WaitForSeconds(textSpeed);
        }

        textFinished = true;
        index++;
    }
}

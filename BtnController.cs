using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnController : MonoBehaviour
{
    public GameObject goPrefeb;
    public GameObject[] procBtn;
    public ObjectP op;
    public int maxStage;
    public int currentPage = 0;
    public int totalPage;
    public Transform createPos;
    public Button btnPrev;
    public Button btnNext;

    public int maxLimit;
    private void Start()
    {
        op = GetComponent<ObjectP>();
        totalPage = maxStage / maxLimit;

        btnPrev.onClick.AddListener(() =>{ PrevPage(); });
        btnNext.onClick.AddListener(() => { NextPage(); });
    }

    public void PrevPage()
    {
        if (currentPage == 0)
        {
            return;
        }
        currentPage--;
        foreach (var item in procBtn)
        {
            item.gameObject.SetActive(false);
        }
        var startIndex = currentPage * maxLimit;
        var endIndex = startIndex + maxLimit;
        
        
        for (int i = 0; i < maxLimit; i++)
        {
            procBtn[startIndex + i].gameObject.SetActive(true);
        }

        if (currentPage == 0)
        {
            btnPrev.gameObject.SetActive(false);
        }
        else
        {
            btnPrev.gameObject.SetActive(true);
        }
        btnNext.gameObject.SetActive(true);
    }
    public void NextPage()
    {
        if (currentPage == totalPage)
        {
            return;
        }
        currentPage++;
        foreach(var item in procBtn)
        {
            item.gameObject.SetActive(false);
        }

        Debug.LogFormat("currentPage: {0}, totalPage: {1}", currentPage, totalPage);

        var startIndex = currentPage * maxLimit;
        var endIndex = startIndex + maxLimit;
        var index = maxStage - startIndex;
        Debug.LogFormat("{0} ~ {1}", startIndex, index);

        if(index > maxLimit)
        {
            for (int i = 0; i < maxLimit; i++)
            {
                procBtn[startIndex + i].gameObject.SetActive(true);
            }
        }
        
        else if(index < maxLimit)
        {
            for(int i = 0; i < index; i++)
            {
                procBtn[startIndex + i].gameObject.SetActive(true);
            }
        }
        if (currentPage == totalPage)
        {
            btnNext.gameObject.SetActive(false);
        }
        else
        {
            btnNext.gameObject.SetActive(true);
        }
        btnPrev.gameObject.SetActive(true);
    }
    public void CreateBtn(int count)
    {
        procBtn = new GameObject[count];

        
        for (int i = 0; i < count; i++)
        {
            procBtn[i] = Instantiate(goPrefeb, createPos.transform);
            procBtn[i].GetComponent<Btn>().btnIndex = i + 1;


            if (i >= maxLimit)
            {
                procBtn[i].gameObject.SetActive(false);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class Btn : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int btnIndex;
    BtnOn bo;
    UnityEvent procEvent;
    private void Start()
    {
        bo = FindObjectOfType<BtnOn>();
        text.text = btnIndex.ToString();
        GetComponent<Button>().onClick.AddListener(Call);
    }

    public void Call()
    {
        bo.CallProcButton(btnIndex - 1);
        Debug.Log(btnIndex - 1);
    }    
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnOn : MonoBehaviour
{
    public ObjectP op;

    public BtnController bc;

    public bool isCheck = false;

    public int step;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bc.CreateBtn(op.length);  
        }
    }

    public void CallProcButton(int count)
    {
        step = count;
    }
}

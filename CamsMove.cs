using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WayPoint
{
    public Transform[] wayPoints;
}
public class CamsMove : MonoBehaviour
{
    public Transform initPos;
    public WayPoint[] wayCount;
    public GameObject target;
    public WayPoint nowWay;
    public float speed = 0.5f;
    public int wayPointNum = 0;
    public Button btn1;
    public Button resetBtn;
    public bool isStart;

    float offset = 5;

    private void Start()
    {
        Init();
        nowWay = null;
    }
    public void Init()
    {
        transform.position = initPos.position;
        transform.rotation = initPos.rotation;
    }

    void FixedUpdate()
    {
        if (!isStart)
            return;

        transform.position = Vector3.Slerp(transform.position, nowWay.wayPoints[wayPointNum].transform.position, speed / offset);
        transform.rotation = Quaternion.Slerp(transform.rotation, nowWay.wayPoints[wayPointNum].transform.rotation, speed / offset);
        transform.LookAt(target.transform);
        if (Vector3.Distance(transform.position, nowWay.wayPoints[wayPointNum].transform.position) < 0.1f)
        {
            if(wayPointNum < nowWay.wayPoints.Length)
            {
                wayPointNum++;
            }
            
        }
        if (wayPointNum >= nowWay.wayPoints.Length)
        {
            nowWay = null;
            wayPointNum = 0;
            isStart = false;
        }
    }

    //private void Update()
    //{
    //    if(nowWay == null)
    //    {
    //        return;
    //    }
    //}
    //void MovePath()
    //{
    //    StopCoroutine(MoveCo());
    //    StartCoroutine(MoveCo());
        
    //}

    //float smoothTime = 0.3f;
    //Vector3 v = Vector3.zero;

    //IEnumerator MoveCo()
    //{
    //    while(true)
    //    {
            
            
    //        if(nowWay != null)
    //        {
    //            transform.position = Vector3.Lerp(transform.position, nowWay.wayPoints[wayPointNum].transform.position, speed / offset);
    //            transform.position = Vector3.SmoothDamp(transform.position, nowWay.wayPoints[wayPointNum].transform.position, ref v, smoothTime);
    //            transform.rotation = Quaternion.Slerp(transform.rotation, nowWay.wayPoints[wayPointNum].transform.rotation, speed / offset);
    //            if (transform.position == nowWay.wayPoints[wayPointNum].transform.position)
    //            {
                    
    //                yield return new WaitForSeconds(.1f);
    //                wayPointNum++;
    //            }
    //            if (wayPointNum == nowWay.wayPoints.Length)
    //            {
    //                nowWay = null;
    //                wayPointNum = 0;
    //            }
    //            if (Vector3.Distance(transform.position, nowWay.wayPoints[wayPointNum].transform.position) < 0.1f)
    //            {

    //                yield return new WaitForEndOfFrame();
    //                wayPointNum++;
    //            }
    //            if (wayPointNum == nowWay.wayPoints.Length)
    //            {
    //                nowWay = null;
    //                wayPointNum = 0;
    //            }
    //        }
            
    //        yield return null;
    //    }
        
    //}

    
    public void Btn1()
    {
        isStart = true;
        nowWay = wayCount[0];
       // MovePath();
    }

    
}

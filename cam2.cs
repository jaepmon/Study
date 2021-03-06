//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MoveCompleteEventArgs
//{
//    public GameObject targetObject;
//    public Vector3 position;
//    public Quaternion quaternion;
//}
//public class cam2 : MonoBehaviour
//{
//    public static event System.EventHandler<MoveCompleteEventArgs> EventHandler_CameraMoveTarget;

//    public GameObject camera;

//    private Transform targetObject;

//    public Transform subTarget;

//    public float smoothTime = 0.3f;

//    private Vector3 velocity = Vector3.zero;

//    public static bool isActive = false;

//    public float zoomIn = -5;

//    private Bounds boundData;
//    private bool isBounds = true;

//    private int passCount = 0;

//    private void Update()
//    {

//        if(isActive)
//        {
//            Vector3 targetPosition;

//            if(subTarget != null && passCount == 0)
//            {
//                targetPosition = subTarget.transform.position;
//                smoothTime = 0.1f;
//            }
//            else
//            {
//                if(!isBounds)
//                {
//                    targetPosition = targetObject.TransformPoint(new Vector3(0, 10, zoomIn));
//                }
//                else
//                {
//                    targetPosition = new Vector3(boundData.center.x, boundData.center.y + boundData.size.y, boundData.center.z - boundData.size.z + zoomIn);
//                }
//            }
//            camera.transform.position = Vector3.SmoothDamp(camera.transform.position, targetPosition, ref velocity, smoothTime);
//            camera.transform.LookAt(targetObject);
//            if(Vector3.Distance(targetPosition, camera.transform.position) < 0.1f)
//            {
//                if(subTarget != null)
//                {
//                    if(targetPosition == subTarget.transform.position)
//                    {
//                        passCount++;

//                        if (!isBounds)
//                        {
//                            targetPosition = targetObject.TransformPoint(new Vector3(0, 10, zoomIn));
//                        }
//                        else
//                        {
//                            targetPosition = new Vector3(boundData.center.x, boundData.center.y + boundData.size.y, boundData.center.z - boundData.size.z + zoomIn);
//                        }
//                    }
//                    else
//                    {
//                        MoveCompleteEventArgs args = new MoveCompleteEventArgs();
//                        args.targetObject = targetObject.gameObject;
//                        args.position = camera.transform.position;
//                        args.quaternion = camera.transform.rotation;
//                        EventHandler_CameraMoveTarget(this, args);

//                        Clear();
//                    }

//                }
//                else
//                {
//                    MoveCompleteEventArgs args = new MoveCompleteEventArgs();
//                    args.targetObject = targetObject.gameObject;
//                    args.position = camera.transform.position;
//                    args.quaternion = camera.transform.rotation;
//                    EventHandler_CameraMoveTarget(this, args);

//                    Clear();
//                }
//            }
//        }
//    }
//    public void SetTarget(GameObject target, bool bounds = true)
//    {
//        if (target == null)
//            return;
//        isActive = true;
//        targetObject = target.transform;

//        if(bounds)
//        {
//            Bounds combineBounds = new Bounds();
//            var renderers = target.GetComponentsInChildren<Renderer>();
//            foreach(var render in renderers)
//            {
//                combineBounds.Encapsulate(render.bounds);
//            }
//            boundData = combineBounds;
//            isBounds = true;
//        }
//        else
//        {
//            boundData = new Bounds();
//            isBounds = false;
//        }
//    }
//    public void Clear()
//    {
//        smoothTime = 0.3f;
//        isActive = false;
//        targetObject = null;
//        passCount = 0;
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ???? ?????? ???? ??????
/// </summary>
public class MoveCompleteEventArgs
{
    public GameObject targetObject;
    public Vector3 position;
    public Quaternion quaternion;
}

public class cam2 : MonoBehaviour
{
    public static event System.EventHandler<MoveCompleteEventArgs> EventHandler_CameraMoveTargtet;

    /// <summary>
    /// ??????
    /// </summary>
    public GameObject camera;
    public GameObject targetPos;
    /// <summary>
    /// ???? ???? ????????
    /// </summary>
    private Transform targetObject;

    /// <summary>
    /// ???? ???? ????
    /// </summary>
    public Transform subTarget;

    /// <summary>
    /// ???????? ?????? ????
    /// </summary>
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    /// <summary>
    /// ?????? ???? ???? ???? ??????
    /// </summary>
    public static bool IsActive = false;

    /// <summary>
    /// ???? ???? -?? ?????? ??????
    /// </summary>
    public float Zoomin = -5;

    /// <summary>
    /// ???????? ?????? ???? ?????? ?????? ?????? ??????
    /// </summary>
    private Bounds boundsData;
    private bool isBounds = true;

    /// <summary>
    /// ???????? ???? ?? ???? ??????
    /// </summary>
    private int PassCount = 0;
    // Update is called once per frame


    void Update()
    {
        if (IsActive)
        {
            Vector3 targetPosition;

            //?????????? ?????? ?????????? ???????????? ????????
            if (subTarget != null && PassCount == 0)
            {
                targetPosition = subTarget.transform.position;
                smoothTime = 0.1f;
            }
            else
            {
                //?????????? ?????? bounds ???? ?? ?????????? ???????? ????????
                if (!isBounds)
                    targetPosition = targetObject.TransformPoint(new Vector3(0, 10, Zoomin));
                else
                    targetPosition = new Vector3(boundsData.center.x, boundsData.center.y + boundsData.size.y, boundsData.center.z - boundsData.size.z + Zoomin);
            }

            //?????? ?????? ?????? ???????? ????
            camera.transform.position = Vector3.SmoothDamp(camera.transform.position, targetPosition, ref velocity, smoothTime);
            camera.transform.LookAt(targetObject);

            //???????? ?????? ????
            if (Vector3.Distance(targetPosition, camera.transform.position) < 0.1f)
            {
                //?????????? ???? ????
                if (subTarget != null)
                {
                    //if(Vector3.Distance(targetPosition,subTarget.transform.position) < 0.1f)
                    if (targetPosition == subTarget.transform.position)
                    {
                        PassCount++;

                        //???????? ???? ?? targetPosition?? ???? ?????????? ????
                        if (!isBounds)
                            targetPosition = targetObject.TransformPoint(new Vector3(0, 10, Zoomin));
                        else
                            targetPosition = new Vector3(boundsData.center.x, boundsData.center.y + boundsData.size.y, boundsData.center.z - boundsData.size.z + Zoomin);
                    }
                    else
                    {
                        //???????? ???? ?????? ?????????? ?????? ????

                        MoveCompleteEventArgs args = new MoveCompleteEventArgs();
                        args.targetObject = targetObject.gameObject;
                        args.position = camera.transform.position;
                        args.quaternion = camera.transform.rotation;
                        EventHandler_CameraMoveTargtet(this, args);

                        Clear();
                    }
                }
                else
                {
                    //???? ???? ???? ???? ?????? ?????????? ?????? ????
                    MoveCompleteEventArgs args = new MoveCompleteEventArgs();
                    args.targetObject = targetObject.gameObject;
                    args.position = camera.transform.position;
                    args.quaternion = camera.transform.rotation;
                    EventHandler_CameraMoveTargtet(this, args);

                    Clear();
                }
            }
        }

        //if (Input.GetMouseButton(0) && IsActive || Input.GetMouseButton(1) && IsActive || Input.GetAxis("Mouse ScrollWheel") != 0 && IsActive)
        //{
        //    Clear();
        //}

    }
    public void SelectBtn()
    {
        SetTarget(targetPos, true);
    }
    /// <summary>
    /// target ?????????? ?????? ???????? ????
    /// </summary>
    /// <param name="target">???? ????????</param>
    /// <param name="bounds">???????? ?????? ???? ???? ????</param>
    public void SetTarget(GameObject target, bool bounds = true)
    {
        if (target == null)
            return;
        IsActive = true;
        targetObject = target.transform;

        //bounds?? true?????? target?? bounds ???????? ????
        if (bounds)
        {
            Bounds combinedBounds = new Bounds();
            var renderers = target.GetComponentsInChildren<Renderer>();
            foreach (var render in renderers)
            {
                combinedBounds.Encapsulate(render.bounds);
            }

            boundsData = combinedBounds;
            isBounds = true;
        }
        else
        {
            boundsData = new Bounds();
            isBounds = false;
        }

    }

    public void Clear()
    {
        smoothTime = 0.3f;
        IsActive = false;
        targetObject = null;
        PassCount = 0;
    }
}

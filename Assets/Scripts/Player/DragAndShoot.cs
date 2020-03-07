using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragAndShoot : MonoBehaviour
{
    [Header("Drag & Drop Params")]
    [SerializeField] private float power = 5f;
    [SerializeField] private Vector2  minPower, maxPower;
    [SerializeField] private LayerMask clickMask;
    [Header("External Scripts")]
    [SerializeField] private CameraVignette cameraVignette;

    private DragLine dragLine;
    private Rigidbody rb;
    Vector2 force;
    Vector3 startPoint, endPoint;

    private bool isGravityPlayer;

    private void Start()
    {
        dragLine = GetComponent<DragLine>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // If time is running out
        if (TimeManager.instance.isTimesUp || GameManager.instance.isPlayerDead)
        {
            EndDrag(false);
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //Avoid Interaction when menu exists
            if (EventSystem.current.IsPointerOverGameObject() && !GameManager.instance.isGamePlaying) return;

            //Start the slow motion
            TimeManager.instance.SlowMotion(true);
            //Active camera Vignette
            cameraVignette.ActiveVignette();

            // Decrease pitch in backgrund music
            SoundManager.instance.ChangePitch("Background", 0.8f);

            //Mouse in wordl position 3d
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 50f, clickMask))
            {
                startPoint = hit.point;
                startPoint.z = -1f;
            }
        }

        if (Input.GetMouseButton(0))
        {
            //Avoid Interaction when menu exists
            if (EventSystem.current.IsPointerOverGameObject() && !GameManager.instance.isGamePlaying) return;

            //Current position is equal to start position
            Vector3 currentPoint = startPoint;

            //Mouse in wordl position 3d
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 50f, clickMask))
            {
                currentPoint = hit.point;
                currentPoint.z = -1f;
            }

            //Render the line every frame
            dragLine.RenderLine(startPoint, currentPoint);
        }

        if (Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
    }


    private void EndDrag(bool addForceToPlayer = true)
    {
        //Avoid Interaction when menu exists
        if (EventSystem.current.IsPointerOverGameObject() && !GameManager.instance.isGamePlaying) return;

        //Add gravity to player if need
        if (!isGravityPlayer)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            GameManager.instance.GamePlay();
            isGravityPlayer = true;
        }
        //Stop the slow motion
        TimeManager.instance.SlowMotion(false);
        //Deactive camera Vignette
        cameraVignette.DeactiveVignette();

        // Increase pitch in backgrund music
        SoundManager.instance.ChangePitch("Background", 1f);

        //Remove the DragLine
        dragLine.EndLine();

        //Mouse in wordl position 3d
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 50f, clickMask))
        {
            endPoint = hit.point;
            endPoint.z = -1f;
        }

        if (addForceToPlayer)
        {
            //Remove the Actual force of the player
            rb.velocity = Vector3.zero;
            //Add New force to the player
            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode.Impulse);
            transform.rotation = Quaternion.LookRotation(force);
        }
    }

    private Vector3 TrimLine()
    {
        Vector3 result = Vector3.zero;
        float hMax = 4f;
        Debug.Log("I:" + startPoint);
        Debug.Log("E:" + endPoint);

        float x = Mathf.Abs(endPoint.x - startPoint.x);
        float y = Mathf.Abs(endPoint.y - startPoint.y);
        float h = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));

        float startAngle = 1 / Mathf.Sin(x / h);

        float minX = Mathf.Sin(startAngle) * hMax;
        float minY = Mathf.Cos(startAngle) * hMax;

        if (endPoint.x - startPoint.x >= 0)
        {
            result.x = startPoint.x + minX;
        }
        else
        {
            result.x = startPoint.x - minX;
        }

        if (endPoint.y - startPoint.y >= 0)
        {
            result.y = startPoint.y + minY;
        }
        else
        {
            result.y = startPoint.y - minY;
        }
        result.z = -1f;
        return result;
    }
}

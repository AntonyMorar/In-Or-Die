using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
    [SerializeField] private float power = 5f;
    [SerializeField] private Vector2  minPower, maxPower;
    [SerializeField] private LayerMask clickMask;
    [Header("External Scripts")]
    [SerializeField] private TimeManager timeManager;
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
        if (Input.GetMouseButtonDown(0))
        {
            //Start the slow motion
            timeManager.SlowMotion(true);
            //Active camera Vignette
            cameraVignette.ActiveVignette();

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
            //Add gravity to player if need
            if (!isGravityPlayer)
            {
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                GameManager.instance.GamePlay();
                isGravityPlayer = true;
            }
            //Stop the slow motion
            timeManager.SlowMotion(false);
            //Deactive camera Vignette
            cameraVignette.DeactiveVignette();

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

            //Remove the Actual force of the player
            rb.velocity = Vector3.zero;

            //Add New force to the player
            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode.Impulse);
        }
    }
}

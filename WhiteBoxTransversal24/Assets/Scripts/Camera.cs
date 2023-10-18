using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float rotationSpeed = 1;
    Transform target, player;
    float mouseX, mouseY;
    Transform obstruction;
    public float zoomSpeed = 2f;
    public LayerMask layerMask;

    public int maxY;
    public int minY;

    public float distanceToPlayer = 5;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = GameObject.Find("Target").transform;
        obstruction = target;
        transform.position = target.position + new Vector3(distanceToPlayer, 1, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        MoveCamera();
        AvoidWalls();
    }

    void MoveCamera()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, minY, maxY);

        transform.LookAt(target);

        target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        player.rotation = Quaternion.Euler(0, mouseX, 0);
    }

    void AvoidWalls()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, target.position - transform.position, out hit, 4.5f, layerMask))
        {
            obstruction = hit.transform;
            // Uncomment to make the object dissappear
            //obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

            if (Vector3.Distance(obstruction.position, transform.position) >= 1f && Vector3.Distance(transform.position, target.position) >= 0.5f)
            {
                transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
            }
        }
        else
        {
            obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            if (Vector3.Distance(transform.position, target.position) < 4.5f)
            {
                transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
            }
        }
    }
}

using UnityEngine;

public class CameraController : MonoBehaviour
{
    // 主角和相机偏移
    private Vector3 offset;

    private Transform playerTransform;

    public float zoomSpeed = 10;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position + offset;
        // 鼠标滑轮
        var axis = Input.GetAxis("Mouse ScrollWheel");
        var mainFieldOfView = Camera.main.fieldOfView + axis * zoomSpeed;
        Camera.main.fieldOfView = Mathf.Clamp(mainFieldOfView, 20, 100);
    }
}
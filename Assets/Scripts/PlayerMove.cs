using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent PlayerAgent;

    public float moveSpeed;

    private CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        PlayerAgent = GetComponent<NavMeshAgent>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var hAxisRaw = Input.GetAxisRaw("Horizontal");
        var vAxisRaw = Input.GetAxisRaw("Vertical");
        //                                 指针位于游戏对象上
        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false)
        {
            // 主角看到的射线
            var screenPointToRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // 是否碰撞
            bool isCollide = Physics.Raycast(screenPointToRay, out hit);
            if (isCollide)
            {
                if (hit.collider.tag == "Ground")
                {
                    // 设置目的地
                    PlayerAgent.stoppingDistance = 0;
                    PlayerAgent.SetDestination(hit.point);
                }
                else if (hit.collider.tag == "Interactable")
                {
                    hit.collider.GetComponent<Interactable>().OnClick(PlayerAgent);
                }
            }
        }
        // 如果施加了水平或者锤子方向的力
        else if (hAxisRaw != 0 || vAxisRaw != 0)
        {
            PlayerAgent.ResetPath();
            Vector3 dir = transform.right * hAxisRaw + transform.forward * vAxisRaw;
            dir = dir.normalized;
            cc.Move(dir * Time.deltaTime * moveSpeed);
        }
    }
}
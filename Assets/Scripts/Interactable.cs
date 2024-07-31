

/*
 * 可交互
 */

using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    private NavMeshAgent playAgent;
    private bool haveInteracted = false;

    public void OnClick(NavMeshAgent playAgent)
    {
        this.playAgent = playAgent;
        playAgent.stoppingDistance = 3;
        // 设置目的地
        playAgent.SetDestination(transform.position);
        haveInteracted = false;
    }

    private void Update()
    {
        //                                                  路径挂起 表示路径已经走完了
        if (playAgent != null && haveInteracted == false && playAgent.pathPending == false)
        {
            if (playAgent.remainingDistance <= 3)
            {
                Interact();
                haveInteracted = true;
            }
        }
    }

    protected virtual void Interact()
    {
    }
}
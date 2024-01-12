using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public Player player;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(instance.gameObject);
    }

    public IEnumerator WalkToNewScene(Vector2 exitDir, float delay)
    {
        yield return new WaitForSeconds(0.001f);
        if (exitDir.y > 0)
        {
            player.ChangeVelocity(player.rb.velocity.x, player.JumpForce * exitDir.y);
        }
        if (exitDir.x != 0 )
        {
            float xAxis = exitDir.x > 0 ? 1 : -1;
            player.SetMoveDir(xAxis);
            player.stateMachine.ChangeState(player.moveState);
        }
        yield return new WaitForSeconds(delay);
        GameManager.Instance.isCutScene = false;
    }
   
}

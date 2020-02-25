using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DipPlayerState : IPlayerState
{
    Player mPlayer;
    Rigidbody rbPlayer;

    public void Enter(Player player)
    {
        //Debug.Log("Entering State: Ducking");
        rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.transform.position = Vector3.MoveTowards(rbPlayer.position, new Vector3(0, -.64f, 0), 3);
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        if (!Input.GetKey(KeyCode.X))
        {
            rbPlayer.transform.position = Vector3.MoveTowards(rbPlayer.position, new Vector3(0, .64f, 0), 3);
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }
    }
}

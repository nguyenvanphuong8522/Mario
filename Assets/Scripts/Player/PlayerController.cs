using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    IDLE,
    RUN,
    JUMP,
    FREEZE,
    DIE
}

public class PlayerController : MonoBehaviour
{
    public event Action<PlayerState> OnStateChange = delegate { };
    public PlayerState state;

    [SerializeField] private InputPlayer input;

    [SerializeField] private GroundCheck groundCheck;

    private Movement movement;

    private int coin;

    [SerializeField] private BoxCollider2D box;

    public HashSet<PowerUpType> powerUpsReceived = new HashSet<PowerUpType>();

    public AnimationPlayer animationPlayer;

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    private void OnEnable()
    {
        state = PlayerState.IDLE;
        input.EnableControl();
        ChangeState(state);
    }

    public void ChangeState(PlayerState state)
    {
        this.state = state;
        OnStateChange(state);
        if(state == PlayerState.DIE)
        {
            movement.DelaySetDie();
            input.DisableControl();
        }
            
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SizeUp();
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            SizeDown();
        }

        if (state == PlayerState.DIE || state == PlayerState.FREEZE) return;
        if (!groundCheck.IsGrounded)
        {
            ChangeState(PlayerState.JUMP);
            return;
        }

        if (input.Horizontal == 0)
        {
            ChangeState(PlayerState.IDLE);
            return;
        }

        ChangeState(PlayerState.RUN);
    }

    public void IncreaseCoin(int value)
    {
        coin += value;
        UiManager.instance.UpdateTxtCoin(coin.ToString());
    }

    public void SizeUp()
    {
        if (powerUpsReceived.Contains(PowerUpType.SIZE)) return;
        transform.localScale = Vector3.one * 2;
        Vector3 curPos = transform.position;
        curPos.y += box.size.y / 2;
        transform.position = curPos;
        powerUpsReceived.Add(PowerUpType.SIZE);
        ChangeState(PlayerState.FREEZE);
        animationPlayer.Play("sizeUp");
        StartCoroutine(DelayFreeze());
    }

    public void SizeDown()
    {
        if (!powerUpsReceived.Contains(PowerUpType.SIZE)) return;
        transform.localScale = Vector3.one;
        Vector3 curPos = transform.position;
        curPos.y -= box.size.y / 2;
        transform.position = curPos;
        powerUpsReceived.Remove(PowerUpType.SIZE);
        ChangeState(PlayerState.FREEZE);
        animationPlayer.SetLayer(1);
        StartCoroutine(DelayFreeze());
        StartCoroutine(DelayUnFlicker());
    }

    private IEnumerator DelayFreeze()
    {
        Freeze();
        yield return new WaitForSeconds(0.5f);
        UnFreeze();
    }
    private IEnumerator DelayUnFlicker()
    {
        yield return new WaitForSeconds(2f);
        animationPlayer.SetLayer(0);
    }

    private void Freeze()
    {
        input.DisableControl();
        movement.rb.simulated = false;
    }

    public void UnFreeze()
    {
        input.EnableControl();
        movement.rb.simulated = true;
        ChangeState(PlayerState.IDLE);
    }

}

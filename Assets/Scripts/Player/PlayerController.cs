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

    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        //powerUpsReceived.Add(PowerUpType.INVINCIBLE);
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
        if (Input.GetKeyDown(KeyCode.Z)) Shooting();
        if (Input.GetKeyDown(KeyCode.X)) StartCoroutine(DelayDiableInvincible());

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

    public void ActiveInvincible()
    {
        StartCoroutine(DelayDiableInvincible());
    }

    public void IncreaseCoin(int value)
    {
        coin += value;
        UiManager.instance.UpdateTxtCoin(coin.ToString());
    }

    public void SizeUp()
    {
        if (powerUpsReceived.Contains(PowerUpType.SIZE)) return;
        AudioManager.instance.Play(AudioManager.instance.listClip[5]);
        transform.localScale = Vector3.one * 2;
        Vector3 curPos = transform.position;
        curPos.y += box.size.y / 2;
        transform.position = curPos;
        AddPowerUp(PowerUpType.SIZE);
        ChangeState(PlayerState.FREEZE);
        animationPlayer.Play("sizeUp");
        StartCoroutine(DelayFreeze());
    }

    public void SizeDown()
    {
        if (!powerUpsReceived.Contains(PowerUpType.SIZE)) return;
        AudioManager.instance.Play(AudioManager.instance.listClip[6]);
        transform.localScale = Vector3.one;
        Vector3 curPos = transform.position;
        curPos.y -= box.size.y / 2;
        transform.position = curPos;
        RemovePowerUp(PowerUpType.SIZE);
        ChangeState(PlayerState.FREEZE);
        animationPlayer.SetWeightLayerSecond(1);
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
        animationPlayer.SetWeightLayerSecond(0);
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

    public void Shooting()
    {
        AudioManager.instance.Play(AudioManager.instance.listClip[7]);
        Vector2 direct = new Vector2(0.5f, -0.5f);
        Vector3 pointShoot = new Vector3(transform.position.x + .7f, transform.position.y, 0);
        if (spriteRenderer.flipX)
        {
            direct = new Vector2(-0.5f, -0.5f);
            pointShoot = new Vector3(transform.position.x - .7f, transform.position.y, 0);
        }

        PowerUpSpawner.instance.SpawnBullet(direct, pointShoot);
    }

    public bool IsInvincible()
    {
        return powerUpsReceived.Contains(PowerUpType.INVINCIBLE);
    }

    public bool IsBigSized()
    {
        return powerUpsReceived.Contains(PowerUpType.SIZE);
    }

    private IEnumerator DelayDiableInvincible()
    {
        AddPowerUp(PowerUpType.INVINCIBLE);
        animationPlayer.Play("Invincible", 1);
        animationPlayer.SetWeightLayerSecond(1);
        yield return new WaitForSeconds(10);
        animationPlayer.SetWeightLayerSecond(0);
        RemovePowerUp(PowerUpType.INVINCIBLE);

    }
    private void AddPowerUp(PowerUpType newPowerUp)
    {
        if (powerUpsReceived.Contains(newPowerUp)) return;
        powerUpsReceived.Add(newPowerUp);
    }
    private void RemovePowerUp(PowerUpType newPowerUp)
    {
        if (!powerUpsReceived.Contains(newPowerUp)) return;
        powerUpsReceived.Remove(newPowerUp);
    }
}

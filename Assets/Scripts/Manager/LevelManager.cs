using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Level> levels;
    public PlayerController playerPrefab;
    internal PlayerController player;
    public Level curLevel;
    public void SpawnLevel(int index)
    {
        if(player == null)
        player = Instantiate(playerPrefab);


        Camera.main.GetComponent<CameraFollow>().transform.position = new Vector3(0, 0, -10);
        Camera.main.GetComponent<CameraFollow>().SetUp(player);
        //Destroy(curLevel);
        curLevel = Instantiate(levels[index]);
        GameManager.instance.ChangeState(GameState.STARTED);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
  public Ball ball;
  public Wall wall;
  public static Vector2 bLeft;
  public static Vector2 tRight;
  public bool showHelp;

  // Start is called before the first frame update
  void Start() {

    // set screen position
    bLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
    tRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

    // creates 2 walls and a pong ball
    Instantiate(ball);
    Wall wallR = Instantiate(wall) as Wall;
    Wall wallL = Instantiate(wall) as Wall;
    wallR.InitWall(true);   // check if right wall
    wallL.InitWall(false);  // check if left wall
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKey("escape")) {
      Application.Quit();
    } else if (Input.GetKey("h")) {
      Time.timeScale = 0;
      pause();
    } else if (Input.GetKey("r")) {
      Time.timeScale = 1;
      resume();
    } else if (Input.GetKey("space")) {
      Application.LoadLevel(0);
      Time.timeScale = 1;
    }
  }

  void pause() {
    showHelp = true;
  }

  void resume() {
    showHelp = false;
  }

  void OnGUI() {
    if(showHelp) {
      GUI.Box(new Rect(700, 500, 500, 100),
      "Controls:\n Player 1: Use up and down arrow keys\n Player 2: Use w and s keys\n Press the space bar to reset\n Press r to resume play");
    }
  }
}

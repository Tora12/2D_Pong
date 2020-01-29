using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

  public bool isR;
  float speed;
  float height;
  string input;

  // Start is called before the first frame update
  void Start() {
    height = transform.localScale.y;
    speed = 5;
  }

  // Update is called once per frame
  void Update() {

    float move = Input.GetAxis(input) * Time.deltaTime * speed;

    // checks for wall top and bottom boundaries and stop wall movement if at boundary
    if((transform.position.y < GameManager.bLeft.y + height / 2 && move < 0)
    || (transform.position.y > GameManager.tRight.y - height / 2 && move > 0)) {
      move = 0;
    }

    transform.Translate(move * Vector2.up);
  }

  // sets positions for wallR and wallL
  public void InitWall(bool isRight) {

    isR = isRight;
    Vector2 position = Vector2.zero;

    if(isRight) {
      position = new Vector2(GameManager.tRight.x, 0);
      input = "WallRight";
    } else {
      position = new  Vector2(GameManager.bLeft.x, 0);
      input = "WallLeft";
    }

    // update walls positions and names
    transform.position = position;
    transform.name = input;
  }
}

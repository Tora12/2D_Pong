using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

  float speed;
  float radius;
  Vector2 direction;

  // Start is called before the first frame update
  void Start() {
    direction = Vector2.one.normalized;
    radius = transform.localScale.x / 2;
    speed = 5;
  }

  // Update is called once per frame
  void Update() {

    Vector2 position = Vector2.zero;

    transform.Translate(direction * speed * Time.deltaTime);

    // checks ball top and bottom boundaries and redirects
    if ((transform.position.y < GameManager.bLeft.y + radius && direction.y < 0)
    || (transform.position.y > GameManager.tRight.y - radius && direction.y > 0)) {
      direction.y = -direction.y;
    }

    // checks if ball hits goal
    if (transform.position.x < GameManager.bLeft.x + radius && direction.x < 0) {
      Debug.Log("Right Wins");
      position = new Vector2(0, 0);
      transform.position = position;
      Time.timeScale = 0;
    } else if (transform.position.x > GameManager.tRight.x - radius && direction.x > 0) {
      Debug.Log("Left Wins");
      position = new Vector2(0, 0);
      transform.position = position;
      Time.timeScale = 0;
    }
  }

  void OnTriggerEnter2D(Collider2D other) {

    if(other.tag == "Wall") {
      bool isR = other.GetComponent<Wall>().isR;

      // checks if ball hits wall and redirects ball if true
      if(isR == true && direction.x > 0) {
        direction.x = -direction.x;
      } else if (isR == false && direction.x < 0) {
        direction.x = -direction.x;
      }
    }

  }
}

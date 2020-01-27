using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuerdas : MonoBehaviour
{
    float fuerzaSalto;
    GameObject player;
    Player playerScript;
    Rigidbody2D playerRB;
    float climbSpeed;
    [SerializeField]
    bool climbing;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        playerScript = player.GetComponent<Player>();
        climbSpeed = 3;
        climbing = false;
        fuerzaSalto = 9.25f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                playerRB.velocity = new Vector2(0, Input.GetAxisRaw("Vertical") * climbSpeed);
                playerRB.gravityScale = 0;
                climbing = true;
                playerScript.AgarradoCuerda = true;
            }
            else if (Input.GetAxisRaw("Vertical") == 0 && climbing)
            {
                playerRB.velocity = new Vector2(0, 0);
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                climbing = false;
                playerScript.AgarradoCuerda = false;
                playerRB.gravityScale = 3;
                playerRB.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            climbing = false;
            playerScript.AgarradoCuerda = false;
            playerRB.gravityScale = 3;

        }
    }

}

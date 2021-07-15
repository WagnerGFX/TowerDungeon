using System.Collections;
using TowerDungeon.UI;
using UnityEngine;

namespace TowerDungeon.Character
{
    public class ForcePowerUp : MonoBehaviour
    {
        public SpriteRenderer player_sprite;
        public PlayerLife playerLife_script;
        public int savePreviousPower;

        public PlayerControl playerControl_script;
        int powered;
        public bool powerUpActivated = false;
        public PowerUpUI powerUpUI_script;

        void Start()
        {
            playerLife_script = GetComponent<PlayerLife>();
            playerControl_script = GetComponent<PlayerControl>();

            savePreviousPower = playerControl_script.myPower;
            powered = 5;
            player_sprite = GetComponent<SpriteRenderer>();
            powerUpUI_script.ActiveFeedbackPowerUp(powerUpUI_script.ImageForce, powerUpActivated);
        }

        void Update()
        {
            if (powerUpActivated)
            {
                player_sprite.color = Color.Lerp(Color.blue, Color.white, Mathf.PingPong(2 * Time.time, .5f));
                powerUpUI_script.ActiveFeedbackPowerUp(powerUpUI_script.ImageForce, powerUpActivated);
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("force"))
            {
                StartCoroutine(nameof(growPower));
            }
        }

        IEnumerator growPower()
        {
            powerUpActivated = true;
            playerControl_script.myPower = powered;
            Debug.Log(playerControl_script.myPower);
            yield return new WaitForSeconds(10f);
            powerUpActivated = false;
            player_sprite.color = Color.white;
            playerControl_script.myPower = savePreviousPower;
            Debug.Log("Power atual: " + playerControl_script.myPower);
            powerUpUI_script.ActiveFeedbackPowerUp(powerUpUI_script.ImageForce, powerUpActivated);
        }
    }
}



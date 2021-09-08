using System.Collections;
using TowerDungeon.UI;
using UnityEngine;

namespace TowerDungeon.Character
{
    public class SpeedPowerUp : MonoBehaviour
    {
        private PlayerControl playerControl;
        private SpriteRenderer playerSprite;
        private PowerUpUI powerUpUI;
        private bool isSlow = false;
        private bool isFast = false;
        private float speedModifier = 5f;
        private float attackRateModifier = 1f; //In seconds
        private float effectDuration = 10f;    //In seconds

        void Start()
        {
            playerControl = GetComponent<PlayerControl>();
            playerSprite = GetComponent<SpriteRenderer>();
            powerUpUI = GameObject.Find("panelpowerUp")?.GetComponent<PowerUpUI>();
            powerUpUI?.ActiveFeedbackPowerUp(powerUpUI.ImageFast, isFast);
            powerUpUI?.ActiveFeedbackPowerUp(powerUpUI.ImageSlow, isSlow);
        }

        void Update()
        {
            SlowAndFastCondition();
        }

        void SlowAndFastCondition()
        {
            if (isSlow)
            {
                if (isFast)
                {
                    isFast = false;
                    playerSprite.color = Color.Lerp(Color.red, Color.white, Mathf.PingPong(2 * Time.time, .5f));
                    powerUpUI?.ActiveFeedbackPowerUp(powerUpUI.ImageSlow, isSlow);
                    powerUpUI?.ActiveFeedbackPowerUp(powerUpUI.ImageFast, isFast);
                }
                playerSprite.color = Color.Lerp(Color.red, Color.white, Mathf.PingPong(2 * Time.time, .5f));
            }

            else if (isFast)
            {
                if (isSlow)
                {
                    isSlow = false;
                    playerSprite.color = Color.Lerp(Color.blue, Color.white, Mathf.PingPong(2 * Time.time, .5f));
                    powerUpUI?.ActiveFeedbackPowerUp(powerUpUI.ImageSlow, isSlow);
                    powerUpUI?.ActiveFeedbackPowerUp(powerUpUI.ImageFast, isFast);
                }
                playerSprite.color = Color.Lerp(Color.blue, Color.white, Mathf.PingPong(2 * Time.time, .5f));

            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("speedUp"))
            {
                if (!isFast)
                {
                    StartCoroutine(nameof(PowerUpSpeed));
                }

            }
            else if (other.gameObject.CompareTag("speedDown"))
            {
                if (!isSlow)
                {
                    StartCoroutine(nameof(PowerDownSpeed));
                }
            }
        }

        public IEnumerator PowerUpSpeed()
        {
            //Apply Effect
            isFast = true;
            attackRateModifier = -0.7f; //Remove later
            playerControl.moveSpeedModifier += speedModifier;
            playerControl.attackRateModifier += attackRateModifier;
            yield return new WaitForSeconds(effectDuration);

            //Revert Effect
            isFast = false;
            playerSprite.color = Color.white;
            playerControl.moveSpeedModifier -= speedModifier;
            playerControl.attackRateModifier -= attackRateModifier;
        }

        public IEnumerator PowerDownSpeed()
        {
            //Apply Effect
            isSlow = true;
            attackRateModifier = 1f; //Remove later
            playerControl.moveSpeedModifier += speedModifier;
            playerControl.attackRateModifier += attackRateModifier;
            yield return new WaitForSeconds(effectDuration);

            //Revert Effect
            isSlow = false;
            playerSprite.color = Color.white;
            playerControl.moveSpeedModifier -= speedModifier;
            playerControl.attackRateModifier -= attackRateModifier;
        }
    }
}
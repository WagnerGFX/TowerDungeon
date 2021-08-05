using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TowerDungeon.Management;
using TowerDungeon.Events;

namespace TowerDungeon.Character
{
    public class PlayerLife : MonoBehaviour
    {
        [SerializeField]
        GameStateRequestEventChannelSO gameStateChangeRequestChannel;


        public PlayerSO playerScriptalbe;
        public int life;
        public int numberOfHearts;
        public Image[] hearts;
        public Sprite fullHeart;
        public Sprite emptyHeart;
        public PlayerAnimations player_anim;
        private Text pointTxt;
        bool invencibility;
        public SpriteRenderer playerSprite;

        private void Awake()
        {

            life = playerScriptalbe.life;
            numberOfHearts = life;
        }

        private void Start()
        {
            pointTxt = GameObject.Find("pointsTxt").GetComponent<Text>();
            playerSprite = GetComponent<SpriteRenderer>();
            invencibility = false;
        }

        void Update()
        {
            ControlHearts();
            if (invencibility)
            {
                playerSprite.color = Color.Lerp(Color.white, new Color(255, 255, 255, 0), Mathf.PingPong(2 * Time.time, .5f));
            }

        }

        void ControlHearts()
        {
            if (life > numberOfHearts)
            {
                life = numberOfHearts;
            }

            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < life)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }
                if (i < numberOfHearts)
                {
                    hearts[i].enabled = true;
                }
                else
                {
                    hearts[i].enabled = false;
                }
            }
        }

        public float TakeDamage()
        {
            if (!invencibility)
            {
                player_anim.DamageAnim();
                life = life - 1;
                StartCoroutine("Invencibility");
            }

            return life;
        }

        IEnumerator Invencibility()
        {
            Debug.Log("começo");
            invencibility = true;
            //  playerSprite.color = new Color(255,255,255,76);
            yield return new WaitForSeconds(2f);
            Debug.Log("fim");
            invencibility = false;
            playerSprite.color = new Color(255, 255, 255, 255);

        }

        //little-2 hearts
        //medium-3 hearts
        //hard- 6 hearts
        public float RestoreLife(int recoverIntensity)
        {
            life += recoverIntensity;
            return life;
        }

        public void VerifyGameCondition()
        {
            if (life <= 0)
            {
                gameStateChangeRequestChannel?.RaiseEvent(GameState.GameOver);
            }
        }
    }
}
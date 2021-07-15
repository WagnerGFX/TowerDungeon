using UnityEngine;

namespace TowerDungeon.UI
{
    public class PowerUpUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject slow_img, fast_img, poison_img, force_img;


        public GameObject ImageSlow { get { return slow_img; } }

        public GameObject ImageFast { get { return fast_img; } }

        public GameObject ImagePoison { get { return poison_img; } }

        public GameObject ImageForce { get { return force_img; } }

        public void ActiveFeedbackPowerUp(GameObject powerObj, bool activated)
        {
            powerObj.SetActive(activated);
        }
    }
}

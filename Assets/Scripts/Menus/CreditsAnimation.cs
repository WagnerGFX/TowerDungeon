using UnityEngine;

namespace TowerDungeon.Menus
{
    public class CreditsAnimation : MonoBehaviour
    {
        [SerializeField] [Min(0)]
        private float scrollSpeed = 100f;

        [SerializeField]
        private RectTransform canvasRect;

        [SerializeField]
        private RectTransform creditsRect;

        void Update()
        {
            MoveCredits();
        }

        private void MoveCredits()
        {
            float nextStep = scrollSpeed * Time.deltaTime;
            Vector3 directionVector = new Vector3(0, nextStep, 0);

            creditsRect.Translate(directionVector);

            float creditsEndpoint = creditsRect.position.y - creditsRect.rect.height;

            if (creditsEndpoint >= canvasRect.rect.height)
            {
                directionVector.y = -(canvasRect.rect.height + creditsRect.rect.height);
                creditsRect.Translate(directionVector);
            }
        }
    }
}

using UnityEngine;

namespace TowerDungeon.Menus
{
    public class TowerAscentionAnimation : MonoBehaviour
    {
        private enum ScrollDirection { Up = 1, Down = -1 }
        [Header("Scrolling")]
        [SerializeField]
        [Min(0)]
        private float scrollSpeed = 5f;

        [SerializeField]
        [Min(0)]
        private float scrollAcceleration = 1f;

        [SerializeField]
        private ScrollDirection scrollDirection = ScrollDirection.Down;

        [Header("Sections")]
        [SerializeField]
        private float distanceBetweenSections = 4.93f;

        [SerializeField]
        private Transform[] towerSections;

        private Transform topSection;
        private Transform bottomSection;
        private float topReturnPoint;
        private float bottomReturnPoint;
        private float currentSpeed = 0f;

        // Start is called before the first frame update
        void Start()
        {
            if (towerSections != null && towerSections.Length > 0)
                InitialSetup();
        }

        // Update is called once per frame
        void Update()
        {
            if (towerSections != null && towerSections.Length > 0)
                MoveTowerSections();
        }

        private void InitialSetup()
        {
            topSection = towerSections[0];
            bottomSection = towerSections[0];

            for (int i = 1; i < towerSections.Length; i++)
            {
                if (topSection.position.y < towerSections[i].position.y)
                    topSection = towerSections[i];

                if (bottomSection.position.y > towerSections[i].position.y)
                    bottomSection = towerSections[i];
            }

            topReturnPoint = topSection.position.y + distanceBetweenSections / 2;
            bottomReturnPoint = bottomSection.position.y - distanceBetweenSections / 2;
        }

        private float GetCurrentSpeed()
        {
            float returnSpeed;

            if (currentSpeed < scrollSpeed)
            {
                currentSpeed += scrollAcceleration * Time.deltaTime;
                returnSpeed = currentSpeed * Time.deltaTime;
            }
            else
            {
                returnSpeed = scrollSpeed * Time.deltaTime;
            }

            returnSpeed *= (float)scrollDirection;

            return returnSpeed;
        }

        private void MoveTowerSections()
        {
            float nextStep = GetCurrentSpeed();
            Vector3 directionVector = new Vector3(0, nextStep, 0);

            Transform newTopSection = null;
            Transform newBottomSection = null;

            for (int i = 0; i < towerSections.Length; i++)
            {
                towerSections[i].Translate(directionVector);

                if (towerSections[i].position.y <= bottomReturnPoint)
                    newTopSection = towerSections[i];
                else if (towerSections[i].position.y >= topReturnPoint)
                    newBottomSection = towerSections[i];
            }

            if (newTopSection != null)
            {
                Vector3 newPos = topSection.position;
                newPos.y += distanceBetweenSections;

                newTopSection.SetPositionAndRotation(newPos, newTopSection.rotation);
                topSection = newTopSection;
            }
            else if (newBottomSection != null)
            {
                Vector3 newPos = bottomSection.position;
                newPos.y -= distanceBetweenSections;

                newBottomSection.SetPositionAndRotation(newPos, newBottomSection.rotation);
                bottomSection = newBottomSection;
            }
        }
    }
}
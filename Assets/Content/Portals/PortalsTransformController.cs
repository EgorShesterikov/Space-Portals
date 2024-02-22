using System.Collections.Generic;
using UnityEngine;

namespace SpacePortals
{
    public class PortalsTransformController : MonoBehaviour
    {
        private int PORTALS_ON_ONE_SIDE = 4;
        private int PORTALS_SIDES = 2;

        private int FIRST_PORTALS_INDEX = 0;
        private int SECOND_PORTALS_INDEX = 1;

        [SerializeField] private List<PortalsCouple> _portalsCouples;
        [SerializeField] private ParticleSystem _swapEffect;

        private Vector3[,] _defaultPositions;

        public void Awake()
        {
            _defaultPositions = new Vector3[PORTALS_ON_ONE_SIDE, PORTALS_SIDES];

            for (int i = 0; i < _portalsCouples.Count; i++)
            {
                _defaultPositions[i, FIRST_PORTALS_INDEX] = _portalsCouples[i].FirstPortalTransform.position;
                _defaultPositions[i, SECOND_PORTALS_INDEX] = _portalsCouples[i].SecondPortalTransform.position;
            }
        }

        public void RandomMove()
        {
            int side = GetRandomIndexSide();

            int portal_1 = GetRandomIndexPortal();
            int portal_2 = GetRandomIndexPortal();

            while (portal_1 == portal_2)
                portal_2 = GetRandomIndexPortal();

            if (side == FIRST_PORTALS_INDEX)
            {
                Instantiate(_swapEffect, _portalsCouples[portal_1].FirstPortalTransform.position, Quaternion.identity);
                Instantiate(_swapEffect, _portalsCouples[portal_2].FirstPortalTransform.position, Quaternion.identity);

                Vector3 portal_1_position = _portalsCouples[portal_1].FirstPortalTransform.position;
                _portalsCouples[portal_1].FirstPortalTransform.position = _portalsCouples[portal_2].FirstPortalTransform.position;
                _portalsCouples[portal_2].FirstPortalTransform.position = portal_1_position;
            }
            else if(side == SECOND_PORTALS_INDEX)
            {
                Instantiate(_swapEffect, _portalsCouples[portal_1].SecondPortalTransform.position, Quaternion.identity);
                Instantiate(_swapEffect, _portalsCouples[portal_2].SecondPortalTransform.position, Quaternion.identity);

                Vector3 portal_1_position = _portalsCouples[portal_1].SecondPortalTransform.position;
                _portalsCouples[portal_1].SecondPortalTransform.position = _portalsCouples[portal_2].SecondPortalTransform.position;
                _portalsCouples[portal_2].SecondPortalTransform.position = portal_1_position;
            }
        }
        public void SetDefaultPos()
        {
            for (int i = 0; i < _portalsCouples.Count; i++)
            {
                _portalsCouples[i].FirstPortalTransform.position = _defaultPositions[i, FIRST_PORTALS_INDEX];
                _portalsCouples[i].SecondPortalTransform.position = _defaultPositions[i, SECOND_PORTALS_INDEX];

                Instantiate(_swapEffect, _portalsCouples[i].FirstPortalTransform.position, Quaternion.identity);
                Instantiate(_swapEffect, _portalsCouples[i].SecondPortalTransform.position, Quaternion.identity);
            }
        }

        private int GetRandomIndexSide()
            => Random.Range(0, PORTALS_SIDES);
        private int GetRandomIndexPortal()
            => Random.Range(0, PORTALS_ON_ONE_SIDE);
    }
}
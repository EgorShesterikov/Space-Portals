using System;

namespace SpacePortals
{
    [Serializable]
    public class BallSkinInfo
    {
        public BallTypes Type;
        public bool IsOpen = false;

        public BallSkinInfo(BallTypes type, bool isOpen) 
        {
            Type = type;
            IsOpen = isOpen;
        }
    }
}

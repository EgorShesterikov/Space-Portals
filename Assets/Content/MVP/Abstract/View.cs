using UnityEngine;

namespace SpacePortals
{
    public abstract class View : MonoBehaviour
    {
        [SerializeField] private MainMenuView _mainMenuView;
        [SerializeField] private StoreView _storeView;
        [SerializeField] private SettingsView _settingsView;
        [SerializeField] private PlayerControllerView _playerControllerView;
        [SerializeField] private PlayMenuView _playMenuView;
        [SerializeField] private ResultMenuView _resultMenuView;
        [SerializeField] private StarsIndicationView _starsIndicationView;
        [SerializeField] private TimeIndicationView _timeIndicationView;

        public MainMenuView MainMenuView => _mainMenuView;
        public StoreView StoreView => _storeView;
        public SettingsView SettingsView => _settingsView;
        public PlayerControllerView PlayerControllerView => _playerControllerView;
        public PlayMenuView PlayMenuView => _playMenuView;
        public ResultMenuView ResultMenuView => _resultMenuView;
        public StarsIndicationView StarsIndicationView => _starsIndicationView;
        public TimeIndicationView TimeIndicationView => _timeIndicationView;

        public abstract void DisplayOnMainMenu(bool isActiv);
        public abstract void DisplayOnStoreMenu(bool isActiv);
        public abstract void DisplayOnSettingsMenu(bool isActiv);
        public abstract void DisplayOnPlayerController(bool isActiv);
        public abstract void DisplayOnResultMenu(bool isActiv);
        public abstract void DisplayOnPlayMenu(bool isActiv);

        public abstract void DisplayOnMusicSliderValue(float value);
        public abstract void DisplayOnSFXSliderValue(float value);

        public abstract void DisplayStarsValue(int value);

        public abstract void DisplayOnCurrentTimeInResultsMenu(int second);
        public abstract void DisplayOnCollectedStarsInResultsMenu(int value);

        public abstract void DisplayOnCurrentTime(int second);
        public abstract void DisplayOnRecordTime(int second);

        public abstract void DisplayOnSkinBallInStoreMenu(BallTypes type);
        public abstract void DisplayOnCostInBuyButtonInStoreMenu(int value);
        public abstract void DisplayOnSelectInBuyButtonInStoreMenu();
    }
}
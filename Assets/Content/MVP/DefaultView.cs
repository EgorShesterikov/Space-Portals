using SupportScipts;

namespace SpacePortals
{
    public class DefaultView : View
    {
        public override void DisplayOnMainMenu(bool isActiv)
        {
            if (isActiv == true)
                MainMenuView.Open();
            else 
                MainMenuView.Close();
        }
        public override void DisplayOnStoreMenu(bool isActiv)
        {
            if (isActiv == true)
                StoreView.Open();
            else
                StoreView.Close();
        }
        public override void DisplayOnSettingsMenu(bool isActiv)
        {
            if (isActiv == true)
                SettingsView.Open();
            else
                SettingsView.Close();
        }
        public override void DisplayOnPlayerController(bool isActiv)
        {
            if (isActiv == true)
                PlayerControllerView.Open();
            else
                PlayerControllerView.Close();
        }
        public override void DisplayOnResultMenu(bool isActiv)
        {
            if (isActiv == true)
                ResultMenuView.Open();
            else
                ResultMenuView.Close();
        }
        public override void DisplayOnPlayMenu(bool isActiv)
        {
            if (isActiv == true)
                PlayMenuView.Open();
            else
                PlayMenuView.Close();
        }

        public override void DisplayOnMusicSliderValue(float value)
            => SettingsView.MusicSlider.value = value;
        public override void DisplayOnSFXSliderValue(float value)
            => SettingsView.SfxSlider.value = value;

        public override void DisplayStarsValue(int value)
            => StarsIndicationView.StarsCountText.text = value.ToString();

        public override void DisplayOnCurrentTimeInResultsMenu(int second)
            => ResultMenuView.CurrentTimeText.text = $"Time: {SecondConverter.ConvertSecondInTimeFormat(second)}";
        public override void DisplayOnCollectedStarsInResultsMenu(int value)
            => ResultMenuView.CollectedStarsText.text = $"Stars: {value}";

        public override void DisplayOnCurrentTime(int second)
            => TimeIndicationView.TimeText.text = $"Time: {SecondConverter.ConvertSecondInTimeFormat(second)}";
        public override void DisplayOnRecordTime(int second)
            => TimeIndicationView.TimeText.text = $"Record: {SecondConverter.ConvertSecondInTimeFormat(second)}";
    }
}
using SupportScipts;
using YG;

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
            => ResultMenuView.CurrentTimeText.text = $"{SecondConverter.ConvertSecondInTimeFormat(second)}";
        public override void DisplayOnCollectedStarsInResultsMenu(int value)
        {
            string starsText;

            if(YandexGame.lang == "ru")
                starsText = $"Звезды: {value}";
            else
                starsText = $"Stars: {value}";

            ResultMenuView.CollectedStarsText.text = starsText;
        }

        public override void DisplayOnCurrentTime(int second)
        {
            string starsText;

            if (YandexGame.lang == "ru")
                starsText = $"Время: {SecondConverter.ConvertSecondInTimeFormat(second)}";
            else
                starsText = $"Time: {SecondConverter.ConvertSecondInTimeFormat(second)}";

            TimeIndicationView.TimeText.text = starsText;
        }
        public override void DisplayOnRecordTime(int second)
        {
            string starsText;

            if (YandexGame.lang == "ru")
                starsText = $"Рекорд: {SecondConverter.ConvertSecondInTimeFormat(second)}";
            else
                starsText = $"Record: {SecondConverter.ConvertSecondInTimeFormat(second)}";


            TimeIndicationView.TimeText.text = starsText;
        }

        public override void DisplayOnSkinBallInStoreMenu(BallTypes type)
            => StoreView.DisplaySkinAndNameBall(type);
        public override void DisplayOnCostInBuyButtonInStoreMenu(int value)
            => StoreView.DisplayCostInBuyButton(value);
        public override void DisplayOnSelectInBuyButtonInStoreMenu()
            => StoreView.DisplaySelectInBuyButton();
    }
}
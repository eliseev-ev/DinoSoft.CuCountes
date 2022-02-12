using DinoSoft.CuCounters.Domain.Infrastructure;

namespace DinoSoft.CuCounters.BlazorApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            this.MainPage = new MainPage();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            Window window = base.CreateWindow(activationState);

            window.Deactivated += (s, e) =>
            {
                //mainDataManager.SaveCurrent();
            };

            window.Destroying += (s, e) =>
            {
                //mainDataManager.SaveCurrent();
            };

            window.Stopped += (s, e) =>
            {
                //mainDataManager.SaveCurrent();
            };

            return window;
        }
    }
}
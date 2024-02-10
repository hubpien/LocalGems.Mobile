namespace LocalGems
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NAaF1cXmhLYVJ2WmFZfVpgcV9EZVZSQWYuP1ZhSXxXdkdjWn9bcnFWQ2VcV0U=");
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}

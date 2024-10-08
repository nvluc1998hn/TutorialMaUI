namespace TutorialMaUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            Routing.RegisterRoute(nameof(Views.UserDetailView), typeof(Views.UserDetailView));
            InitializeComponent();
        }
    }
}

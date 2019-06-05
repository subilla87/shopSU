namespace shopSU.UIForms.Infrastructure
{
    using shopSU.UIForms.ViewModels;
    class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}

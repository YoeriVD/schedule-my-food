namespace ScheduleMyFood.Main
{
    public interface IMainViewModel
    {
        string MainText { get; }
    }

    class MainViewModel : IMainViewModel
    {
        public string MainText => "Test with AutoFac";
    }
}

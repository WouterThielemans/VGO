using System.Windows.Input;
using ViewModel.Commands;

namespace ViewModel
{
    public class StartVM
    {
        public MainWindowVM MainWindowVM { get; }
        public ICommand select { get; }
        public ICommand quit { get; }
        public StartVM(MainWindowVM mainWindowVM)
        {
            MainWindowVM = mainWindowVM;
            select = new LevelSelectCommand(MainWindowVM);
            quit = new CloseCommand(MainWindowVM);
        }
    }
}
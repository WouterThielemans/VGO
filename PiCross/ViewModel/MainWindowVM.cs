using PiCross;
using System;
using System.ComponentModel;

namespace ViewModel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private object activeScreen;
        public PiCrossFacade PiCrossFacade { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        public Action Close { get; set; }
       
        public MainWindowVM()
        {
            ActiveScreen = new StartVM(this);
            PiCrossFacade = new PiCrossFacade();
        }

        //Change screen on Notify
        public object ActiveScreen
        {
            get => activeScreen;
            set
            {
                activeScreen = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(ActiveScreen)));
                }
            }
        }        

        //Go back to start 
        public void ReturnToStartScreen() => ActiveScreen = new StartVM(this);

        //Open puzzle select
        public void Select() => ActiveScreen = new LevelSelectVM(this);

        //Start chosen puzzle 
        public void StartSelect(Puzzle puzzle) => ActiveScreen = new GameVM(this, puzzle);

        //Close the program
        public void CloseWindow()
        {
            ActiveScreen = null;
            Close.Invoke();
        }
    }
}
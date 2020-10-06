using PiCross;
using System;
using System.Windows.Input;

//Contains all the commands used in the ViewModel
namespace ViewModel.Commands
{
    //Go to start screen
    public class ReturnToStartCommand : ICommand
    {
        private MainWindowVM MainWindowVM;
        private bool canExecute;
        public ReturnToStartCommand(MainWindowVM mvm)
        {
            MainWindowVM = mvm;
            canExecute = true;
        }
        //add{} and remove{} are for not getting warnings while compiling
        public event EventHandler CanExecuteChanged { add{} remove{} }

        public void Execute(object o) => MainWindowVM.ReturnToStartScreen();

        public bool CanExecute(object o) => canExecute;
    }

    //Quit program
    public class CloseCommand : ICommand
    {
        private MainWindowVM MainWindowVM;
        private bool canExecute;

        public CloseCommand(MainWindowVM mvm)
        {
            MainWindowVM = mvm;
            canExecute = true;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }
        public void Execute(object o) => MainWindowVM.CloseWindow();

        public bool CanExecute(object o) => canExecute;
    }

    //Open the levelSelect screen
    public class LevelSelectCommand : ICommand
    {
        public MainWindowVM MainWindowVM;
        private bool canExecute;

        public LevelSelectCommand(MainWindowVM mvm)
        {
            MainWindowVM = mvm;
            canExecute = true;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }

        public void Execute(object o) => MainWindowVM.Select();

        public bool CanExecute(object o) => canExecute;
    }

    //Open the selected puzzle
    public class SelectPuzzleCommand : ICommand
    {
        public MainWindowVM MainWindowVM { get; }

        public SelectPuzzleCommand(MainWindowVM mvm) => MainWindowVM = mvm;

        public event EventHandler CanExecuteChanged { add{} remove{} }

        public void Execute(object o)
        {
            var puzzel = o as Puzzle;
            MainWindowVM.StartSelect(puzzel);
        }

        public bool CanExecute(object o) => true;
    }

    //Clicked on square in puzzle
    public class ClickSquareCommand : ICommand
    {
        private SquareVM SquareVM;
        private bool canExecute;

        public ClickSquareCommand(SquareVM svm)
        {
            SquareVM = svm;
            canExecute = true;
        }

        public event EventHandler CanExecuteChanged { add{} remove{} }

        public void Execute(object o)
        {
            //Change button on click to filled or empty, depends on previous value
            var square = o as IPlayablePuzzleSquare;

            if (square.Contents.Value == Square.FILLED)
            {
                square.Contents.Value = Square.EMPTY;
            }
            else
            {
                square.Contents.Value = Square.FILLED;
            }
        }
        public bool CanExecute(object o) => canExecute;
    }
}
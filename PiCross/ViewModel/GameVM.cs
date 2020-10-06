using Cells;
using DataStructures;
using PiCross;
using System;
using System.Windows.Input;
using ViewModel.Commands;

namespace ViewModel
{
    public class GameVM
    {
        public Cell<IGrid<SquareVM>> grid { get; }
        public Cell<bool> IsSolved { get; }
        public MainWindowVM MainWindowVM { get; }
        public ICommand back { get; }
        public ICommand quit { get; }
        public Action close { get; }
        public Puzzle Puzzle { get; }
        public IPlayablePuzzle PlayablePuzzle { get; set; }

        //Constructor
        public GameVM(MainWindowVM mainWindowVM, Puzzle puzzle)
        {
            MainWindowVM = mainWindowVM;
            Puzzle = puzzle;
            grid = Cell.Create<IGrid<SquareVM>>(null);
            back = new ReturnToStartCommand(MainWindowVM);
            quit = new CloseCommand(MainWindowVM);
            IsSolved = Cell.Create(false);
            Start();
        }

        public void Start()
        {
            var facade = new PiCrossFacade();
            PlayablePuzzle = facade.CreatePlayablePuzzle(Puzzle);
            PlayablePuzzle.IsSolved.ValueChanged += IsSolvedValueChanged;
            grid.Value = PlayablePuzzle.Grid.Map(square => new SquareVM(square)).Copy();
        }

        //Check if puzzle is correct
        private void IsSolvedValueChanged() => IsSolved.Value = PlayablePuzzle.IsSolved.Value;
    }
}
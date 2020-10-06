using PiCross;
using System.Collections;
using System.Windows.Input;
using ViewModel.Commands;

namespace ViewModel
{
    public class LevelSelectVM
    {
        public MainWindowVM MainWindowVM { get; }
        public ICommand back { get; }
        public ICommand select { get; }
        public ArrayList puzzles { get; }

        //Constructor
        public LevelSelectVM(MainWindowVM mainWindowVM)
        {
            MainWindowVM = mainWindowVM;
            var data = MainWindowVM.PiCrossFacade.CreateDummyGameData();
            var puzzleList = data.PuzzleLibrary.Entries;
            puzzles = new ArrayList();
            foreach (IPuzzleLibraryEntry puzzle in puzzleList)
            {
                puzzles.Add(puzzle.Puzzle);
            }

            back = new ReturnToStartCommand(MainWindowVM);
            select = new SelectPuzzleCommand(MainWindowVM);
        }
    }
}
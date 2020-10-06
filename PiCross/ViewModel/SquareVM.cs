using Cells;
using PiCross;
using System.Windows.Input;
using ViewModel.Commands;
namespace ViewModel
{
    public class SquareVM
    {
        public ICommand Click { get; }
        public IPlayablePuzzleSquare Square { get; }
        public Cell<Square> Contents{
            get{
                return Square.Contents;
            }
        }
        public SquareVM(IPlayablePuzzleSquare square){
            Square = square;
            Click = new ClickSquareCommand(this);
        }
    }
}
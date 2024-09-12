using System;

namespace WpfApp8
{
    public class Tile
    {
        public bool IsRevealed { get; private set; }
        public bool IsFlagged { get; set; }
        public int AdjacentMinesCount { get; set; }
        public Action RevealAction { get; set; }

        public Tile(Action revealAction)
        {
            IsRevealed = false;
            IsFlagged = false;
            AdjacentMinesCount = 0;
            RevealAction = revealAction;
        }

        public void Reveal()
        {
            if (!IsFlagged && !IsRevealed)
            {
                RevealAction?.Invoke();
                IsRevealed = true;
            }
        }

        public override string ToString()
        {
            return IsRevealed ? (IsFlagged ? "F" : AdjacentMinesCount > 0 ? AdjacentMinesCount.ToString() : ".") : " ";
        }
    }
}

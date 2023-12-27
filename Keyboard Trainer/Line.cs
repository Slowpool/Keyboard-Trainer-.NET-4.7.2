namespace Keyboard_Trainer
{
    internal abstract class Line
    {
        protected int MaxLength { get; set; }
        public Line(int MaxLength)
        {
            this.MaxLength = MaxLength;
        }
    }
}
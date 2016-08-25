namespace DpiConverter.Data
{
    internal class TargetRecord
    {
        private readonly string targetIndex;
        private readonly double targetHeight;

        public TargetRecord(string targetIndex, double targetHeight)
        {
            this.targetIndex = targetIndex;
            this.targetHeight = targetHeight;
        }

        public double TargetHeight
        {
            get
            {
                return this.targetHeight;
            }
        }

        public string TargetIndex
        {
            get
            {
                return this.targetIndex;
            }
        }
    }
}
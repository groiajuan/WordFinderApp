namespace WordSearchLogic;
    public sealed class Matrix64Validator : MatrixValidatorBase
    {
        private const int MAXROWSIZE = 64;
        private const int MAXCOLUMSIZE = 64;

        public Matrix64Validator() : base(MAXROWSIZE, MAXCOLUMSIZE)
        {

        }

        public override void ExecuteOtherValidations(IEnumerable<string> matrix)
        {
            if(!matrix.All(p => p.Length == matrix.First().Length))
                throw new ArgumentException($"All words on the Matrix must have the same Length");
        }
    }


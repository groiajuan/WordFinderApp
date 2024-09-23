//We can use some validation library like FluentValidation but I decided to do it by hand It also allows extending to other matrix cardinality.

namespace WordSearchLogic;
    public abstract class MatrixValidatorBase
    {
        protected int? RowLimits { get; set; }
        protected int? ColumnLimits { get; set; }

        public MatrixValidatorBase() { }

        public MatrixValidatorBase(int? rowLimits, int? columnLimits)
        {
            RowLimits = rowLimits;
            ColumnLimits = columnLimits;
        }

        protected void SetMaxSize(int? xMaxSize, int? yMaxSize)
        {
            RowLimits = xMaxSize;
            ColumnLimits = yMaxSize;
        }
        protected virtual bool HasSizeRestrictions() => RowLimits is not null || ColumnLimits is not null;

        public virtual void ExecuteValidations(IEnumerable<string> _matrix)
        {
            if (_matrix is null || !_matrix.Any())
                throw new ArgumentException($"The Matrix cannot be null or empty");

            ExecuteOtherValidations(_matrix);

            if (HasSizeRestrictions())
                ValidateMatrixMaxSize(_matrix);
        }

        public abstract void ExecuteOtherValidations(IEnumerable<string> matrix);

        //We can use fluent validations or other kind of library to do that but, i choose the standart way
        public virtual void ValidateMatrixMaxSize(IEnumerable<string> matrix)
        {
            // If we think what all words have the same lenght of course we can replace matrix.Max
            // to take only the first element and calculate their lenght
            if ((RowLimits.HasValue && matrix.Count() > RowLimits) || 
                (ColumnLimits.HasValue && matrix.Max(s => s.Length) > ColumnLimits))
                throw new ArgumentException($"The Matrix cannot be larger than {RowLimits} x {ColumnLimits}");
        }

    }


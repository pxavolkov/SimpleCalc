namespace CalcService.BL
{
    /// <summary>
    /// Base class for all operations
    /// </summary>
    public abstract class BaseOperation
    {
        /// <summary>
        /// Unique ID for operation
        /// </summary>
        public abstract int OperationId { get; }
        /// <summary>
        /// Graphical sign for operation
        /// </summary>
        public abstract string OperationSign { get; }
        /// <summary>
        /// Action
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <returns>Result of operation</returns>
        public abstract double PerformAction(double a, double b);
    }

    public class Addition : BaseOperation
    {
        public override int OperationId => 0;
        public override string OperationSign => "+";

        public override double PerformAction(double a, double b)
        {
            return a + b;
        }
    }

    public class Subtraction : BaseOperation
    {
        public override int OperationId => 1;
        public override string OperationSign => "-";

        public override double PerformAction(double a, double b)
        {
            return a - b;
        }
    }

    public class Multiplication : BaseOperation
    {
        public override int OperationId => 2;
        public override string OperationSign => "*";

        public override double PerformAction(double a, double b)
        {
            return a * b;
        }
    }

    public class Division : BaseOperation
    {
        public override int OperationId => 3;
        public override string OperationSign => "/";

        public override double PerformAction(double a, double b)
        {
            return a / b;
        }
    }
}
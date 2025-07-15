using Demo_10_Testing.App.Exceptions;

namespace Demo_10_Testing.App.Services
{
    public class CalculService
    {
        public long Addition(long nb1, long nb2)
        {
            try
            {
                long result = checked(nb1 + nb2);
                return result;
            }
            catch (OverflowException e)
            {
                throw new CalculOverFlowException(nameof(Addition), $"Dépassement lors de l'addition de {nb1} et {nb2}.");
            }
        }

        public double Addition(double nb1, double nb2)
        {
            double result = nb1 + nb2;
            return Math.Round(result, 3, MidpointRounding.AwayFromZero);
        }


        public long Soustraction(long nb1, long nb2)
        {
            throw new NotImplementedException();
        }

        public double Soustraction(double nb1, double nb2)
        {
            throw new NotImplementedException();
        }
    }
}

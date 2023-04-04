namespace DelegatesSolution
{
    public class Fee
    {
        public double HighFee(double fee)
        {
            return fee += fee * 0.25; 
        }
    }
}

namespace Assign3_ClassLibrary_ChiHo;

public class Rooter
{
    // public double SquareRoot(double input)
    // {
    //     return input / 2;
    // }
    
    public double SquareRoot(double input)
    {
        
        if (input <= 0.0)
        {
            throw new ArgumentOutOfRangeException();
        }
        double result         = input;
        double previousResult = -input;
        while (Math.Abs(previousResult - result) > result / 1000)
        {
            previousResult = result;
            result         = result - (result * result - input) / (2 * result);
        }
        return result;
    }
    
}
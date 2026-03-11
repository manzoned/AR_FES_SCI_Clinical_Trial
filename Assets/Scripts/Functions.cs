using System;
public class functions
{
    
    // Function to find the angle 
    // between the two lines
    public static float CalculateAngle(float x1, float y1, float z1,
                               float x2, float y2, float z2,
                               float x3, float y3, float z3)
    {
        // Find direction ratio of line AB
        float ABx = x1 - x2;
        float ABy = y1 - y2;
        float ABz = z1 - z2;

        // Find direction ratio of line BC
        float BCx = x3 - x2;
        float BCy = y3 - y2;
        float BCz = z3 - z2;
            
        // Find the dotProduct
        // of lines AB & BC
        float dotProduct = ABx * BCx +
                            ABy * BCy +
                            ABz * BCz;

        // Find magnitude of
        // line AB and BC
        float magnitudeAB = ABx * ABx +
                             ABy * ABy +
                             ABz * ABz;
        float magnitudeBC = BCx * BCx +
                             BCy * BCy +
                             BCz * BCz;

        // Find the cosine of the 
        // angle formed by line
        // AB and BC
        float angle = dotProduct;
        angle /= MathF.Sqrt(magnitudeAB *
                           magnitudeBC);
        float test = MathF.Acos(angle);
        test = test * 180f / MathF.PI;

        // Find angle in degrees (I think)
        angle = angle * 180f / 3.14f;
        
        return test;
        
        
    }
}
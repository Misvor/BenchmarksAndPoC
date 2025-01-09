namespace ConsoleApp1.Problems;

public class Asteroids
{
     public int[] AsteroidCollision(int[] asteroids) {
       var lastAsteroid = 0;
        var reverse = false;
        var pointer = 0;
        var checkedLast = false;
        while(!(checkedLast))
        {
            NextStep(ref pointer, ref reverse, asteroids.Length);            
            
            if(pointer == asteroids.Length)
            {
                checkedLast = true;                
                continue;
            }
            if(pointer < 0)
            {
                pointer = 0;
                reverse = false;
            }

            if(reverse && asteroids[lastAsteroid] > 0)
            {
                reverse = false;
                continue;
            }
            
            if(!reverse && asteroids[lastAsteroid] <= 0)
            {
                lastAsteroid = pointer;
                continue;
            }            

            if(asteroids[pointer] == 0)
            {
                continue;
            }

            if(lastAsteroid == pointer)
            {
                continue;
            }
            
            if((asteroids[lastAsteroid] ^ asteroids[pointer]) >= 0)
            {
                if(!reverse)
                {
                    lastAsteroid = pointer;
                }
            }
            else
            {
                if(asteroids[lastAsteroid] + asteroids[pointer] == 0)
                {
                    asteroids[lastAsteroid] = 0;
                    asteroids[pointer] = 0;
                    reverse = true;
                }else if(Math.Abs(asteroids[lastAsteroid]) > Math.Abs(asteroids[pointer]))
                {                    
                    asteroids[pointer] = 0;                    
                }
                else
                {
                    reverse = true;
                    asteroids[lastAsteroid] = 0;
                    lastAsteroid = pointer;                                     
                }                
            }            
        } 
       
        return asteroids.Where(x=> x != 0).ToArray();
    }

    private void NextStep(ref int pointer, ref bool reverse, int limit)
    {        
        pointer = reverse ? pointer -1: pointer +1;
        if(pointer == 0 || pointer == limit)
        {
            reverse = !reverse;            
        }
    }
}
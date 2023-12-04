using System;

public class MiscEvents
{
    public event Action onFruitCollected;
    public void FruitCollected() 
    {
        if (onFruitCollected != null) 
        {
            onFruitCollected();
        }
    }

    /**public event Action onGemCollected;
    public void GemCollected() 
    {
        if (onGemCollected != null) 
        {
            onGemCollected();
        }
    }
    **/
}
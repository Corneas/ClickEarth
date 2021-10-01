using System.Collections.Generic;

[System.Serializable]
public class User
{
    public string userName;
    public long StarEnergy;
    public List<Star> starList = new List<Star>();
}

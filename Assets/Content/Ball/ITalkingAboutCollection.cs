using System.Collections.Generic;

namespace SpacePortals
{
    public interface ITalkingAboutCollection <T>
    { 
        IEnumerable<T> Collection { get; }
    }

}
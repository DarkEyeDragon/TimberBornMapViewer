using System;
using System.Collections.Generic;

namespace TimberBornMapViewer.Map
{
    public class Location
    {

        public static Dictionary<Location, TileEntity> TileEntityLocations { get; } = new();
        public int X { get; }
        public int Y { get; }
        public int Z { get; }
        private readonly int _hash;
        public Location(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
            var h = new HashCode();
            h.Add(X);
            h.Add(Y);
            h.Add(Z);
            _hash = h.ToHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Location location) return false;
            //if (obj == this) return true;
            return X == location.X && Y == location.Y && Z == location.Z;
        }

        public override int GetHashCode()
        {
            return _hash;
        }

        public override string ToString()
        {
            return $"Location[X{X} Y{Y} Z{Z}]";
        }
    }
}
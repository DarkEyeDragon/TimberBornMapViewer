using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TimberBornMapViewer.Map
{
    public class TileEntity
    {
        public static Dictionary<string, TileEntity> TileEntities = new();
        public string DisplayName { get; set; }
        public Color Color { get; }

        public Rectangle Rectangle { get; set; }
        public TileEntity(Color color, string displayName = "Unknown")
        {
            DisplayName = displayName;
            Color = color;
            Rectangle = new Rectangle();
            Rectangle.Fill = new SolidColorBrush(color);
        }
    }
}
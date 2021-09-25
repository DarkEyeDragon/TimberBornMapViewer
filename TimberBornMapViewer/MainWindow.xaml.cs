using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MapInterpreter;
using Microsoft.Win32;
using TimberBornMapViewer.Map;

namespace TimberBornMapViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MapHandler.Map Map { get; set; }
        public readonly int TileSize = 4;
        public Rectangle LastSelected { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            LoadEntities();
        }

        private void LoadEntities()
        {
            Debug.WriteLine("Loading entities...");
            TileEntity.TileEntities = new Dictionary<string, TileEntity>
            {
                { "Bakery", new TileEntity(Colors.Chocolate, "Bakery") },
                { "Barrier", new TileEntity(Colors.DarkSlateGray, "Barrier") },
                { "Beehive", new TileEntity(Colors.Chocolate, "Beehive") },
                { "Bench", new TileEntity(Colors.SaddleBrown, "Bench") },
                { "Birch", new TileEntity(Colors.GreenYellow, "Birch") },
                { "BlueberryBush", new TileEntity(Colors.CadetBlue, "BlueberryBush") },
                { "BuildersHut", new TileEntity(Colors.SaddleBrown, "BuildersHut") },
                { "BreedingPod", new TileEntity(Colors.Purple, "BreedingPod") },
                { "Campfire", new TileEntity(Colors.SaddleBrown, "Campfire") },
                { "Carrot", new TileEntity(Colors.DarkOrange, "Carrot") },
                { "Dam", new TileEntity(Colors.SaddleBrown, "Dam") },
                { "DistrictCenter", new TileEntity(Colors.Black, "DistrictCenter") },
                { "DoubleFloodgate", new TileEntity(Colors.SaddleBrown, "DoubleFloodgate") },
                { "DoubleLodge", new TileEntity(Colors.SaddleBrown, "DoubleLodge") },
                { "DoublePlatform", new TileEntity(Colors.SaddleBrown, "DoublePlatform") },
                { "DropOffPoint", new TileEntity(Colors.Red, "DropOffPoint") },
                { "ExplosivesFactory", new TileEntity(Colors.Indigo, "ExplosivesFactory") },
                { "FarmHouse", new TileEntity(Colors.SaddleBrown, "FarmHouse") },
                { "FlippedLodge", new TileEntity(Colors.SaddleBrown, "FlippedLodge") },
                { "Forester", new TileEntity(Colors.Brown, "Forester") },
                { "GathererFlag", new TileEntity(Colors.MediumPurple, "GathererFlag") },
                { "GearWorkshop", new TileEntity(Colors.BurlyWood, "GearWorkshop") },
                { "Gristmill", new TileEntity(Colors.BurlyWood, "Gristmill") },
                { "HaulingPost", new TileEntity(Colors.Red, "HaulingPost") },
                { "Inventor", new TileEntity(Colors.CadetBlue, "Inventor") },
                { "LaborerMonument", new TileEntity(Colors.Orange, "LaborerMonument") },
                { "LargeWarehouse", new TileEntity(Colors.SaddleBrown, "LargeWarehouse") },
                { "LargeWaterTank", new TileEntity(Colors.RoyalBlue, "LargeWaterTank") },
                { "LargeWindmill", new TileEntity(Colors.Brown, "LargeWindmill") },
                { "Levee", new TileEntity(Colors.Brown, "Levee") },
                { "LogPile", new TileEntity(Colors.RosyBrown, "LogPile") },
                { "LumberjackFlag", new TileEntity(Colors.BurlyWood, "LumberjackFlag") },
                { "LumberMill", new TileEntity(Colors.BurlyWood, "LumberMill") },
                { "Maple", new TileEntity(Colors.DarkGreen, "Maple") },
                { "PaperMill", new TileEntity(Colors.PaleTurquoise, "PaperMill") },
                { "Path", new TileEntity(Colors.Peru, "Path") },
                { "Pine", new TileEntity(Colors.ForestGreen, "Pine") },
                { "Platform", new TileEntity(Colors.DimGray, "Platform") },
                { "Potato", new TileEntity(Colors.PapayaWhip, "Potato") },
                { "PowerShaftIntersection", new TileEntity(Colors.CadetBlue, "PowerShaftIntersection") },
                { "PowerShaftStraight", new TileEntity(Colors.CadetBlue, "PowerShaftStraight") },
                { "PowerShaftTurn", new TileEntity(Colors.CadetBlue, "PowerShaftTurn") },
                { "PowerWheel", new TileEntity(Colors.CadetBlue, "PowerWheel") },
                { "PrintingPress", new TileEntity(Colors.CadetBlue, "DropOffPoint") },
                { "RooftopTerrace", new TileEntity(Colors.CadetBlue, "RooftopTerrace") },
                { "RuinColumnH1", new TileEntity(Colors.DarkSlateGray, "RuinColumnH1") },
                { "RuinColumnH2", new TileEntity(Colors.DarkSlateGray, "RuinColumnH2") },
                { "RuinColumnH3", new TileEntity(Colors.DarkSlateGray, "RuinColumnH3") },
                { "RuinColumnH4", new TileEntity(Colors.DarkSlateGray, "RuinColumnH4") },
                { "RuinColumnH5", new TileEntity(Colors.DarkSlateGray, "RuinColumnH5") },
                { "RuinColumnH6", new TileEntity(Colors.DarkSlateGray, "RuinColumnH6") },
                { "RuinColumnH7", new TileEntity(Colors.DarkSlateGray, "RuinColumnH7") },
                { "RuinColumnH8", new TileEntity(Colors.DarkSlateGray, "RuinColumnH8") },
                { "Shredder", new TileEntity(Colors.CadetBlue, "Shredder") },
                { "Shrub", new TileEntity(Colors.CadetBlue, "Shrub") },
                { "Slope", new TileEntity(Colors.LightSlateGray, "Slope") },
                { "SmallWarehouse", new TileEntity(Colors.CadetBlue, "SmallWarehouse") },
                { "Temple", new TileEntity(Colors.CadetBlue, "Temple") },
                { "TripleLodge", new TileEntity(Colors.CadetBlue, "TripleLodge") },
                { "WaterDump", new TileEntity(Colors.CadetBlue, "WaterDump") },
                { "WaterPump", new TileEntity(Colors.CadetBlue, "WaterPump") },
                { "WaterWheel", new TileEntity(Colors.SaddleBrown, "WaterWheel") },
                { "Wheat", new TileEntity(Colors.CadetBlue, "Wheat") },
                { "WoodenStairs", new TileEntity(Colors.CadetBlue, "WoodenStairs") },
                { "WaterSource", new TileEntity(Colors.CadetBlue, "WaterSource") },
                { "Grill", new TileEntity(Colors.CadetBlue, "Grill") },
                { "StartingLocation", new TileEntity(Colors.CadetBlue, "StartingLocation") },
                { "Floodgate", new TileEntity(Colors.CadetBlue, "Floodgate") },
                { "DepthMarker", new TileEntity(Colors.CadetBlue, "DepthMarker") },
                { "DistributionPost", new TileEntity(Colors.CadetBlue, "DistributionPost") },
                { "DistrictGate", new TileEntity(Colors.CadetBlue, "DistrictGate") },
                { "BeaverAdult", new TileEntity(Colors.CadetBlue, "BeaverAdult") },
                { "BeaverStatue", new TileEntity(Colors.CadetBlue, "BeaverStatue") },
                { "TripleFloodgate", new TileEntity(Colors.CadetBlue, "TripleFloodgate") },
                { "ScavengerFlag", new TileEntity(Colors.CadetBlue, "ScavengerFlag") },
                { "SuspensionBridge2x1", new TileEntity(Colors.CadetBlue, "SuspensionBridge2x1") },
                { "SuspensionBridge1x1", new TileEntity(Colors.CadetBlue, "SuspensionBridge1x1") },
                { "Barrack", new TileEntity(Colors.CadetBlue, "Barrack") },
                { "DeepWaterPump", new TileEntity(Colors.CadetBlue, "DeepWaterPump") },
                { "LargeBarrack", new TileEntity(Colors.CadetBlue, "LargeBarrack") },
                { "IndustrialLogPile", new TileEntity(Colors.CadetBlue, "IndustrialLogPile") },
                { "PowerShaftTShapedIntersection", new TileEntity(Colors.CadetBlue, "PowerShaftTShapedIntersection") },
                { "Engine", new TileEntity(Colors.CadetBlue, "Engine") },
                { "Roof3x2", new TileEntity(Colors.CadetBlue, "Roof3x2") },
                { "Roof1x1", new TileEntity(Colors.CadetBlue, "Roof1x1") },
                { "Roof1x2", new TileEntity(Colors.CadetBlue, "Roof1x2") },
                { "Dynamite", new TileEntity(Colors.CadetBlue, "Dynamite") },
                { "BeaverChild", new TileEntity(Colors.CadetBlue, "BeaverChild") },
            };
            Debug.WriteLine("Done loading entities...");
        }

        private void BtnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Map = MapHandler.CreateFromJson(File.ReadAllText(openFileDialog.FileName));
                MapCanvas.Children.Clear();
                var entities = Map.Entities;
                var list = entities.Select(entity => entity.Template.Split(".")[0]).Distinct()
                    .Except(TileEntity.TileEntities.Keys.ToList()).ToHashSet();
                foreach (var s in list)
                {
                    Debug.WriteLine(s);
                }
                foreach (var entity in entities)
                {
                    var name = entity.Template.Split(".")[0];
                    
                }
                foreach (var entity in entities)
                {
                    var block = entity.Components.BlockObject;
                    if(block == null) continue;
                    var coordinates = block.Coordinates;
                    var name = entity.Template.Split(".")[0];
                    var location = new Location(coordinates.X, coordinates.Y, coordinates.Z);
                    /*if (Location.TileEntityLocations.ContainsKey(location))
                    {
                        Debug.WriteLine(location);
                    }
                    else
                    {*/
                    if (location.X == 117 && location.Y == 125 && location.Z == 2)
                    {
                        Debug.WriteLine(entity.Id);
                    }
                    Location.TileEntityLocations.TryAdd(location, TileEntity.TileEntities[name]);
                        
                    //}
                }
                for (int y = 0; y < Map.Singletons.MapSize.Size.Y; y++)
                {
                    for (int x = 0; x < Map.Singletons.MapSize.Size.X; x++)
                    {
                        var rect = new Rectangle();
                        var index = x * Map.Singletons.MapSize.Size.X + y;
                        var depth = Map.Singletons.WaterMap.WaterDepths.Array[index];
                        var height = Map.Singletons.TerrainMap.Heights.Array[index];
                        var moisture = Map.Singletons.SoilMoistureSimulator.MoistureLevels.Array[index];
                        Brush brush = new SolidColorBrush(Color.FromRgb(0, 0, (byte)(256 - 16 * depth)));
                        if (depth == 0)
                        {
                            brush = new SolidColorBrush(Color.FromRgb((byte)(128 - 8 * moisture),
                                (byte)(256 - 16 * height), 0));
                        }

                        rect.Height = TileSize;
                        rect.Width = TileSize;
                        rect.Margin = new Thickness(x * TileSize, y * TileSize, TileSize, TileSize);
                        rect.PreviewMouseDown += TileClick;
                        /*foreach (var entity in entities)
                        {
                            var coordinates = entity.Components.BlockObject?.Coordinates;
                            if (coordinates?.Z == height && coordinates.X == x && coordinates.Y == y)
                            {
                                var name = entity.Template.Split('.')[0];
                            }
                        }*/
                        var present =  Location.TileEntityLocations.TryGetValue(new Location(x, y, height), out var result);
                        if (present)
                        {
                            var color = result.Color;
                            brush = new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
                        }
                        rect.Fill = brush;
                        MapCanvas.Children.Add(rect);
                    }
                }
            }
        }

        private void TileClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is not Rectangle rectangle) return;
            rectangle.Stroke = new SolidColorBrush(Colors.Purple);
            rectangle.StrokeThickness = 1.2;
            if (LastSelected != null)
            {
                LastSelected.Stroke = new SolidColorBrush(Colors.Transparent);
                LastSelected.StrokeThickness = 0;
            }

            LastSelected = rectangle;
            var point = Mouse.GetPosition(MapCanvas);
            if(point.X > MapCanvas.ActualWidth || point.Y > MapCanvas.ActualHeight) return;
            var gridPoint = new Point(point.X / TileSize, point.Y / TileSize);
            var index = (int)(Math.Floor(gridPoint.X) * Map.Singletons.MapSize.Size.X + Math.Floor(gridPoint.Y));
            if(index > Map.Singletons.TerrainMap.Heights.Array.Length) return;
            LabelPosition.Content =
                $"X[{Math.Floor(gridPoint.X)}] Y[{Math.Floor(gridPoint.Y)}] Z[{Map.Singletons.TerrainMap.Heights.Array[index]}]";
            LabelMoistureLevel.Content =
                $"Moisture lvl: {Map.Singletons.SoilMoistureSimulator.MoistureLevels.Array[index]}";
            Location.TileEntityLocations.TryGetValue(new Location((int)gridPoint.X, (int)gridPoint.Y, Map.Singletons.TerrainMap.Heights.Array[index]), out var tileEntity);
            LabelTileName.Content = tileEntity != null ? tileEntity.DisplayName : "Tile";
        }
    }
}
using MudBlazor;
using System.Drawing;

namespace TeamManager.Client.Shared
{
    public class MixedTheme : MudTheme
    {
        public Palette Palette => new Palette
        {
            Primary = "#8bc5bb", // Set your primary color
            Secondary = Colors.Red.Default, // Set your secondary color
            Background = "#222a28", // Set background color
            Surface = "#373e3c;", // Set surface color
            AppbarBackground = "#4d5352", // Set appbar background color
            DrawerBackground = "#4d5352"
        };

        public LayoutProperties LayoutProperties => new LayoutProperties
        {
            DrawerWidthLeft = "240px"
        };
    }
}

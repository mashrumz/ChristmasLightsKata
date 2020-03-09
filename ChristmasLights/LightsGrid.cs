using System.Linq;

namespace ChristmasLights
{
    public enum LightAction
    {
        On,
        Off,
        Toggle
    }

    public class LightsGrid
    {
        private readonly int[][] grid;

        public LightsGrid(uint width, uint height)
        {
            grid = new int[width][];
            for (var i = 0; i < width; i++)
            {
                grid[i] = new int[height];
            }
        }

        private void SwapPoints(ref (int x, int y) pointA, ref (int x, int y) pointB)
        {
            if (pointA.x > pointB.x)
            {
                var tmp = pointA.x;
                pointA.x = pointB.x;
                pointB.x = tmp;
            }
            if (pointA.y > pointB.y)
            {
                var tmp = pointA.y;
                pointA.y = pointB.y;
                pointB.y = tmp;
            }
        }

        private void ExecuteLightAction(LightAction action, (int x, int y) pointA, (int x, int y) pointB)
        {
            SwapPoints(ref pointA, ref pointB);

            int brightness = 0;

            switch (action)
            {
                case LightAction.Off:
                    brightness = -1;
                    break;
                case LightAction.On:
                    brightness = 1;
                    break;
                case LightAction.Toggle:
                    brightness = 2;
                    break;
            }
            for (var i = pointA.x; i <= pointB.x; i++)
            {
                for (var j = pointA.y; j <= pointB.y; j++)
                {
                    grid[i][j] += brightness;
                }
            }
        }

        public void TurnOn((int, int) pointA, (int x, int y) pointB)
        {
            ExecuteLightAction(LightAction.On, pointA, pointB);
        }

        public void Toggle((int, int) pointA, (int, int) pointB)
        {
            ExecuteLightAction(LightAction.Toggle, pointA, pointB);
        }

        public void TurnOff((int, int) pointA, (int, int) pointB)
        {
            ExecuteLightAction(LightAction.Off, pointA, pointB);
        }

        public ulong TotalBrightness => (ulong)grid.SelectMany(row => row).Sum(l => l);
    }
}

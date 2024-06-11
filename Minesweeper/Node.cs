using System.Runtime.InteropServices;

namespace MinesweeperBot.Minesweeper
{
	public class Node
	{
		[DllImport("user32.dll")]
		static extern bool SetCursorPos(int x, int y);

		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

		private const int MOUSEEVENTF_LEFTDOWN = 0x02;
		private const int MOUSEEVENTF_LEFTUP = 0x04;
		private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
		private const int MOUSEEVENTF_RIGHTUP = 0x10;

		public int X { get; }
		public int Y { get; }
		public int State { get; set; }

		private Grid grid;

		public Node(Grid grid, int x, int y)
		{
			this.grid = grid;
			this.X = x;
			this.Y = y;
		}

		public NodePack GetNeighbours()
		{
			return new NodePack(grid.GetNeighbours(X, Y));
		}

		public void Open()
		{
			State = -1;
			int x = 690 + X * 30 + 15;
			int y = 401 + Y * 30 + 15;
			SetCursorPos(x, y);
			mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
			Thread.Sleep(50);
		}

		public void Mark()
		{
			State = -2;
			int x = 690 + X * 30 + 15;
			int y = 401 + Y * 30 + 15;
			SetCursorPos(x, y);
			mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, x, y, 0, 0);
			Thread.Sleep(50);
		}
	}
}

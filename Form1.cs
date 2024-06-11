using MinesweeperBot.Minesweeper;

namespace MinesweeperBot
{
	public partial class Form1 : Form
	{
		private KeyboardHook hook = new();
		private Grid grid = new(18, 14);

		public Form1()
		{
			InitializeComponent();

			hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
			hook.RegisterHotKey(MinesweeperBot.ModifierKeys.Control, Keys.X);
		}

		void hook_KeyPressed(object sender, KeyPressedEventArgs e)
		{
			while (true)
			{
				grid.Update();

				foreach (var node in grid.Nodes)
				{
					if (node.State < 1)
						continue;

					var nodes = node.GetNeighbours();
					if (nodes.Count(0) > 0 && nodes.Count(0) + nodes.Count(-2) == node.State)
						nodes.Mark(0);

					if (nodes.Count(0) > 0 && nodes.Count(-2) == node.State)
						nodes.Open(0);
				}
			}
		}
	}
}

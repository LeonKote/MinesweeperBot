namespace MinesweeperBot.Minesweeper
{
	public class Grid
	{
		public Node[,] Nodes { get; }

		private int width;
		private int height;
		private Bitmap bmp;
		private Graphics g;

		public Grid(int width, int height)
		{
			this.width = width;
			this.height = height;

			Nodes = new Node[width, height];

			for (int x = 0; x < width; x++)
				for (int y = 0; y < height; y++)
					Nodes[x, y] = new Node(this, x, y);

			bmp = new Bitmap(width * 30, height * 30);
			g = Graphics.FromImage(bmp);
		}

		public void Update()
		{
			g.CopyFromScreen(690, 401, 0, 0, new Size(bmp.Width, bmp.Height));

			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					switch ((uint)bmp.GetPixel(x * 30 + 15, y * 30 + 14).ToArgb())
					{
						case 0xFFBDAE3E:
						case 0xFFB7AA38:
							Nodes[x, y].State = -2;
							break;
						case 0xFFE5C29F:
						case 0xFFD7B899:
							Nodes[x, y].State = -1;
							break;
						case 0xFFAAD751:
						case 0xFFA2D149:
							Nodes[x, y].State = 0;
							break;
						case 0xFF1976D2:
							Nodes[x, y].State = 1;
							break;
						case 0xFF93A970:
						case 0xFF8CA46C:
							Nodes[x, y].State = 2;
							break;
						case 0xFFD32F2F:
							Nodes[x, y].State = 3;
							break;
						case 0xFFAD6BA0:
						case 0xFFA6669D:
							Nodes[x, y].State = 4;
							break;
						case 0xFFFF8F00:
							Nodes[x, y].State = 5;
							break;
					}
				}
			}
		}

		public List<Node> GetNeighbours(int x, int y)
		{
			var neighbours = new List<Node>();

			for (int _x = -1; _x <= 1; _x++)
			{
				for (int _y = -1; _y <= 1; _y++)
				{
					if (_x == 0 && _y == 0)
						continue;

					int checkX = x + _x;
					int checkY = y + _y;

					if (checkX < 0 || checkX >= width || checkY < 0 || checkY >= height)
						continue;

					neighbours.Add(Nodes[checkX, checkY]);
				}
			}
			return neighbours;
		}
	}
}

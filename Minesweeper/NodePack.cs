namespace MinesweeperBot.Minesweeper
{
	public class NodePack
	{
		private List<Node> nodes;

		public NodePack(List<Node> nodes)
		{
			this.nodes = nodes;
		}

		public void Open(int state)
		{
			foreach (var node in nodes)
				if (node.State == state)
					node.Open();
		}

		public void Mark(int state)
		{
			foreach (var node in nodes)
				if (node.State == state)
					node.Mark();
		}

		public int Count(int state)
		{
			return nodes.Count(x => x.State == state);
		}
	}
}

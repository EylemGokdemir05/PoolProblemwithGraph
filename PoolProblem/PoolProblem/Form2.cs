using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoolProblem
{
    public partial class Form2 : Form
    {
        public int dugum_degeri { get; set; }
        public Dictionary<string, int> edges { get; set; } = new Dictionary<string, int>();
        public Dictionary<Dictionary<string, string>, int> _graph { get; set; } = new Dictionary<Dictionary<string, string>, int>();
        public Dictionary<string, bool> nodeStatus { get; set; } = new Dictionary<string, bool>();

        public Dictionary<string, Dictionary<int, int>> coordinates { get; set; } = new Dictionary<string, Dictionary<int, int>>();

        public List<Node> nodes { get; set; } = new List<Node>();

        public Dictionary<string, Dictionary<int, int>> capacityCoordinates { get; set; } = new Dictionary<string, Dictionary<int, int>>();

        public Dictionary<string, string> test { get; set; } = new Dictionary<string, string>();

        public Form2(int dugum_degeri,
                    Dictionary<string, int> edges,
                    Dictionary<Dictionary<string, string>, int> _graph,
                    Dictionary<string, bool> nodeStatus)
        {
            InitializeComponent();
            ResizeRedraw = true;
            this.dugum_degeri = dugum_degeri;
            this.edges = edges;
            this._graph = _graph;
            this.nodeStatus = nodeStatus;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void DrawGraph(object sender, PaintEventArgs e)
        {
            var nodeCount = dugum_degeri;
            var edgesInfo = edges;
            var graph = _graph;

            for (int i = 0; i < dugum_degeri; i++)
            {
                if (i == 0)
                {
                    nodes.Add(new Node(edges.Keys.ElementAt(i), 350, 30 * (i) + 20));
                    continue;
                }
                if (i == (dugum_degeri - 1))
                {
                    nodes.Add(new Node(edges.Keys.ElementAt(i), 370, 30 * (i) + 40));
                    continue;
                }
                if (i % 2 == 1)
                {
                    nodes.Add(new Node(edges.Keys.ElementAt(i), 250, 30 * (i) + 40));
                }
                else
                {
                    nodes.Add(new Node(edges.Keys.ElementAt(i), 450, 30 * (i - 1) + 60));
                }
            }

            foreach (var item in nodes)
            {
                Pen pen = new Pen(Color.Black, 5);//bir kalem oluşturduk siyah renkte ve 5 genişliğinde
                e.Graphics.DrawEllipse(pen, new Rectangle(item.coordX - 7, item.coordY - 5, 40, 40)); //Tepe Noktası

                System.Drawing.Graphics graphicsObj;
                graphicsObj = this.CreateGraphics();
                Font myFont = new Font("Helvetica", 20, FontStyle.Regular);
                Brush myBrush = new SolidBrush(Color.DarkRed);
                graphicsObj.DrawString(item.nodeName, myFont, myBrush, item.coordX, item.coordY);

                var nodeNeighBor = GetNeighbor(item.nodeName);

                for (int i = 0; i < nodeNeighBor.Count; i++)
                {
                    var nodeItem = nodeNeighBor.ElementAt(i);

                    var neighborCoordinates = nodes.Where(p => p.nodeName == nodeItem.Value).FirstOrDefault();

                    Pen edgeLine = new Pen(Color.Black, 4);
                    e.Graphics.DrawLine(edgeLine, new Point(item.coordX, item.coordY), new Point(neighborCoordinates.coordX, neighborCoordinates.coordY));

                    if (!test.ContainsKey(nodeItem.Key))
                    {
                        test.Add(nodeItem.Key, nodeItem.Value);

                        var controlData = new Dictionary<string, string>();
                        controlData.Add(item.nodeName, nodeItem.Value);
                        var data = _graph.Where(p => p.Key.SequenceEqual(controlData)).FirstOrDefault().Value;
                        var capX = (item.coordX + neighborCoordinates.coordX + (i * 20)) / 2;
                        var capY = (item.coordY + neighborCoordinates.coordY) / 2;

                        var control = test.Where(p => p.Key == nodeItem.Value + item.nodeName && p.Value == item.nodeName).ToList();
                        if (control.Count > 0)
                        {
                            capX = capX + 20;
                        }

                        var dataTxt = "";

                        if (i == nodeNeighBor.Count - 1)
                        {
                            dataTxt = data.ToString();
                        }
                        else
                        {
                            dataTxt = data.ToString() + " / ";
                        }

                        Font myFont2 = new Font("Helvetica", 12, FontStyle.Regular);
                        Brush myBrush2 = new SolidBrush(Color.DarkGreen);
                        graphicsObj.DrawString(dataTxt, myFont2, myBrush2, capX, capY);
                    }
                }
            }
        }

        public Dictionary<string, string> GetNeighbor(string node)
        {
            var graph = _graph;
            var data = graph.Select(p => p.Key).ToList();
            Dictionary<string, string> sourceTargetPairs = new Dictionary<string, string>();

            foreach (var item in data)
            {
                var result = item.Where(p => p.Key == node).FirstOrDefault();
                if (result.Key == node)
                {
                    sourceTargetPairs.Add(result.Key + result.Value, result.Value);
                }
            }
            return sourceTargetPairs;
        }

        private bool bfs(int[,] rGraph, int source, int target, int[] parent)
        {
            bool[] visited = new bool[dugum_degeri];
            for (int i = 0; i < dugum_degeri; ++i)
            {
                visited[i] = false;
            }

            List<int> queue = new List<int>();
            queue.Add(source);
            visited[source] = true;
            parent[source] = -1;

            while (queue.Count != 0)
            {
                int j = queue[0];
                queue.RemoveAt(0);

                for (int i = 0; i < dugum_degeri; i++)
                {
                    if (visited[i] == false && rGraph[j, i] > 0)
                    {
                        queue.Add(i);
                        parent[i] = j;
                        visited[i] = true;
                    }
                }
            }

            return (visited[target] == true);
        }

        private int MaxFlow(int[,] graph, int source, int target)
        {
            int i, j;

            int[,] rGraph = new int[dugum_degeri, dugum_degeri];

            for (i = 0; i < dugum_degeri; i++)
            {
                for (j = 0; j < dugum_degeri; j++)
                {
                    rGraph[i, j] = graph[i, j];
                }
            }
            int[] parent = new int[dugum_degeri];
            int max_flow = 0;
            while (bfs(rGraph, source, target, parent))
            {
                int path_flow = int.MaxValue;
                for (j = target; j != source; j = parent[j])
                {
                    i = parent[j];
                    path_flow = Math.Min(path_flow, rGraph[i, j]);
                }
                for (j = target; j != source; j = parent[j])
                {
                    i = parent[j];
                    rGraph[i, j] -= path_flow;
                    rGraph[j, i] += path_flow;
                }
                max_flow += path_flow;
            }
            var data = max_flow;
            return data;
        }

        private void maxflowbtn_Click(object sender, EventArgs e)
        {
            var _tempControlNeighbor = new List<string>();
            ArrayList _tempGraph = new ArrayList();

            int counter = 0;
            foreach (var item in _graph)
            {
                var source = (item.Key).Select(p => p.Key).FirstOrDefault();
                var target = (item.Key).Select(p => p.Value).FirstOrDefault();
                var cap = item.Value;
                var index = nodes.Select(p => p.nodeName).ToList().IndexOf(target);

                if (_tempControlNeighbor.Count == 0)
                {
                    _tempControlNeighbor.Add(source);

                    List<int> row = new List<int>();
                    for (int i = 0; i < dugum_degeri; i++)
                    {
                        row.Add(0);
                    }

                    row[index] = cap;
                    _tempGraph.Add(row);
                    counter++;
                }
                else if (source != _tempControlNeighbor[_tempControlNeighbor.Count - 1])
                {
                    _tempControlNeighbor.Add(source);

                    List<int> row = new List<int>();
                    for (int i = 0; i < dugum_degeri; i++)
                    {
                        row.Add(0);
                    }

                    row[index] = cap;
                    _tempGraph.Add(row);
                    counter++;
                }
                else
                {
                    ((List<int>)_tempGraph[_tempGraph.Count - 1])[index] = cap;
                }
            }

            for (int i = 0; i < dugum_degeri - counter; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < dugum_degeri; j++)
                {
                    row.Add(0);
                }
                _tempGraph.Add(row);
            }

            int[,] graph = new int[dugum_degeri, dugum_degeri];

            for (int i = 0; i < dugum_degeri; i++)
            {
                var data = (List<int>)_tempGraph[i];
                for (int j = 0; j < dugum_degeri; j++)
                {
                    graph[i, j] = data[j];
                }
            }

            var result = MaxFlow(graph, 0, dugum_degeri - 1);
            maxflowvalue.Text = result.ToString();
        }

        private static bool bfsMinCut(int[,] rGraph, int source, int target, int[] parent)
        {
            bool[] visited = new bool[rGraph.Length];
            Queue<int> q = new Queue<int>();
            q.Enqueue(source);
            visited[source] = true;
            parent[source] = -1;

            while (q.Count != 0)
            {
                int j = q.Dequeue();
                for (int i = 0; i < rGraph.GetLength(0); i++)
                {
                    if (rGraph[j, i] > 0 && !visited[i])
                    {
                        q.Enqueue(i);
                        visited[i] = true;
                        parent[i] = j;
                    }
                }
            }
            return (visited[target] == true);
        }

        private static void dfsMinCut(int[,] rGraph, int source, bool[] visited)
        {
            visited[source] = true;
            for (int i = 0; i < rGraph.GetLength(0); i++)
            {
                if (rGraph[source, i] > 0 && !visited[i])
                {
                    dfsMinCut(rGraph, i, visited);
                }
            }
        }

        private ArrayList MinCut(int[,] graph, int source, int target)
        {
            int u, v;
            int[,] rGraph = new int[graph.Length, graph.Length];
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    rGraph[i, j] = graph[i, j];
                }
            }

            int[] parent = new int[graph.Length];

            while (bfsMinCut(rGraph, source, target, parent))
            {
                // Find minimum residual capacity of the edhes
                // along the path filled by BFS. Or we can say
                // find the maximum flow through the path found.
                int pathFlow = int.MaxValue;
                for (v = target; v != source; v = parent[v])
                {
                    u = parent[v];
                    pathFlow = Math.Min(pathFlow, rGraph[u, v]);
                }

                // update residual capacities of the edges and
                // reverse edges along the path
                for (v = target; v != source; v = parent[v])
                {
                    u = parent[v];
                    rGraph[u, v] = rGraph[u, v] - pathFlow;
                    rGraph[v, u] = rGraph[v, u] + pathFlow;
                }
            }

            bool[] isVisited = new bool[graph.Length];
            dfsMinCut(rGraph, source, isVisited);

            var result = new ArrayList();

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    if (graph[i, j] > 0 && isVisited[i] && !isVisited[j])
                    {
                        var minPath = new List<string>();
                        minPath.Add(nodes[i].nodeName);
                        minPath.Add(nodes[j].nodeName);

                        result.Add(minPath);
                        //Console.WriteLine(i + " - " + j);
                    }
                }
            }

            return result;
        }

        private void mincutbtn_Click(object sender, EventArgs e)
        {
            var _tempControlNeighbor = new List<string>();
            ArrayList _tempGraph = new ArrayList();

            int counter = 0;

            foreach (var item in _graph)
            {
                var source = (item.Key).Select(p => p.Key).FirstOrDefault();
                var target = (item.Key).Select(p => p.Value).FirstOrDefault();
                var cap = item.Value;
                var index = nodes.Select(p => p.nodeName).ToList().IndexOf(target);

                if (_tempControlNeighbor.Count == 0)
                {
                    _tempControlNeighbor.Add(source);

                    List<int> row = new List<int>();
                    for (int i = 0; i < dugum_degeri; i++)
                    {
                        row.Add(0);
                    }

                    row[index] = cap;
                    _tempGraph.Add(row);
                    counter++;
                }
                else if (source != _tempControlNeighbor[_tempControlNeighbor.Count - 1])
                {
                    _tempControlNeighbor.Add(source);

                    List<int> row = new List<int>();
                    for (int i = 0; i < dugum_degeri; i++)
                    {
                        row.Add(0);
                    }

                    row[index] = cap;
                    _tempGraph.Add(row);
                    counter++;
                }
                else
                {
                    ((List<int>)_tempGraph[_tempGraph.Count - 1])[index] = cap;
                }
            }

            for (int i = 0; i < dugum_degeri - counter; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < dugum_degeri; j++)
                {
                    row.Add(0);
                }
                _tempGraph.Add(row);
            }

            int[,] graph = new int[dugum_degeri, dugum_degeri];

            for (int i = 0; i < dugum_degeri; i++)
            {
                var data = (List<int>)_tempGraph[i];
                for (int j = 0; j < dugum_degeri; j++)
                {
                    graph[i, j] = data[j];
                }
            }

            var result = MinCut(graph, 0, dugum_degeri - 1);

            var resultText = "";

            foreach (var item in result)
            {
                var minPath = (List<string>)item;
                var text = "";
                foreach (var item2 in minPath)
                {
                    text += " - " + item2;
                }
                resultText += "\n" + text;
            }

            mincutvalue.Text = resultText;
        }
    }
}
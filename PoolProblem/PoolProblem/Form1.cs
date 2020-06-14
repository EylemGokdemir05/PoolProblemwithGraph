using System;
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
    public partial class Form1 : Form
    {
        public int dugum_degeri { get; set; }
        public Dictionary<string, int> edges { get; set; } = new Dictionary<string, int>();
        public Dictionary<Dictionary<string, string>, int> _graph { get; set; } = new Dictionary<Dictionary<string, string>, int>();

        public Dictionary<string, bool> nodeStatus { get; set; } = new Dictionary<string, bool>();

        //public static int dugum_degeri;
        //public static Dictionary<string, int> edges = new Dictionary<string, int>();
        //public static Dictionary<Dictionary<string, string>, int> _graph = new Dictionary<Dictionary<string, string>, int>();

        public Form1()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void dugumekle_button_Click(object sender, EventArgs e)
        {
            dugum_degeri = Convert.ToInt32(numericUpDown1.Value);

            for (int i = 0; i < dugum_degeri; i++)
            {
                Label label = new Label()
                {
                    Width = 84,
                    Height = 14,
                    Text = (i + 1).ToString() + ". Düğüm: ",
                    Name = "lbl_" + (i + 1).ToString(),
                    Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular),
                };
                label.Location = new System.Drawing.Point(24, 44 + (60 * i));
                this.Controls.Add(label);

                TextBox textBox = new TextBox()
                {
                    Width = 91,
                    Height = 20,
                    Name = "source_" + (i + 1).ToString(),
                    Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular),
                };
                textBox.Location = new System.Drawing.Point(108, 44 + (60 * i));
                this.Controls.Add(textBox);

                NumericUpDown numericUpDown = new NumericUpDown()
                {
                    Width = 91,
                    Height = 20,
                    Name = "nud_" + (i + 1).ToString(),
                    Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular)
                };

                numericUpDown.Location = new System.Drawing.Point(108, 74 + (60 * i));
                this.Controls.Add(numericUpDown);
            }

            Button button = new Button()
            {
                Width = 75,
                Height = 20,
                Name = "komsu_ekle",
                Text = "Kenar Ekle",
                Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular),
            };

            button.Location = new System.Drawing.Point(220, 44);
            this.Controls.Add(button);

            button.Click += Buttons_Click;
        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            FillEdgeDictionary();

            for (int i = 0; i < edges.Count; i++)
            {
                var textBoxValue = this.Controls["source_" + (i + 1).ToString()] as TextBox;

                var item = edges.ElementAt(i);
                CreateNeighBorNodes(textBoxValue.Name, item.Value);
            }
        }

        public void FillEdgeDictionary()
        {
            for (int i = 0; i < dugum_degeri; i++)
            {
                var numericUpDown = this.Controls["nud_" + (i + 1).ToString()] as NumericUpDown;

                var textBoxValue = this.Controls["source_" + (i + 1).ToString()] as TextBox;

                if (numericUpDown != null && textBoxValue != null)
                {
                    var value = Convert.ToInt32(numericUpDown.Value);

                    var currentNudControl = edges.Where(p => p.Key == textBoxValue.Text).ToList();
                    if (currentNudControl.Count > 0)
                    {
                        edges[textBoxValue.Text] = value;
                    }
                    else
                    {
                        edges.Add(textBoxValue.Text, value);
                        nodeStatus.Add(textBoxValue.Text, false);
                    }
                }
            }

            var test = new Dictionary<string, int>();
            test = edges;
        }

        public void CreateNeighBorNodes(string edgeName, int numberOfEdge)
        {
            var textBoxSource = this.Controls[edgeName] as TextBox;

            var x = textBoxSource.Location.X.ToString();
            var y = textBoxSource.Location.Y.ToString();

            for (int i = 0; i < numberOfEdge; i++)
            {
                TextBox textBox = new TextBox()
                {
                    Width = 91,
                    Height = 20,
                    Name = "txt_" + (i + 1).ToString() + x.ToString() + y.ToString(),
                    Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular),
                };

                textBox.Location = new Point(320 + (i * 100), textBoxSource.Location.Y);
                this.Controls.Add(textBox);

                NumericUpDown numericUp = new NumericUpDown()
                {
                    Width = 91,
                    Height = 20,
                    Name = "cap_" + (i + 1).ToString() + x.ToString() + y.ToString(),
                    Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular)
                };
                numericUp.Location = new Point(320 + (i * 100), textBoxSource.Location.Y + 30);
                this.Controls.Add(numericUp);
            }

            Button button = new Button()
            {
                Width = 75,
                Height = 20,
                Text = "Oluştur",
                Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular)
            };
            button.Location = new Point(356, 22);
            this.Controls.Add(button);

            button.Click += CreateButtons_Click;
        }

        public void CreateButtons_Click(object sender, EventArgs e)
        {
            //Dictionary/Dictionary'ler oluşturulup girdiler alınacak

            CreateGraph();

            Form2 form2 = new Form2(dugum_degeri, edges, _graph, nodeStatus);
            form2.Show();
        }

        public void CreateGraph()
        {
            for (int i = 0; i < edges.Count; i++)
            {
                var textBoxValue = this.Controls["source_" + (i + 1).ToString()] as TextBox;
                var textBoxSource = this.Controls[textBoxValue.Name] as TextBox;
                var x = textBoxSource.Location.X.ToString();
                var y = textBoxSource.Location.Y.ToString();

                var edgesCount = edges[textBoxValue.Text];

                for (int j = 0; j < edgesCount; j++)
                {
                    var textBoxTarget = this.Controls["txt_" + (j + 1).ToString() + x.ToString() + y.ToString()] as TextBox;

                    var capacity = this.Controls["cap_" + (j + 1).ToString() + x.ToString() + y.ToString()] as NumericUpDown;

                    var edge = new Dictionary<string, string>();
                    edge.Add(textBoxValue.Text, textBoxTarget.Text);

                    _graph.Add(edge, Convert.ToInt32(capacity.Value));
                }
            }

            var test = new Dictionary<Dictionary<string, string>, int>();
            test = _graph;
        }
    }
}
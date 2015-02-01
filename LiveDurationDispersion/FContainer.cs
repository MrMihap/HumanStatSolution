using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveDurationDispersion.Modules;
using LiveDurationDispersion.Properties;

namespace LiveDurationDispersion
{
  public partial class FContainer : Form
  {
    public FContainer()
    {
      InitializeComponent();
    }
    
    private void FContainer_Load(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Maximized;
      Dispersion.PerformClick();
    }

    private void Dispersion_Click(object sender, EventArgs e)
    {
      FLoadStat form = new FLoadStat();
      form.MdiParent = this;
      form.Show();
    }
  }
}

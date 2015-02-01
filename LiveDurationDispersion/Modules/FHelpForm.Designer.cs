namespace LiveDurationDispersion.Modules
{
  partial class FHelpForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.zedGraph = new ZedGraph.ZedGraphControl();
      this.SuspendLayout();
      // 
      // zedGraph
      // 
      this.zedGraph.Location = new System.Drawing.Point(0, 0);
      this.zedGraph.Name = "zedGraph";
      this.zedGraph.ScrollGrace = 0D;
      this.zedGraph.ScrollMaxX = 0D;
      this.zedGraph.ScrollMaxY = 0D;
      this.zedGraph.ScrollMaxY2 = 0D;
      this.zedGraph.ScrollMinX = 0D;
      this.zedGraph.ScrollMinY = 0D;
      this.zedGraph.ScrollMinY2 = 0D;
      this.zedGraph.Size = new System.Drawing.Size(849, 300);
      this.zedGraph.TabIndex = 0;
      // 
      // FHelpForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(861, 312);
      this.Controls.Add(this.zedGraph);
      this.Name = "FHelpForm";
      this.Text = "FHelpForm";
      this.Load += new System.EventHandler(this.FHelpForm_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private ZedGraph.ZedGraphControl zedGraph;
  }
}
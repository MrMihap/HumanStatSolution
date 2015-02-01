namespace LiveDurationDispersion.Modules
{
  partial class FLoadStat
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
      this.GroupeBox = new System.Windows.Forms.GroupBox();
      this.DaysCountNumeric = new System.Windows.Forms.NumericUpDown();
      this.EndDate = new System.Windows.Forms.MaskedTextBox();
      this.StartDate = new System.Windows.Forms.MaskedTextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.calc_button = new System.Windows.Forms.Button();
      this.zedGraph = new ZedGraph.ZedGraphControl();
      this.GroupeBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DaysCountNumeric)).BeginInit();
      this.SuspendLayout();
      // 
      // GroupeBox
      // 
      this.GroupeBox.Controls.Add(this.DaysCountNumeric);
      this.GroupeBox.Controls.Add(this.EndDate);
      this.GroupeBox.Controls.Add(this.StartDate);
      this.GroupeBox.Controls.Add(this.label2);
      this.GroupeBox.Controls.Add(this.label4);
      this.GroupeBox.Controls.Add(this.label1);
      this.GroupeBox.Controls.Add(this.calc_button);
      this.GroupeBox.Location = new System.Drawing.Point(719, 12);
      this.GroupeBox.Name = "GroupeBox";
      this.GroupeBox.Size = new System.Drawing.Size(181, 118);
      this.GroupeBox.TabIndex = 1;
      this.GroupeBox.TabStop = false;
      this.GroupeBox.Text = "параметры";
      // 
      // DaysCountNumeric
      // 
      this.DaysCountNumeric.Location = new System.Drawing.Point(107, 65);
      this.DaysCountNumeric.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
      this.DaysCountNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.DaysCountNumeric.Name = "DaysCountNumeric";
      this.DaysCountNumeric.Size = new System.Drawing.Size(69, 20);
      this.DaysCountNumeric.TabIndex = 6;
      this.DaysCountNumeric.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
      this.DaysCountNumeric.ValueChanged += new System.EventHandler(this.DaysCountNumeric_ValueChanged);
      // 
      // EndDate
      // 
      this.EndDate.Location = new System.Drawing.Point(107, 41);
      this.EndDate.Mask = "00/00/0000";
      this.EndDate.Name = "EndDate";
      this.EndDate.Size = new System.Drawing.Size(69, 20);
      this.EndDate.TabIndex = 4;
      this.EndDate.Text = "31122000";
      this.EndDate.ValidatingType = typeof(System.DateTime);
      // 
      // StartDate
      // 
      this.StartDate.Location = new System.Drawing.Point(107, 17);
      this.StartDate.Mask = "00/00/0000";
      this.StartDate.Name = "StartDate";
      this.StartDate.Size = new System.Drawing.Size(69, 20);
      this.StartDate.TabIndex = 4;
      this.StartDate.Text = "01010001";
      this.StartDate.ValidatingType = typeof(System.DateTime);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(7, 68);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(79, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "разброс, дней";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(7, 44);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(62, 13);
      this.label4.TabIndex = 1;
      this.label4.Text = "дата конеч";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(7, 20);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(50, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "дата нач";
      // 
      // calc_button
      // 
      this.calc_button.Location = new System.Drawing.Point(74, 89);
      this.calc_button.Name = "calc_button";
      this.calc_button.Size = new System.Drawing.Size(102, 23);
      this.calc_button.TabIndex = 0;
      this.calc_button.Text = "анализировать";
      this.calc_button.UseVisualStyleBackColor = true;
      this.calc_button.Click += new System.EventHandler(this.calc_button_Click);
      // 
      // zedGraph
      // 
      this.zedGraph.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.zedGraph.Location = new System.Drawing.Point(6, 12);
      this.zedGraph.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
      this.zedGraph.Name = "zedGraph";
      this.zedGraph.ScrollGrace = 0D;
      this.zedGraph.ScrollMaxX = 0D;
      this.zedGraph.ScrollMaxY = 0D;
      this.zedGraph.ScrollMaxY2 = 0D;
      this.zedGraph.ScrollMinX = 0D;
      this.zedGraph.ScrollMinY = 0D;
      this.zedGraph.ScrollMinY2 = 0D;
      this.zedGraph.Size = new System.Drawing.Size(681, 360);
      this.zedGraph.TabIndex = 0;
      this.zedGraph.Load += new System.EventHandler(this.zedGraph_Load);
      // 
      // FLoadStat
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(912, 393);
      this.Controls.Add(this.zedGraph);
      this.Controls.Add(this.GroupeBox);
      this.Name = "FLoadStat";
      this.Text = "FLoadStat";
      this.Load += new System.EventHandler(this.FLoadStat_Load);
      this.GroupeBox.ResumeLayout(false);
      this.GroupeBox.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DaysCountNumeric)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox GroupeBox;
    private System.Windows.Forms.NumericUpDown DaysCountNumeric;
    private System.Windows.Forms.MaskedTextBox StartDate;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button calc_button;
    private System.Windows.Forms.MaskedTextBox EndDate;
    private System.Windows.Forms.Label label4;

    private ZedGraph.ZedGraphControl zedGraph;
  }
}
namespace LiveDurationDispersion
{
  partial class FContainer
  {
    /// <summary>
    /// Требуется переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Обязательный метод для поддержки конструктора - не изменяйте
    /// содержимое данного метода при помощи редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.базаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.запросToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.подключениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.Dispersion = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.базаToolStripMenuItem,
            this.запросToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(802, 24);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // базаToolStripMenuItem
      // 
      this.базаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.подключениеToolStripMenuItem});
      this.базаToolStripMenuItem.Name = "базаToolStripMenuItem";
      this.базаToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
      this.базаToolStripMenuItem.Text = "база";
      // 
      // запросToolStripMenuItem
      // 
      this.запросToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Dispersion});
      this.запросToolStripMenuItem.Name = "запросToolStripMenuItem";
      this.запросToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
      this.запросToolStripMenuItem.Text = "запрос";
      // 
      // подключениеToolStripMenuItem
      // 
      this.подключениеToolStripMenuItem.Name = "подключениеToolStripMenuItem";
      this.подключениеToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.подключениеToolStripMenuItem.Text = "подключение";
      // 
      // Dispersion
      // 
      this.Dispersion.Name = "Dispersion";
      this.Dispersion.Size = new System.Drawing.Size(152, 22);
      this.Dispersion.Text = "дисперсия";
      this.Dispersion.Click += new System.EventHandler(this.Dispersion_Click);
      // 
      // FContainer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(802, 376);
      this.Controls.Add(this.menuStrip1);
      this.IsMdiContainer = true;
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "FContainer";
      this.Text = "FContainer";
      this.Load += new System.EventHandler(this.FContainer_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem базаToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem подключениеToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem запросToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem Dispersion;
  }
}


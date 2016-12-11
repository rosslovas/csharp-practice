namespace Draughts
{
  partial class MainForm
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
			this.Renderer = new System.Windows.Forms.Panel();
			this.OutputBox = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// Renderer
			// 
			this.Renderer.BackColor = System.Drawing.SystemColors.ControlDark;
			this.Renderer.Location = new System.Drawing.Point(30, 30);
			this.Renderer.Name = "Renderer";
			this.Renderer.Size = new System.Drawing.Size(800, 800);
			this.Renderer.TabIndex = 0;
			this.Renderer.Click += new System.EventHandler(this.ClickBoard);
			this.Renderer.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintDraughts);
			// 
			// OutputBox
			// 
			this.OutputBox.Location = new System.Drawing.Point(845, 30);
			this.OutputBox.Name = "OutputBox";
			this.OutputBox.ReadOnly = true;
			this.OutputBox.Size = new System.Drawing.Size(541, 799);
			this.OutputBox.TabIndex = 1;
			this.OutputBox.Text = "";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1420, 860);
			this.Controls.Add(this.OutputBox);
			this.Controls.Add(this.Renderer);
			this.Name = "MainForm";
			this.Text = "Draughts";
			this.Load += new System.EventHandler(this.OnLoad);
			this.ResumeLayout(false);

    }

		#endregion

		private System.Windows.Forms.Panel Renderer;
		private System.Windows.Forms.RichTextBox OutputBox;
	}
}


namespace DungeonEscapeCS {
	partial class GameWindow {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.TitleImage = new System.Windows.Forms.PictureBox();
			this.StartButton = new System.Windows.Forms.Button();
			this.DebugButton = new System.Windows.Forms.Button();
			this.gameStartCheck = new System.Windows.Forms.Timer(this.components);
			this.BottomScreenBlank = new System.Windows.Forms.PictureBox();
			this.topScreenBlock = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.TitleImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BottomScreenBlank)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.topScreenBlock)).BeginInit();
			this.SuspendLayout();
			// 
			// TitleImage
			// 
			this.TitleImage.Image = global::DungeonEscapeCS.Properties.Resources.Title;
			this.TitleImage.Location = new System.Drawing.Point(0, 0);
			this.TitleImage.Name = "TitleImage";
			this.TitleImage.Size = new System.Drawing.Size(400, 240);
			this.TitleImage.TabIndex = 0;
			this.TitleImage.TabStop = false;
			// 
			// StartButton
			// 
			this.StartButton.Location = new System.Drawing.Point(159, 357);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(75, 23);
			this.StartButton.TabIndex = 1;
			this.StartButton.Text = "Start Game";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			this.StartButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StartButton_KeyDown);
			this.StartButton.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StartButton_KeyUp);
			// 
			// DebugButton
			// 
			this.DebugButton.Location = new System.Drawing.Point(313, 445);
			this.DebugButton.Name = "DebugButton";
			this.DebugButton.Size = new System.Drawing.Size(75, 23);
			this.DebugButton.TabIndex = 2;
			this.DebugButton.Text = "Debug";
			this.DebugButton.UseVisualStyleBackColor = true;
			this.DebugButton.Click += new System.EventHandler(this.DebugButton_Click);
			this.DebugButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
			this.DebugButton.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
			// 
			// gameStartCheck
			// 
			this.gameStartCheck.Enabled = true;
			this.gameStartCheck.Tick += new System.EventHandler(this.gameStartCheck_Tick);
			// 
			// BottomScreenBlank
			// 
			this.BottomScreenBlank.Location = new System.Drawing.Point(0, 240);
			this.BottomScreenBlank.Name = "BottomScreenBlank";
			this.BottomScreenBlank.Size = new System.Drawing.Size(400, 240);
			this.BottomScreenBlank.TabIndex = 3;
			this.BottomScreenBlank.TabStop = false;
			this.BottomScreenBlank.Visible = false;
			// 
			// topScreenBlock
			// 
			this.topScreenBlock.Location = new System.Drawing.Point(159, 123);
			this.topScreenBlock.Name = "topScreenBlock";
			this.topScreenBlock.Size = new System.Drawing.Size(400, 240);
			this.topScreenBlock.TabIndex = 4;
			this.topScreenBlock.TabStop = false;
			this.topScreenBlock.Visible = false;
			// 
			// GameWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(400, 480);
			this.Controls.Add(this.topScreenBlock);
			this.Controls.Add(this.BottomScreenBlank);
			this.Controls.Add(this.DebugButton);
			this.Controls.Add(this.StartButton);
			this.Controls.Add(this.TitleImage);
			this.Name = "GameWindow";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Title_Load);
			((System.ComponentModel.ISupportInitialize)(this.TitleImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BottomScreenBlank)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.topScreenBlock)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox TitleImage;
		private System.Windows.Forms.Button StartButton;
		private System.Windows.Forms.Button DebugButton;
		public System.Windows.Forms.Timer gameStartCheck;
		private System.Windows.Forms.PictureBox BottomScreenBlank;
		private System.Windows.Forms.PictureBox topScreenBlock;
	}
}


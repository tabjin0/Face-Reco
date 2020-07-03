namespace wavRecording {
    partial class Recording {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.comboWaveInDevice = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonStartRecording = new System.Windows.Forms.Button();
            this.buttonStopRecording = new System.Windows.Forms.Button();
            this.comboBoxSampleRate = new System.Windows.Forms.ComboBox();
            this.comboBoxChannels = new System.Windows.Forms.ComboBox();
            this.listBoxRecordings = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboWaveInDevice
            // 
            this.comboWaveInDevice.FormattingEnabled = true;
            this.comboWaveInDevice.Location = new System.Drawing.Point(292, 74);
            this.comboWaveInDevice.Name = "comboWaveInDevice";
            this.comboWaveInDevice.Size = new System.Drawing.Size(121, 20);
            this.comboWaveInDevice.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(618, 31);
            this.progressBar1.Maximum = 5;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(257, 21);
            this.progressBar1.TabIndex = 4;
            // 
            // buttonStartRecording
            // 
            this.buttonStartRecording.Location = new System.Drawing.Point(292, 31);
            this.buttonStartRecording.Name = "buttonStartRecording";
            this.buttonStartRecording.Size = new System.Drawing.Size(75, 23);
            this.buttonStartRecording.TabIndex = 1;
            this.buttonStartRecording.Text = "开始";
            this.buttonStartRecording.UseVisualStyleBackColor = true;
            this.buttonStartRecording.Click += new System.EventHandler(this.OnButtonStartRecordingClick);
            // 
            // buttonStopRecording
            // 
            this.buttonStopRecording.Location = new System.Drawing.Point(385, 31);
            this.buttonStopRecording.Name = "buttonStopRecording";
            this.buttonStopRecording.Size = new System.Drawing.Size(75, 23);
            this.buttonStopRecording.TabIndex = 2;
            this.buttonStopRecording.Text = "停止";
            this.buttonStopRecording.UseVisualStyleBackColor = true;
            // 
            // comboBoxSampleRate
            // 
            this.comboBoxSampleRate.FormattingEnabled = true;
            this.comboBoxSampleRate.Location = new System.Drawing.Point(292, 110);
            this.comboBoxSampleRate.Name = "comboBoxSampleRate";
            this.comboBoxSampleRate.Size = new System.Drawing.Size(121, 20);
            this.comboBoxSampleRate.TabIndex = 3;
            // 
            // comboBoxChannels
            // 
            this.comboBoxChannels.FormattingEnabled = true;
            this.comboBoxChannels.Location = new System.Drawing.Point(440, 74);
            this.comboBoxChannels.Name = "comboBoxChannels";
            this.comboBoxChannels.Size = new System.Drawing.Size(121, 20);
            this.comboBoxChannels.TabIndex = 4;
            // 
            // listBoxRecordings
            // 
            this.listBoxRecordings.FormattingEnabled = true;
            this.listBoxRecordings.ItemHeight = 12;
            this.listBoxRecordings.Location = new System.Drawing.Point(618, 89);
            this.listBoxRecordings.Name = "listBoxRecordings";
            this.listBoxRecordings.Size = new System.Drawing.Size(120, 88);
            this.listBoxRecordings.TabIndex = 5;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(292, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "测试语音";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Recording
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 463);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxRecordings);
            this.Controls.Add(this.comboBoxChannels);
            this.Controls.Add(this.comboBoxSampleRate);
            this.Controls.Add(this.buttonStopRecording);
            this.Controls.Add(this.buttonStartRecording);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.comboWaveInDevice);
            this.Name = "Recording";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Recording_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxRecordings;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button buttonStartRecording;
        public System.Windows.Forms.Button buttonStopRecording;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.ComboBox comboWaveInDevice;
        public System.Windows.Forms.ComboBox comboBoxChannels;
        public System.Windows.Forms.ComboBox comboBoxSampleRate;
    }
}


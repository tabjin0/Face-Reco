using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using wavRecording.pojo;
using wavRecording.model.audio;
using wavRecording.voice.utils;

namespace wavRecording
{

    public partial class Recording : Form
    {
        private IWaveIn captureDevice; // 捕获设备
        private WaveFileWriter writer;
        private string outputFilename;// 输出文件名
        private readonly string outputFolder;// 输出文件目录

        public static Recording recordingForm;
        public Recording()
        {
            InitializeComponent();
            Disposed += OnRecordingPanelDisposed;

            LoadWaveInDevicesCombo();// 加载WaveIn设备组合框

            // 码率
            comboBoxSampleRate.DataSource = new[] { 8000, 16000, 22050, 32000, 44100, 48000 };
            comboBoxSampleRate.SelectedIndex = 0;
            // 信道
            comboBoxChannels.DataSource = new[] { "Mono", "Stereo" };// 单声道、立体声
            comboBoxChannels.SelectedIndex = 0;

            // step1: 首先，选择将录制的音频放在何处。将转到桌面上recorded.wav一个NAudioDemo文件夹中的文件
            outputFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "tabjinAudio");
            Directory.CreateDirectory(outputFolder);
            var outputFilePath = Path.Combine(outputFolder, "recorded.wav");
        }

        /// <summary>
        /// 清理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnRecordingPanelDisposed(object sender, EventArgs e)
        {
            Cleanup();
        }
        /// <summary>
        /// 加载waveIn设备组合框
        /// </summary>
        private void LoadWaveInDevicesCombo()
        {
            var devices = Enumerable.Range(-1, WaveIn.DeviceCount + 1).Select(n => WaveIn.GetCapabilities(n)).ToArray();

            comboWaveInDevice.DataSource = devices;
            comboWaveInDevice.DisplayMember = "ProductName";
        }

        private void Cleanup()
        {
            if (captureDevice != null)
            {
                captureDevice.Dispose();
                captureDevice = null;
            }
            FinalizeWaveFile();
        }

        private void FinalizeWaveFile()
        {
            // writer?.Dispose();
            if (writer != null)
            {
                writer.Dispose();
            }
            writer = null;
        }

        /// <summary>
        /// 开始录音
        /// 单击“开始”时，将创建一个新的WaveFileWriter，指定要创建的WAV文件的路径以及要记录的格式。
        /// 该格式必须与记录设备格式相同，因为该格式将是接收记录数据的格式，所以用waveIn.WaveFormat。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonStartRecordingClick(object sender, EventArgs e)
        {

            if (captureDevice == null)
            {//捕获设备
                captureDevice = CreateWaveInDevice();
            }
            outputFilename = GetFileName();
            var path = Path.Combine(outputFolder, outputFilename);
            if (outputFolder != null && outputFilename != null)
            {
                writer = new WaveFileWriter(Path.Combine(outputFolder, outputFilename), captureDevice.WaveFormat);
                captureDevice.StartRecording();
                SetControlStates(true);
            }
        }

        /// <summary>
        /// 停止录音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<StoppedEventArgs>(OnRecordingStopped), sender, e);
            }
            else
            {
                FinalizeWaveFile();
                progressBar1.Value = 0;
                if (e.Exception != null)
                {
                    MessageBox.Show(String.Format("A problem was encountered during recording {0}", e.Exception.Message));
                }
                int newItemIndex = listBoxRecordings.Items.Add(outputFilename);
                listBoxRecordings.SelectedIndex = newItemIndex;
                SetControlStates(false);
            }
        }


        private string GetFileName()
        {
            var deviceName = captureDevice.GetType().Name;
            var sampleRate = string.Format("{0}kHz", captureDevice.WaveFormat.SampleRate / 1000);
            var channels = captureDevice.WaveFormat.Channels == 1 ? "mono" : "stereo";

            return string.Format("{0} {1} {2} {3}.wav", deviceName, sampleRate, channels, DateTime.Now.Ticks.ToString());// DateTime.Now:yyy-MM-dd HH-mm-ss    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        }



        /// <summary>
        /// 创建WaveIn设备
        /// </summary>
        /// <returns></returns>
        private IWaveIn CreateWaveInDevice()
        {
            IWaveIn newWaveIn;

            var deviceNumber = comboWaveInDevice.SelectedIndex - 1;//waveIn设备数量
            // step2: 创建记录设备
            newWaveIn = new WaveInEvent() { DeviceNumber = deviceNumber };

            var sampleRate = (int)comboBoxSampleRate.SelectedItem;
            var channels = comboBoxChannels.SelectedIndex + 1;
            newWaveIn.WaveFormat = new WaveFormat(sampleRate, channels);
            newWaveIn.DataAvailable += OnDataAvailable;
            newWaveIn.RecordingStopped += OnRecordingStopped;
            return newWaveIn;
        }

        void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            if (InvokeRequired)
            {
                //Debug.WriteLine("Data Available");
                BeginInvoke(new EventHandler<WaveInEventArgs>(OnDataAvailable), sender, e);
            }
            else
            {
                //Debug.WriteLine("Flushing Data Available");
                writer.Write(e.Buffer, 0, e.BytesRecorded);
                int secondsRecorded = (int)(writer.Length / writer.WaveFormat.AverageBytesPerSecond);
                //if (secondsRecorded >= 30) {
                if (secondsRecorded >= 5)
                {
                    StopRecording();
                }
                else
                {
                    progressBar1.Value = secondsRecorded;
                }
            }
        }

        void StopRecording()
        {
            Debug.WriteLine("StopRecording");
            //captureDevice?.StopRecording();
            if (captureDevice != null)
            {
                captureDevice.StopRecording();
            }
        }

        /// <summary>
        /// 设置空间状态
        /// </summary>
        /// <param name="isRecording"></param>
        private void SetControlStates(bool isRecording)
        {
            buttonStartRecording.Enabled = !isRecording;
            buttonStopRecording.Enabled = isRecording;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddFileASRTaskRequest addFileASRTaskRequest = new AddFileASRTaskRequest();
            var uuid = Guid.NewGuid().ToString();
            addFileASRTaskRequest.UserID = "DYMAM";
            addFileASRTaskRequest.TaskID = uuid;
            addFileASRTaskRequest.CallBackAddressInfo = "http://192.168.138.65:18801/ASRTaskCallBack";
            addFileASRTaskRequest.TaskName = "AudioCmdAnalze_" + uuid;
            addFileASRTaskRequest.ResultIncludeTime = 0;
            addFileASRTaskRequest.IncludePunctuation = 0;
            addFileASRTaskRequest.SourceFile = new SourceFile();
            addFileASRTaskRequest.SourceFile.FileType = 1;
            addFileASRTaskRequest.SourceFile.FileName = "AudioStart.wav";
            addFileASRTaskRequest.SourceFile.PathInfo = @"M:\打包公共区";
            var str = XMLHelper.XmlSerialize(addFileASRTaskRequest);
            //AddFileASRTaskResponse response = Voice_Recognition.postVoiceRecognitionXML(addFileASRTaskRequest);
            //AddFileASRTaskResponse b = null;
        }

        private void Recording_Load(object sender, EventArgs e)
        {

        }
    }
}

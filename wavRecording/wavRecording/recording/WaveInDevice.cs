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


namespace wavRecording.recording
{
   public class WaveInDevice
    {
        /// <summary>
        /// 创建WaveIn设备
        /// </summary>
        /// <returns></returns>
        //private IWaveIn Create()
        //{
        //    IWaveIn newWaveIn;

        //    var deviceNumber = Recording.recordingForm.comboWaveInDevice.SelectedIndex - 1;//waveIn设备数量
        //    // step2: 创建记录设备
        //    newWaveIn = new WaveInEvent() { DeviceNumber = deviceNumber };

        //    var sampleRate = (int)Recording.recordingForm.comboBoxSampleRate.SelectedItem;
        //    var channels = Recording.recordingForm.comboBoxChannels.SelectedIndex + 1;
        //    newWaveIn.WaveFormat = new WaveFormat(sampleRate, channels);
        //    newWaveIn.DataAvailable += OnDataAvailable;
        //    newWaveIn.RecordingStopped += OnRecordingStopped;
        //    return newWaveIn;
        //}
    }
}

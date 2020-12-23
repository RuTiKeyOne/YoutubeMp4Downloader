﻿using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using YoutubeMp3DownloaderLibrary.Model;
using YoutubeMp3DownloaderLibrary.Model.Commands;
using YoutubeMp3DownloaderLibrary.Model.Dialogs;
using YoutubeMp3DownloaderLibrary.Model.UI;
using YoutubeMp3DownloaderLibrary.Model.UI.Text.DataFile;
using YoutubeMp3DownloaderLibrary.ViewModel.Base;

namespace YoutubeMp3DownloaderLibrary.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region UI objects

        private UIClose Close;
        private Sing Sing;
        private Data Data;
        private Dialog Dialog;

        #endregion

        #region UI text

        #region UI Sing text
        private string singText = null;
        public string SingText
        {
            get => singText;
            set => SetProperty(ref singText, value);
        }
        #endregion

        #region UI Name file
        private string nameFile = null;
        public string NameFile
        {
            get => nameFile;
            set => SetProperty(ref nameFile, value);
        }

        #endregion

        #region UI Speed

        private string speedInternet = null;
        public string SpeedInternet
        {
            get => speedInternet;
            set => SetProperty(ref speedInternet, value);
        }

        #endregion

        #region UI Size

        private string sizeFile = null;
        public string SizeFile
        {
            get => sizeFile;
            set => SetProperty(ref speedInternet, value);
        }

        #endregion

        #region UI Url

        private string url = null;
        public string Url
        {
            get => url;
            set => SetProperty(ref url, value);
        }

        #endregion

        #endregion

        #region Close command
        public RelayCommand<Window> CloseMainWindow { get; private set; }

        public void CloseWindow(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }

        #endregion

        #region Download command

        public ICommand Download { get; set; }

        public bool CanDownloadExecute(object sender) => true;

        public void DownloadExecute(object sender)
        {
          
        }

        #endregion

        #region Constructor
        public MainViewModel()
        {
            //Initial UI objects
            Sing = new();
            Close = new();
            Data = new();
            Dialog = new();

            //Initial UI text
            singText = Sing.GetInitial();
            nameFile = Data.GetInitial(new DataName());
            speedInternet = Data.GetInitial(new DataSpeed());
            sizeFile = Data.GetInitial(new DataSize());

            //Initial Command
            CloseMainWindow = new RelayCommand<Window>(this.CloseWindow);
            Download = new ActionCommand(DownloadExecute, CanDownloadExecute);
        }

        #endregion

    }
}

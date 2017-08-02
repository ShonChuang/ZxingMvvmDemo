using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace ZxingMvvm.Demo.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private readonly IPageDialogService _dialogService;
        private readonly INavigationService _navigationService;


        #region IsVisible
        private bool _IsVisible = false;
        /// <summary>
        /// IsScanning
        /// </summary>
        public bool IsVisible
        {
            get { return this._IsVisible; }
            set { this.SetProperty(ref this._IsVisible, value); }
        }
        #endregion

        #region IsScanning
        private bool _IsScanning = false;
        /// <summary>
        /// IsScanning
        /// </summary>
        public bool IsScanning
        {
            get { return this._IsScanning; }
            set { this.SetProperty(ref this._IsScanning, value); }
        }
        #region IsAnalyzing
        private bool _IsAnalyzing = false;
        /// <summary>
        /// IsAnalyzing
        /// </summary>
        public bool IsAnalyzing
        {
            get { return this._IsAnalyzing; }
            set { this.SetProperty(ref this._IsAnalyzing, value); }
        }
        #endregion
        #region Result
        private Result _Result;
        /// <summary>
        /// Result
        /// </summary>
        public Result Result
        {
            get { return this._Result; }
            set { this.SetProperty(ref this._Result, value); }
        }
        #endregion

        #endregion


        #region MODEL
        private string _MODEL;
        /// <summary>
        /// MODEL
        /// </summary>
        public string MODEL
        {
            get { return this._MODEL; }
            set { this.SetProperty(ref this._MODEL, value); }
        }
        #endregion

        #region MODELID
        private string _MODELID;
        /// <summary>
        /// MODELID
        /// </summary>
        public string MODELID
        {
            get { return this._MODELID; }
            set { this.SetProperty(ref this._MODELID, value); }
        }
        #endregion

        public DelegateCommand QRCodeScannerCommand { get; set; }
        public DelegateCommand BarCodeScannerCommand { get; set; }

        public DelegateCommand ScanResultCommand { get; set; }

        ZXingScannerView zxing;
        ZXingDefaultOverlay overlay;

        public MainPageViewModel(INavigationService navigationService
            , IPageDialogService dialogService)
        {
            QRCodeScannerCommand = new DelegateCommand(QRCodeScanner);
            BarCodeScannerCommand = new DelegateCommand(BarCodeScanner);
            ScanResultCommand = new DelegateCommand(ScanResult);

            var fooMobileBarcodeScanningOptions = new MobileBarcodeScanningOptions();
            fooMobileBarcodeScanningOptions.PossibleFormats = new List<ZXing.BarcodeFormat>() {
                BarcodeFormat.QR_CODE,
                BarcodeFormat.CODE_128,
                BarcodeFormat.CODE_39,
                BarcodeFormat.CODABAR
            };
        }

        private void ScanResult()
        {
            //throw new NotImplementedException();
            this.IsVisible = false;
            this.IsScanning = false;
            this.IsAnalyzing = false;
            if (string.IsNullOrEmpty(this.MODEL))
            {
                this.MODEL = Result.Text;
            }
            else
            {
                this.MODELID = Result.Text;
            }
        }

        private void BarCodeScanner()
        {
            //throw new NotImplementedException();
            this.IsVisible = true;
            this.IsScanning = true;
            this.IsAnalyzing = true;
        }

        private void QRCodeScanner()
        {
            this.IsVisible = true;
            this.IsScanning = true;
            this.IsAnalyzing = true;

           
        }
        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }
    }
}
